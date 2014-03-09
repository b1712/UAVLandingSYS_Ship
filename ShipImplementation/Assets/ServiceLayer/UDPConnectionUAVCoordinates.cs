using System;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;

namespace Assets.ServiceLayer
{
    class UdpConnectionUavCoordinates : INotifyPropertyChanged
    {
        private Socket _udpSocket;
        private byte[] _buffer;

        public float[] FloatArray = new float[1];

        private float[] _uavCoordinates = new float[1];

        public float[] UavCoordinates
        {
            get { return _uavCoordinates; }
            set
            {
                _uavCoordinates = value;
                NotifyPropertyChanged("UAVCoordinates");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Starter()
        {
            FloatArray[0] = -130.0f;

            _udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _udpSocket.Bind(new IPEndPoint(IPAddress.Any, 9050));
            _buffer = new byte[1024];

            EndPoint newClientEndPoint = new IPEndPoint(IPAddress.Any, 0);
            _udpSocket.BeginReceiveFrom(_buffer, 0, _buffer.Length, SocketFlags.None, 
                                ref newClientEndPoint, DoReceiveFrom, _udpSocket);
        }

        private void DoReceiveFrom(IAsyncResult asynResultr)
        {
            try
            {
                // Some of the code (next 7 lines and the code in the constructor) for this socket 
                // configuration was taken from: 
                // http://acrocontext.wordpress.com/2013/08/15/c-simple-udp-listener-in-asynchronous-way/
                // and altered to suit the project requirements.
                
                var receiveSocket = (Socket)asynResultr.AsyncState;
                EndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);

                int datagramLength = receiveSocket.EndReceiveFrom(asynResultr, ref clientEndPoint);
                var data = new byte[datagramLength];

                Array.Copy(_buffer, data, datagramLength);

                EndPoint newClientEndPoint = new IPEndPoint(IPAddress.Any, 0);

                _udpSocket.BeginReceiveFrom(_buffer, 0, _buffer.Length, SocketFlags.None, 
                                    ref newClientEndPoint, DoReceiveFrom, _udpSocket);

                FloatArray = new float[data.Length / sizeof(float)];

                int index = 0;

                for (int i = 0; i < FloatArray.Length; i++)
                {
                    FloatArray[i] = BitConverter.ToSingle(data, index);
                    index += sizeof(float);
                }

                UavCoordinates = FloatArray;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
