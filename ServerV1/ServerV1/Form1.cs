using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using MySql.Data.MySqlClient;
namespace ServerV1
{
    public partial class Form1 : Form
    {
        public TcpListener listener;
        public Thread thread_listener;
        public Configuration config;
        public DBConnection objDB = new DBConnection();            
        private void listen()
        {
            try
            {
                listener.Start();
                while (true)
                {
                    ClientHandler handler = new ClientHandler(listener.AcceptTcpClient(), this);
                    Thread clientThread = new Thread(new ThreadStart(handler.RunClient));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }

            }
            catch (Exception exp)
            {

            }
        }

        public Form1()
        {
            objDB.DisplayDatabase();
            if (File.Exists("config.bin"))
            {
                FileStream fs = new FileStream("config.bin", FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                config = (Configuration)formatter.Deserialize(fs);
                fs.Close();
            }
            else
                config = new Configuration();
            listener = new TcpListener(config.get_ip(), config.get_port());
            InitializeComponent();
            bServerStop.Enabled = false;
        }
        private void bServerStart_Click(object sender, EventArgs e)
        {
            thread_listener = new Thread(new ThreadStart(listen));
            thread_listener.Start();
            bServerStart.Enabled = false;
            bServerStop.Enabled = true;            
        }
        private void bServerStop_Click(object sender, EventArgs e)
        {
            listener.Stop();
            thread_listener.Abort();
            bServerStart.Enabled = true;
            bServerStop.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(thread_listener != null && thread_listener.IsAlive)
            {
                listener.Stop();
                thread_listener.Abort();
            }
            FileStream fs = new FileStream("config.bin", FileMode.OpenOrCreate);
            fs.Seek(0, SeekOrigin.Begin);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, config);
            fs.Close();
        }
    }    
    public class ClientHandler
    {
        public ClientHandler(TcpClient arg, Form1 f)
        {
            client = arg;
            form = f;
        }
        public void RunClient()
        {
            StreamReader readerStream = new StreamReader(client.GetStream());;
            NetworkStream writerStream = client.GetStream();
            try
            {
                    BinaryFormatter outFormatter = new BinaryFormatter();
                    MSG.MSG message;
                        message = (MSG.MSG)outFormatter.Deserialize(writerStream);
                        switch (message.stat)
                        {                        
                            case MSG.STATUS.ADD_STUDENT:
                                //while(!writerStream.DataAvailable); а вдруг ненужно:)
                                GeneralClasses.StudentAccount student = (GeneralClasses.StudentAccount)outFormatter.Deserialize(writerStream);
                                // TODO;
                                break;
                            case MSG.STATUS.ADD_INSTRUCTOR:
                                string capt = (string)outFormatter.Deserialize(writerStream);
                                if (capt == form.config.get_test_string())
                                {
                                    writerStream.WriteByte(1);
                                    GeneralClasses.InstructorAccount instructor = (GeneralClasses.InstructorAccount)outFormatter.Deserialize(writerStream);
                                    int test_mess = form.objDB.InsertInstructor(instructor);
                                    if (test_mess != 0)
                                    {
                                        writerStream.WriteByte(1);
                                        instructor.setId(test_mess);
                                        // это надо переделать, можно отправить просто id, на клиенте тоже перепили
                                        outFormatter.Serialize(writerStream, instructor);
                                    }
                                    else
                                        writerStream.WriteByte(0);
                                }
                                else 
                                    writerStream.WriteByte(0);
                                break;
                            case MSG.STATUS.LOGIN:
                                string login = (string)outFormatter.Deserialize(writerStream);
                                string password = (string)outFormatter.Deserialize(writerStream);
                                bool fl = form.objDB.CheckPass(login, password);
                                if (fl)
                                    writerStream.WriteByte(1);
                                else
                                    writerStream.WriteByte(0);
                                break;
                            case MSG.STATUS.GET_TABLE:
                                Console.WriteLine("test");
                                break;
                        }                    
                readerStream.Close();
                writerStream.Close();
                client.Close();
            }
            catch(Exception exp)
            {
                readerStream.Close();
                writerStream.Close();
                client.Close();
            }
            /*StreamReader readerStream = new StreamReader(client.GetStream());
            NetworkStream writerStream = client.GetStream();
            string returnData = readerStream.ReadLine();
            returnData += "\r\n";
                byte[] dataWrite = Encoding.ASCII.GetBytes(returnData);
                writerStream.Write(dataWrite, 0, dataWrite.Length);
           
            client.Close();*/
        }        
        // Data
        private TcpClient client;
        private Form1 form;
    }
}
