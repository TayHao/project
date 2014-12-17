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
    public partial class CreateAccountForm : Form
    {
        Form1 parent;
        LogInForm preParent;
        public CreateAccountForm(Form1  arg, LogInForm arg2)
        {
            parent = arg;
            preParent = arg2;
            InitializeComponent();
            rbStudent.Checked = true;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(rbStudent.Checked)
            {
                try
                {
                    TcpClient eClient = new TcpClient(parent.config.get_ip().ToString(), parent.config.get_port());
                    StreamReader readerStream = new StreamReader(eClient.GetStream());
                    NetworkStream writerStream = eClient.GetStream();
                    MSG.MSG message = new MSG.MSG();
                    message.stat = MSG.STATUS.ADD_STUDENT;
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(writerStream, message);
                    GeneralClasses.LoginData ld = new GeneralClasses.LoginData(tUserName.Text, tUserPassword.Text);
                    GeneralClasses.StudentAccount student = new GeneralClasses.StudentAccount(ld, GeneralClasses.AccountType.STUDENT, tName.Text,
                        tSurName.Text, tMidName.Text);
                    formatter.Serialize(writerStream, student);
                    int test_flag = writerStream.ReadByte();
                    if (test_flag == 1)
                        this.Close();
                    else
                        MessageBox.Show("Пользователь с таким логином уже есть.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    formatter.Serialize(writerStream, message);
                    readerStream.Close();
                    writerStream.Close();
                    eClient.Close();
                }
                catch (SocketException exp)
                {
                    Console.WriteLine("Exception: " + exp);
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Exception: " + exp);
                }
            }
            else if(rbInstructor.Checked)
            {
                try
                {
                    TcpClient eClient = new TcpClient(parent.config.get_ip().ToString(), parent.config.get_port());
                    StreamReader readerStream = new StreamReader(eClient.GetStream());
                    NetworkStream writerStream = eClient.GetStream();
                    MSG.MSG message = new MSG.MSG();
                    message.stat = MSG.STATUS.ADD_INSTRUCTOR;
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(writerStream, message);
                    formatter.Serialize(writerStream, tTestField.Text);
                    int capture_flag = writerStream.ReadByte();
                    if(capture_flag == 1)
                    {
                        GeneralClasses.LoginData ld = new GeneralClasses.LoginData(tUserName.Text, tUserPassword.Text);
                        GeneralClasses.InstructorAccount student = new GeneralClasses.InstructorAccount(ld, GeneralClasses.AccountType.INSTRUCTOR, tName.Text,
                            tSurName.Text, tMidName.Text);
                        formatter.Serialize(writerStream, student);
                        int test_flag = writerStream.ReadByte();
                        if (test_flag == 1)
                        {
                            // это надо переделать, и на сервере
                            parent.login = true;
                            parent.account = (GeneralClasses.Account)formatter.Deserialize(writerStream);
                            this.Close();
                            preParent.Close();
                        }
                        else
                            MessageBox.Show("Пользователь с таким логином уже есть.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    }
                    else
                        MessageBox.Show("Плохой капча.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    readerStream.Close();
                    writerStream.Close();
                    eClient.Close();
                }
                catch (SocketException exp)
                {
                    Console.WriteLine("Exception: " + exp);
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Exception: " + exp);
                }
            }
        }
    }
}
