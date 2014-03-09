using System.Net;
using System.Net.Sockets;
using System;

namespace Assets.ServiceLayer
{

    public class UdpConnectionShipCoordinates
    {
        #region class fields

        private const string Address = "192.168.1.100";
        private const int Port = 9060;
        private readonly IPEndPoint _ipep;
        private readonly Socket _server;
        private byte[] _byteArray;

        #endregion

        public UdpConnectionShipCoordinates()
        {
            _ipep = new IPEndPoint(IPAddress.Parse(Address), Port);

            _server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }
        
        public void PostShipCoordinates(float [] coordinates)
        {
            try
            {
                _byteArray = new byte[coordinates.Length * 4];
                Buffer.BlockCopy(coordinates, 0, _byteArray, 0, _byteArray.Length);

                _server.SendTo(_byteArray, _byteArray.Length, SocketFlags.None, _ipep);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}