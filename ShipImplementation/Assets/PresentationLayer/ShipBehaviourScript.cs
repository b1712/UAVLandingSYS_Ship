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
        public SeaState currentSeaState = SeaState.SeaState0;
        public WaveDirection currentWaveDirection = WaveDirection.Zero_Degrees;
        public ShipSpeed currentShipSpeed = ShipSpeed.Half;
        ShipModelController shipController;
        private List<float> heaveArray;
        private List<float> pitchArray;
        private List<float> rollArray;
        private List<List<float>> motionArray = new List<List<float>>();
        private int count;
        private int modCount;
        DateTime starttime;
        DateTime finishtime;

        //Generate test data
        private List<float> testCoord = new List<float>();
        private string data = "";

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

            //print(pitchArray[modCount].ToString() + "   " + heaveArray[modCount] + "   " + rollArray[modCount] + "   " + count);


            printCoordinates();

            // performing a manual test on framerate - results slightly over 12 seconds which does
            // approximate 30 fps

            if (count == 360)
            {
                var finishtime = DateTime.Now - starttime;
                print("**************" + finishtime.ToString());

                

                foreach (var value in testCoord)
                {
                    data = data + value.ToString() + ",";
                }

                string fileName = currentSeaState.ToString() + "_" + currentWaveDirection.ToString()
                    + "_" + currentShipSpeed.ToString();

                System.IO.File.WriteAllText (@"C:\Users\Brian\Documents\GitHub\UAVLandingSYS_Ship\TestData_Ship\" 
                    + fileName + ".txt", data);


            }
        }

        private void printCoordinates()
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

            testCoord.Add(point12Outer.x);
            testCoord.Add(point12Outer.y);
            testCoord.Add(point12Outer.z);
            testCoord.Add(point4Outer.x);
            testCoord.Add(point4Outer.y);
            testCoord.Add(point4Outer.z);
            testCoord.Add(point8Outer.x);
            testCoord.Add(point8Outer.y);
            testCoord.Add(point8Outer.z);
            testCoord.Add(point12Inner.x);
            testCoord.Add(point12Inner.y);
            testCoord.Add(point12Inner.z);
            testCoord.Add(point4Inner.x);
            testCoord.Add(point4Inner.y);
            testCoord.Add(point4Inner.z);
            testCoord.Add(point8Inner.x);
            testCoord.Add(point8Inner.y);
            testCoord.Add(point8Inner.z);

            //print(point12Outer.x + ", " + point12Outer.y + ", " + point12Outer.z + "---" + 
            //    point4Outer.x + ", " + point4Outer.y + ", " + point4Outer.z + "---" + 
            //    point8Outer.x + ", " + point8Outer.y + ", " + point8Outer.z);
        }
    }
}