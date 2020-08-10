using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace UserHelper
{
    public delegate void SocketEventHandle(object sender, object data);
    public partial class SocketController : IDisposable
    {
        public int UserID;
        public int ContestShiftID;

        public Socket Sock
        {
            get
            {
                return socket;
            }
        }
        Socket socket;
        Thread receiveThread;
        public bool Connect(IPEndPoint ipe)
        {
            try
            {
                lock (objectSync)
                {
                    if (socket != null)
                    {
                        socket.Dispose();
                    }
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(ipe);
                    netStream = null;
                    sReader = null;
                    sWriter = null;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool IsServer { get; set; }
        public SocketController(Socket socket = null)
        {
            if (socket != null)
                IsServer = true;
            this.socket = socket;
            receiveThread = new Thread(new ThreadStart(ReceiveData));
            receiveThread.Start();
        }
        public bool SendData(string data)
        {
            bool result = false;
            if (Writer != null)
            {
                Writer.WriteLine(data);
                Writer.Flush();
                result = true;
            }
            return result;
        }
        public event SocketEventHandle Receive;
        public event SocketEventHandle NoConnected;
        private void ReceiveData()
        {
            while (true)
            {
                try
                {
                    var data = Reader.ReadLine();
                    if (Receive != null)
                    {
                        Receive(this, data);
                    }
                }
                catch (Exception ex)
                {
                    if (NoConnected != null)
                    {
                        NoConnected(this, ex);
                        if (IsServer)
                            break;
                    }
                }
            }
        }

        public void Dispose()
        {

            receiveThread.Abort();
            socket.Shutdown(SocketShutdown.Both);
            socket.Dispose();
        }
     
    }
}
