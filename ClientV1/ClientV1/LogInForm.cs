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
    public partial class LogInForm : Form
    {
        Form1 parent;
        public LogInForm(Form1 arg)
        {
            this.ControlBox = false;
            parent = arg;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateAccountForm caf = new CreateAccountForm(parent, this);
            caf.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TcpClient eClient = new TcpClient(parent.config.get_ip().ToString(), parent.config.get_port());
                StreamReader readerStream = new StreamReader(eClient.GetStream());
                NetworkStream writerStream = eClient.GetStream();
                MSG.MSG message = new MSG.MSG();
                message.stat = MSG.STATUS.LOGIN;
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(writerStream, message);
                formatter.Serialize(writerStream, tLogin.Text);
                formatter.Serialize(writerStream, tPassword.Text);
                int test_flag = writerStream.ReadByte();
                if (test_flag == 1)
                {
                    parent.login = true; // потом изменить
                    // НУЖНО ПОЛУЧИТЬ ОБЪЕКТ!!!!
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Нет такой комбинации имени и пароля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                readerStream.Close();
                writerStream.Close();
                eClient.Close();
            }
            catch(Exception exp)
            {

            }
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
