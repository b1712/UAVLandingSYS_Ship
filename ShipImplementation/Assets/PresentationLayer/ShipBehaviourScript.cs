using UnityEngine;
using System.Collections;
using Assets.ControlLayer;

using System.Collections.Generic;
using System;
using System.IO;


namespace Asset.PresentationLayer
{

    public class ShipBehaviourScript : MonoBehaviour
    {
        #region class fields
        
        // first 3 fields are public so they are accessible from Unity Interface
        public SeaState currentSeaState = SeaState.SeaState0;
        public WaveDirection currentWaveDirection = WaveDirection.Zero_Degrees;
        public ShipSpeed currentShipSpeed = ShipSpeed.Half;
        private ShipModelController shipController;
        private List<float> heaveArray;
        private List<float> pitchArray;
        private List<float> rollArray;
        private List<List<float>> motionArray = new List<List<float>>();
        private int count;
        private int modCount;
        private DateTime starttime;
        private float[] shipCoordinates = new float[18];

        #endregion

        void Start()
        {
            shipController = new ShipModelController();
            motionArray = shipController.initialShipSetup(currentSeaState, currentWaveDirection, currentShipSpeed);

            count = 0;

            heaveArray = motionArray[0];
            pitchArray = motionArray[1];
            rollArray = motionArray[2];

            // refresh rate is set to half the screen refresh rate which is 60Hz
            QualitySettings.vSyncCount = 2;

            // time for manual test
            starttime = DateTime.Now;
        }

        void Update()
        {
            modCount = count % heaveArray.Count;

            gameObject.transform.Translate(0, heaveArray[modCount] * Time.deltaTime, 0,Space.World);

            transform.eulerAngles = new Vector3(-pitchArray[modCount], 0, -rollArray[modCount]); //rollArray[modCount] * Time.deltaTime);           
            
            count++;

            recordCoordinates();

            // performing a manual test on framerate - results slightly over 12 seconds which does
            // approximate 30 fps

            if (count % 360 == 0)
            {
                var finishtime = DateTime.Now - starttime;
                print("Time in seconds for 360 frames: " + finishtime.ToString());
                starttime = DateTime.Now;
            }

        }

        private void recordCoordinates()
        {
            GameObject FindFPC = GameObject.Find("12Outer");
            Vector3 point12Outer = FindFPC.transform.position;
            FindFPC = GameObject.Find("4Outer");
            Vector3 point4Outer = FindFPC.transform.position;
            FindFPC = GameObject.Find("8Outer");
            Vector3 point8Outer = FindFPC.transform.position;
            FindFPC = GameObject.Find("12Inner");
            Vector3 point12Inner = FindFPC.transform.position;
            FindFPC = GameObject.Find("4Inner");
            Vector3 point4Inner = FindFPC.transform.position;
            FindFPC = GameObject.Find("8Inner");
            Vector3 point8Inner = FindFPC.transform.position;

            shipCoordinates[0] = point12Outer.x;
            shipCoordinates[1] = point12Outer.y;
            shipCoordinates[2] = point12Outer.z;
            shipCoordinates[3] = point4Outer.x;
            shipCoordinates[4] = point4Outer.y;
            shipCoordinates[5] = point4Outer.z;
            shipCoordinates[6] = point8Outer.x;
            shipCoordinates[7] = point8Outer.y;
            shipCoordinates[8] = point8Outer.z;

            shipCoordinates[9] = point12Inner.x;
            shipCoordinates[10] = point12Inner.y;
            shipCoordinates[11] = point12Inner.z;
            shipCoordinates[12] = point4Inner.x;
            shipCoordinates[13] = point4Inner.y;
            shipCoordinates[14] = point4Inner.z;
            shipCoordinates[15] = point8Inner.x;
            shipCoordinates[16] = point8Inner.y;
            shipCoordinates[17] = point8Inner.z;

            shipController.postShipCoordinates(shipCoordinates);
        }
    }
}