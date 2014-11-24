using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;

namespace Cheke.Modem
{
    public class Modem
    {
        public event EventHandler<RingEventArgs> Ring;
        private readonly SerialPort _port = null;

        //public Modem()
        //{
        //    string portName = XmlSettings.Instance.GetValue("PortName", "COM1");
        //    int baudRate = XmlSettings.Instance.GetValue("BaudRate", 9600);
        //    this._port = new SerialPort(portName, baudRate);

        //    this.Initialize();
        //}

        public Modem(string portName)
        {
            this._port = new SerialPort(portName, 9600);
            this.Initialize();
        }

        public Modem(string portName, int baudRate)
        {
            this._port = new SerialPort(portName, baudRate);
            this.Initialize();
        }

        private void Initialize()
        {
            this._port.DataBits = 8;
            this._port.Parity = Parity.None;
            this._port.StopBits = StopBits.One;

            this._port.ReadTimeout = this._port.WriteTimeout = 1000;
            this._port.ReadBufferSize = this._port.WriteBufferSize = 1024;

            this._port.Handshake = Handshake.None;
            this._port.ReceivedBytesThreshold = 10;
            this._port.RtsEnable = true;
            this._port.DtrEnable = true;
            this._port.NewLine = "\r";
        }

        public void Open()
        {
            if (!this._port.IsOpen)
            {
                this._port.Open();
            }
        }

        public void Listen()
        {
            this._port.DataReceived += port_DataReceived;
        }

        public void Close()
        {
            if (this._port.IsOpen)
            {
                this._port.Close();
            }
        }

        public bool SupportAT
        {
            get
            {
                this._port.WriteLine("AT");
                Thread.Sleep(500);
                string result = this._port.ReadExisting();
                return result.ToUpper().Contains("OK");
            }
        }

        public bool SupportCID
        {
            get
            {
                //List<string> commandList = XmlSettings.Instance.SectionValues("CID");
                List<string> commandList = new List<string>();
                if (commandList.Count == 0)
                {
                    commandList.Add("AT#CID=1");
                    commandList.Add("AT+VCID=1");
                    commandList.Add("AT#CLS=8#CID=1");
                    commandList.Add("AT#CID=2");
                    commandList.Add("AT%CCID=1");
                    commandList.Add("AT%CCID=2");
                    commandList.Add("AT#CC1");
                    commandList.Add("AT*ID1");
                }

                foreach (string command in commandList)
                {
                    this._port.WriteLine(command);
                    Thread.Sleep(500);
                    string result = this._port.ReadExisting();
                    if (result.ToUpper().Contains("OK"))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if(this.Ring == null)
                return;

            Thread.Sleep(2000);
            string data = this._port.ReadExisting();
            string phoneNumber = this.GetPhoneNumber(data);

            RingEventArgs eventArgs = new RingEventArgs();
            eventArgs.PhoneNumber = phoneNumber;
            eventArgs.OriginalString = data;
            foreach (EventHandler<RingEventArgs> handler in Ring.GetInvocationList())
            {
                handler.Invoke(this, eventArgs);
                if (eventArgs.Handled)
                    break;
            }
        }

        private string GetPhoneNumber(string data)
        {
            string[] splits = data.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string prefix = "NMBR";
            foreach (string item in splits)
            {
                string line = item.Trim().ToUpper();
                if(line.Length == 0)
                    continue;

                if(!line.StartsWith(prefix))
                    continue;

                string result = line.Substring(prefix.Length).Trim();
                result = result.TrimStart('=');
                return result.Trim();
            }

            return string.Empty;
        }
    }
}