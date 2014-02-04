using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System;

namespace Assets.ServiceLayer
{

    public class UDPConnectionShipToUAV
    {
        private string address = "127.0.0.1";
        private int port = 9050;
        IPEndPoint ipep;
        Socket server;
        float [] coordinateArray = new float[20];
        byte[] byteArray;

        public UDPConnectionShipToUAV()
        {
            ipep = new IPEndPoint(
                            IPAddress.Parse(address), port); //9050

            server = new Socket(AddressFamily.InterNetwork,
                           SocketType.Dgram, ProtocolType.Udp);
        }


        //public UDPConnectionShipToUAV(string address, int port)
        //{
        //    //this.address = address;
        //    //this.port = port;
        //}
        
        public void postCoordinates(float [] coordinates)
        {
            
            

            //*************** String message

            //byte[] data = new byte[1024];
            //string message = textBoxMessage.Text;
            //data = Encoding.ASCII.GetBytes(message);

            //server.SendTo(data, data.Length, SocketFlags.None, ipep);

            //*************** Array of floats

            

            //for (int i = 0; i < coordinates.Count; i++)
            //{
            //    coordinateArray[i] = coordinates[i];
            //}


            byteArray = new byte[coordinates.Length * 4];
            Buffer.BlockCopy(coordinates, 0, byteArray, 0, byteArray.Length);

            server.SendTo(byteArray, byteArray.Length, SocketFlags.None, ipep);

        }

    }

}