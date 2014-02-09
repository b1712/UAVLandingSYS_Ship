using UnityEngine;
using System.Collections;
using Assets.ServiceLayer;
using System.ComponentModel;

namespace Asset.PresentationLayer
{

    public class UAVBehaviourScript : MonoBehaviour
    {
        UDPConnectionUAVCoordinates udpUAV = new UDPConnectionUAVCoordinates();

        #region class fields

        private float[] uavCoordinates = new float[1];
        private float zCoord = -130.0f;
        private float yCoord = 50.0f;
        private float xCoord = 0.0f;

        #endregion

        void Start()
        {
            udpUAV.PropertyChanged += new PropertyChangedEventHandler(uavCoordinatesPropertyChange);
            
            uavCoordinates[0] = -130.0f;
            udpUAV.Starter();
        }

        void uavCoordinatesPropertyChange(object sender, PropertyChangedEventArgs e)
        {
            uavCoordinates = udpUAV.UAVCoordinates;
            xCoord = uavCoordinates[0];
            yCoord = uavCoordinates[1];
            zCoord = uavCoordinates[2];
        }

        void Update()
        {
            gameObject.transform.position = new Vector3(xCoord, yCoord, zCoord);
        }

    }

}