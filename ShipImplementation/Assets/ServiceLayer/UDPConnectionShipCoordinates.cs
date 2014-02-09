using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System;

namespace Assets.ServiceLayer
{

    public class UDPConnectionShipCoordinates
    {
        #region class fields

        private string address = "192.168.1.100";
        //private string address = "127.0.0.1";
        private int port = 9060;
        private IPEndPoint ipep;
        private Socket server;
        private byte[] byteArray;

        #endregion

        public UDPConnectionShipCoordinates()
        {
            ipep = new IPEndPoint(IPAddress.Parse(address), port);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }
        
        public void postShipCoordinates(float [] coordinates)
        {
            try
            {
                byteArray = new byte[coordinates.Length * 4];
                Buffer.BlockCopy(coordinates, 0, byteArray, 0, byteArray.Length);

                server.SendTo(byteArray, byteArray.Length, SocketFlags.None, ipep);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}