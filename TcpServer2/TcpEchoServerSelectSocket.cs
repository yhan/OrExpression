//TcpEchoServerSelectSocket.cs
using System;// For Console, Int32, ArgumentException, Environment
using System.Net;// For IPAddress
using System.Collections;// For ArrayList
using System.Net.Sockets;// For Socket, SocketException

class TcpEchoServerSelectSocket
{

    private const int BUFSIZE = 32;// Size of receive buffer
    private const int BACKLOG = 5;// Outstanding conn queue max size
    private const int SERVER1_PORT = 8080;// Port for second echo server
    private const int SERVER2_PORT = 8081;// Port for second echo server

    private const int SERVER3_PORT = 8082;// Port for third echo server
    private const int SELECT_WAIT_TIME = 1000;// Microsecs for Select() to wait

    static void Main(string[] args)
    {
        Socket server1 = null;
        Socket server2 = null;
        Socket server3 = null;

        try
        {
            // Create a socket to accept client connections
            server1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server2 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server3 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server1.Bind(new IPEndPoint(IPAddress.Any, SERVER1_PORT));
            server2.Bind(new IPEndPoint(IPAddress.Any, SERVER2_PORT));
            server3.Bind(new IPEndPoint(IPAddress.Any, SERVER3_PORT));

            server1.Listen(BACKLOG);
            server2.Listen(BACKLOG);
            server3.Listen(BACKLOG);
        }
        catch (SocketException se)
        {
            Console.WriteLine(se.ErrorCode + ": " + se.Message);
            Environment.Exit(se.ErrorCode);
        }

        byte[] rcvBuffer = new byte[BUFSIZE];// Receive buffer
        int bytesRcvd;// Received byte count

        for (;;)
        {// Run forever, accepting and servicing connections
            Socket client = null;

            // Create an array list of all three sockets
            ArrayList acceptList = new ArrayList();
            acceptList.Add(server1);
            acceptList.Add(server2);
            acceptList.Add(server3);

            try
            {
                // The Select call will check readable status of each socket
                // in the list
                Socket.Select(checkRead: acceptList, checkWrite: null, checkError: null, SELECT_WAIT_TIME);

                // The acceptList will now contain ONLY the server sockets with
                // pending connections:
                for (int i = 0; i < acceptList.Count; i++)
                {
                    client = ((Socket)acceptList[i]).Accept();// Get client connection

                    IPEndPoint localEP = (IPEndPoint)((Socket)acceptList[i]).LocalEndPoint;
                    Console.Write("Server port " + localEP.Port);
                    Console.Write(" - handling client at " + client.RemoteEndPoint + " - ");

                    // Receive until client closes connection, indicated by 0 return value
                    int totalBytesEchoed = 0;
                    while ((bytesRcvd = client.Receive(rcvBuffer, 0, rcvBuffer.Length, SocketFlags.None)) > 0)
                    {
                        client.Send(rcvBuffer, 0, bytesRcvd, SocketFlags.None);
                        totalBytesEchoed += bytesRcvd;
                    }
                    Console.WriteLine("echoed {0} bytes.", totalBytesEchoed);

                    client.Close();// Close the socket. We are done with this client!
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                client.Close();
            }
        }
    }
}
