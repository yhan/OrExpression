//TcpNBEchoClient.cs
using System;// For String, Environment
using System.Text;// For Encoding
using System.IO;// For IOException
using System.Net;// For IPEndPoint, Dns
using System.Net.Sockets;
using System.Reflection.Metadata;// For TcpClient, NetworkStream, SocketException
using System.Threading;// For Thread.Sleep

public class TcpNBEchoClient// Non Blocking
{
    static void Main(string[] args)
    {
        if ((args.Length < 2) || (args.Length > 3))// Test for correct # of args
            throw new ArgumentException("Parameters: <Server> <Word> [<Port>]");

        String server = args[0];// Server name or IP address

        // Convert input String to bytes
        var content = "// Define those variables to be evaluated in the next for loop and// then used to connect to the server. These variables are defined// outside the for loop to make them accessible there after.";
        //var content = "hello world";
        byte[] byteBuffer = Encoding.ASCII.GetBytes(content);

        // Use port argument if supplied, otherwise default to 7
        int servPort = (args.Length == 3) ? Int32.Parse(args[2]) : 7;

        // Create Socket and connect
        Socket sock = null;
        try
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Connect(new IPEndPoint(Dns.Resolve(server).AddressList[0], servPort));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Environment.Exit(-1);
        }

        // Receive the same string back from the server
        int totalBytesSent = 0;// Total bytes sent so far
        int totalBytesRcvd = 0;// Total bytes received so far

        const int fixedSz = 64;
        byte[] receiveBytesBuffer = new byte[fixedSz];

        // Make sock a nonblocking Socket
        sock.Blocking = false;//<----------------- non blocking
        // Loop until all bytes have been echoed by server

        var round = 0;
        while (totalBytesRcvd < byteBuffer.Length)
        {
            // Send the encoded string to the server
            if (totalBytesSent < byteBuffer.Length)
            {
                try
                {
                    if (byteBuffer != null)
                        totalBytesSent += sock.Send(byteBuffer, offset: totalBytesSent, size: byteBuffer.Length - totalBytesSent, SocketFlags.None);

                    Console.WriteLine("Sent a total of {0} bytes to server...", totalBytesSent);
                }
                catch (SocketException se)
                {
                    if (se.ErrorCode == 10035)
                    {
                        //WSAEWOULDBLOCK: Resource temporarily unavailable
                        Console.WriteLine("Temporarily unable to send, will retry again later.");
                    }
                    else
                    {
                        Console.WriteLine(se.ErrorCode + ": " + se.Message);
                        sock.Close();
                        Environment.Exit(se.ErrorCode);
                    }
                }
            }

            try
            {
                int bytesRcvd = 0;
                
                var step = 0;
                while (sock.Available > 0)
                {
                    bytesRcvd = sock.Receive(receiveBytesBuffer, offset: 0, size: fixedSz, SocketFlags.None);
                    Console.WriteLine("Received {0} bytes from server: {1}", bytesRcvd, Encoding.ASCII.GetString(receiveBytesBuffer, index: 0, count: Math.Min(bytesRcvd, fixedSz)));
                    step++;
                }
                totalBytesRcvd += bytesRcvd;
                Console.WriteLine($"Round #{round} finished in {step} steps");
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10035)// WSAEWOULDBLOCK: Resource temporarily unavailable
                {
                    Console.WriteLine("WSAEWOULDBLOCK: Resource temporarily unavailable");
                    continue;
                }

                Console.WriteLine(se.ErrorCode + ": " + se.Message);
                break;
            }
            Sleep();

            // Console.WriteLine("Received {0} bytes from server: {1}", totalBytesRcvd, Encoding.ASCII.GetString(byteBuffer, 0, totalBytesRcvd));
            totalBytesRcvd = 0;
            totalBytesSent = 0;
            round++;

        }


        sock.Close();
        Console.ReadKey();
    }

    static void Sleep()
    {
        Console.Write(".");
        Thread.Sleep(1000);
    }
}
