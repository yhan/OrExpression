//TcpEchoServerTimeout.cs
using System;// For Console, Int32, ArgumentException, Environment
using System.Net;// For IPAddress
using System.Net.Sockets;// For TcpListener, TcpClient

class TcpEchoServerTimeout
{

    private const int BUFSIZE = 32;// Size of receive buffer
    
    private const int BACKLOG = 5;// Outstanding conn queue max size
    private const int TIMELIMIT = 100_000;// Default time limit (ms)

    static void Main(string[] args)
    {
        if (args.Length > 1)// Test for correct # of args
            throw new ArgumentException("Parameters: [<Port>]");

        int servPort = (args.Length == 1) ? Int32.Parse(args[0]) : 7;

        Socket server = null;

        try
        {
            // Create a socket to accept client connections
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(new IPEndPoint(IPAddress.Any, servPort));

            server.Listen(backlog: BACKLOG);
        }
        catch (SocketException se)
        {
            Console.WriteLine(se.ErrorCode + ": " + se.Message);
            Environment.Exit(se.ErrorCode);
        }

        byte[] rcvBuffer = new byte[BUFSIZE];// Receive buffer
        int bytesRcvd;// Received byte count
        int totalBytesEchoed = 0;// Total bytes sent

        for (;;)
        {
            // Run forever, accepting and servicing connections

            Socket client = null;

            try
            {

                client = server.Accept();// Get client connection

                DateTime starttime = DateTime.Now;

                // Set the ReceiveTimeout
                client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, TIMELIMIT);
           
                Console.Write("Handling client at " + client.RemoteEndPoint + " - ");

                // Receive until client closes connection, indicated by 0 return value
                totalBytesEchoed = 0;
                while ((bytesRcvd = client.Receive(rcvBuffer, 0, rcvBuffer.Length, SocketFlags.None)) > 0)
                {
                    client.Send(buffer: rcvBuffer, offset: 0, size: bytesRcvd, SocketFlags.None);
                    totalBytesEchoed += bytesRcvd;

                    // Check elapsed time
                    TimeSpan elapsed = DateTime.Now - starttime;
                    if (TIMELIMIT - elapsed.TotalMilliseconds < 0)
                    {
                        Console.WriteLine("Aborting client, timelimit " + TIMELIMIT + "ms exceeded; echoed " + totalBytesEchoed + " bytes");
                        client.Close();
                        throw new SocketException(10060);
                    }

                    // Set the ReceiveTimeout
                    var oldTimeout = client.ReceiveTimeout;
                    client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, (int)(TIMELIMIT - elapsed.TotalMilliseconds));
                    Console.WriteLine($"Reduce ReceiveTimeout {oldTimeout}=> {(int)(TIMELIMIT - elapsed.TotalMilliseconds)}");
                    starttime = DateTime.Now;

                    Console.WriteLine($"Received={bytesRcvd}. Total echoed {totalBytesEchoed} bytes.");
                }
                

                client.Close();// Close the socket. We are done with this client!
                Console.WriteLine($"{client} closed!");

            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10060)
                {
                    // WSAETIMEDOUT: Connection timed out
                    Console.WriteLine("Aborting client, timelimit " + TIMELIMIT + "ms exceeded; echoed " + totalBytesEchoed + " bytes");
                }
                else
                {
                    Console.WriteLine(se.ErrorCode + ": " + se.Message);
                }
                client.Close();
            }
        }
    }
}
