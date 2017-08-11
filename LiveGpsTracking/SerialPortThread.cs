using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LiveGpsTracking
{
    class SerialPortThread
    {
        private bool running = false;
        private SerialPort port;
        private Thread thread = null;

        public delegate void LineReceivedHandler(String line);
        public event LineReceivedHandler LineReceived;

        public SerialPortThread(SerialPort port)
        {
            this.port = port;
            port.ReadTimeout = 2000;
            port.WriteTimeout = 2000;
        }

        public void Start()
        {
            running = true;
            thread = new Thread(new ThreadStart(Read));
            thread.Start();
        }

        public void Stop()
        {
            running = false;
            if (thread != null)
            {
                thread.Interrupt();
            }
            thread = null;
        }

        private void Read()
        {
            while (running)
            {
                try
                {
                    string line = port.ReadLine();
                    line = line.Replace("\r", "").Replace("\n", "");
                    LineReceived(line);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
