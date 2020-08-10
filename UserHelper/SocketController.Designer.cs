using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserHelper
{
    public partial class SocketController
    {
        private readonly object objectSync = new object();
        NetworkStream netStream;
        public NetworkStream NetStream
        {
            get
            {
                if (netStream == null)
                {
                    lock (objectSync)
                    {

                        if (netStream == null && socket != null && socket.Connected)
                        {
                            netStream = new NetworkStream(socket);
                            sReader = null;
                            sWriter = null;
                        }
                    }
                }
                return netStream;
            }
        }
        StreamReader sReader;
        public StreamReader Reader
        {
            get
            {
                if (sReader == null)
                {
                    lock (objectSync)
                    {
                        if (sReader == null){
                            if (NetStream != null)
                            {
                                sReader = new StreamReader(NetStream);
                            }else
                            {
                                sReader = null;
                            }
                        }
                            
                    }
                }
                return sReader;
            }
        }
        StreamWriter sWriter;
        public StreamWriter Writer
        {
            get
            {
                if (sWriter == null)
                {
                    lock (objectSync)
                    {
                        if (sWriter == null)
                            if (NetStream != null)
                            {
                                sWriter = new StreamWriter(NetStream);
                            }
                            else
                            {
                                sWriter = null;
                            }
                    }
                }
                return sWriter;
            }
        }
    }
}
