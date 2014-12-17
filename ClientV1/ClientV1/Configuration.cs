using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ClientV1
{
    [Serializable]
    public class Configuration
    {     
        public Configuration()
        {
            port = 3456;
            ip = IPAddress.Parse("127.0.0.1");
        }
        public void set_ip(string arg)
        {
            ip = IPAddress.Parse(arg);
        }
        public IPAddress get_ip()
        {
            return ip;
        }
        public void set_port(int arg)
        {
            if (arg >= 1024 && arg <= 49151)
                port = arg;
            else
                throw new WrongPort();
        }
        public int get_port()
        {
            return port;
        }
        // Data
        private int port;
        private IPAddress ip;
    }

    [Serializable()]
    public class WrongPort : Exception
    {        
        public override string Message
        {
            get
            {
                return base.Message;
            }
        }

        //Стандартные конструкторы
        public WrongPort() : base("Неправильный номер порта.") { }
        public WrongPort(string message) : base(message) { }
        public WrongPort(string message, Exception innerException) : base(message, innerException) { }
    }
}
