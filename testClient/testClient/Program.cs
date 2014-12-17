using System;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace testClient
{
    class Program
    {
        const int ECHO_PORT = 8080;
        static void Main(string[] args)
        {
            Console.Write("Your UserName:");
            string userName = Console.ReadLine();
            Console.WriteLine("---Logged In--->");

            try
            {
                TcpClient eClient = new TcpClient("localhost", ECHO_PORT);
                StreamReader readerStream = new StreamReader(eClient.GetStream());
                NetworkStream writerStream = eClient.GetStream();
                string dataToSend;
                dataToSend = userName;
                dataToSend += "\r\n";
                byte[] data = Encoding.ASCII.GetBytes(dataToSend);
                writerStream.Write(data, 0, data.Length);
                while(true)
                {
                    Console.Write(userName + ":");
                    dataToSend = Console.ReadLine();
                    dataToSend += "\r\n";
                    data = Encoding.ASCII.GetBytes(dataToSend);
                    writerStream.Write(data, 0, data.Length);
                    if (dataToSend.IndexOf("QUIT") > -1)
                        break;
                    string returnData;
                    returnData = readerStream.ReadLine();
                    Console.WriteLine("Server: " + returnData);
                }
                eClient.Close();
            }
            catch(Exception exp)
            {
                Console.WriteLine("Exception: " + exp);
            }
        }
    }
}
