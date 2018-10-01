using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using Skat;

namespace ConcurrentServer
{
    public class Service
    {
        private TcpClient ConnectionSocket { get; }

        public Service(TcpClient connectionSocket)
        {
            ConnectionSocket = connectionSocket;
        }

        public void DoIt()
        {
            while (true)
            {
                try
                {
                    Stream ns = ConnectionSocket.GetStream();
                    var sr = new StreamReader(ns);
                    var sw = new StreamWriter(ns) {AutoFlush = true};
                    var message1 = sr.ReadLine();
                    double message2 = double.Parse(sr.ReadLine());
                    var answer = "";

                    if (message1 == string.Empty)
                    {
                        Console.WriteLine("Empty string detected!");
                        Console.WriteLine(
                            "Either the client sent an empty string or the connection is lost.\nRestarting server");
                        Thread.Sleep(2300);
                        Console.Clear();
                        ns.Close();
                        ConnectionSocket.Close();
                        break;
                    }

                    while (!string.IsNullOrEmpty(message1) && message2 != 0)
                    {
                        Console.WriteLine("Client: " + message1);
                        Console.WriteLine("Client: " + message2);

                        if (message1 == "stop")
                        {
                            Console.WriteLine("Received interrupt signal!");
                            Console.WriteLine("The server will close the connection and wait for a new client.");
                            sw.WriteLine("Received interrupt signal! Closing connection...");
                            Thread.Sleep(2300);
                            Console.Clear();
                            ns.Close();
                            ConnectionSocket.Close();
                            break;
                        }

                        if (message1 == "Personbil")
                        {
                            Afgift a = new Afgift();
                            answer = (a.BilAfgift(message2)).ToString();
                        } else if (message1 == "Elbil")
                        {
                            Afgift a = new Afgift();
                            answer = (a.ElBilAfgift(message2)).ToString();
                        }

                        // Responds to client.
                        //answer = message1.ToUpper();
                        sw.WriteLine(answer);
                        message1 = sr.ReadLine();
                    }

                    // Closes connection after client disconnect.
                    ns.Close();
                    ConnectionSocket.Close();
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Caught a ArgumentNullException");
                    Console.WriteLine("Probably lost connection to client.\nEnding thread...");
                    ConnectionSocket.Close();
                    break;
                }
                catch (IOException)
                {
                    Console.WriteLine("Caught a IOException");
                    Console.WriteLine("Probably lost connection to client.\nEnding thread...");
                    ConnectionSocket.Close();
                    break;
                }
            }
        }
    }
}