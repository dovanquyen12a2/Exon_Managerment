using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserHelper
{
    public class ServerSide : IDisposable
    {
        public event SocketEventHandle ClientConnected;
        public event SocketEventHandle ClientDisConnected;
        public BindingList<SocketController> ClientList = new BindingList<SocketController>();
        Task MainTask;
        public ServerSide(int port = 3001)
        {
            MainTask = Task.Factory.StartNew(() =>
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, port);
                Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                newsock.Bind(ipep);
                newsock.Listen(100);
                while (true)
                {
                    Socket client = newsock.Accept();
                    var clientWinSock = new SocketController(client);
                    clientWinSock.NoConnected += new SocketEventHandle(clientWinSock_NoConnected);
                    ClientList.Add(clientWinSock);
                    if (ClientConnected != null)
                        ClientConnected(this, clientWinSock);
                }
            });
        }
        Socket newsock;
        public ServerSide(string ip , int port = 3001)
        {

            try
            {
                MainTask = Task.Factory.StartNew(() =>
                {
                    IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), port);
                    newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    
                  //  int count_port_error = 0;

                  
                        newsock.Bind(ipep);
                        newsock.Listen(100);
                    while (true)
                    {
                        Application.DoEvents();
                        Socket client = newsock.Accept();
                            var clientWinSock = new SocketController(client);
                            clientWinSock.NoConnected += new SocketEventHandle(clientWinSock_NoConnected);
                            ClientList.Add(clientWinSock);
                            if (ClientConnected != null)
                                ClientConnected(this, clientWinSock);          
                    }
                });
            }
            catch 
            {
                return;
            }

        }
        static object objectSync = new object();
        void clientWinSock_NoConnected(object sender, object data)
        {
            lock (objectSync)
            {
                for (int i = ClientList.Count - 1; i >= 0; i--)
                {
                    if (sender == ClientList[i])
                        ClientList.RemoveAt(i);
                }
                if (ClientDisConnected != null)
                    ClientDisConnected(this, sender);
            }
        }

        public void CloseSocket()
        {
            newsock.Dispose();
            newsock.Close();
           
        }

        public void Dispose()
        {
            foreach (var item in ClientList)
            {
                if (item != null)
                {
                    item.Dispose();
                  
                }
            }
            
        }
    }
}
