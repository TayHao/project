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
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClientV1
{
    public partial class Form1 : Form
    {
        public GeneralClasses.Account account;
        public bool login = false;
        public Configuration config;
        public Form1()
        {
            if (File.Exists("config.bin"))
            {
                FileStream fs = new FileStream("config.bin", FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                config = (Configuration)formatter.Deserialize(fs);
                fs.Close();
            }
            else
                config = new Configuration();
            login = false;
            LogInForm lg = new LogInForm(this);
            lg.ShowDialog(this);
            if (login)
            {
                InitializeComponent();
            }
            else
                Environment.Exit(0);
        }

        private void btestSend_Click(object sender, EventArgs e)
        {        
            try
            {
                TcpClient eClient = new TcpClient(config.get_ip().ToString(), config.get_port());
                StreamReader readerStream = new StreamReader(eClient.GetStream());
                NetworkStream writerStream = eClient.GetStream();
                MSG.MSG message = new MSG.MSG();
                message.stat = MSG.STATUS.GET_TABLE;
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(writerStream, message);
                readerStream.Close();
                writerStream.Close();
                eClient.Close();
            }
            catch(SocketException exp)
            {
                Console.WriteLine("Exception: " + exp);
            }
            catch(Exception exp)
            {
                Console.WriteLine("Exception: " + exp);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileStream fs = new FileStream("config.bin", FileMode.OpenOrCreate);
            fs.Seek(0, SeekOrigin.Begin);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, config);
            fs.Close();
        }
    }    
}
