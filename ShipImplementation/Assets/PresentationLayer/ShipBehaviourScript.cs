using UnityEngine;
using System.Collections;
using Assets.ControlLayer;
using System.Collections.Generic;
using System;

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
        private List<List<float>> motionArray = new List<List<float>>();
        private int count;
        private int modCount;
        DateTime starttime;
        DateTime finishtime;

        void Start()
        {
            shipController = new ShipModelController();
            motionArray = shipController.initialShipSetup(currentSeaState, currentWaveDirection, currentShipSpeed);

            count = 0;

            heaveArray = motionArray[0];
            pitchArray = motionArray[1];

            // refresh rate is set to half the screen refresh rate which is 60Hz
            QualitySettings.vSyncCount = 2;

            // time for manual test
            starttime = DateTime.Now;
        }

        void Update()
        {
            modCount = count % heaveArray.Count;

            gameObject.transform.Translate(0, heaveArray[modCount] * Time.deltaTime, 0);

            transform.eulerAngles = new Vector3( -pitchArray[modCount], 0, 0 * Time.deltaTime);
            count++;

            print(pitchArray[modCount].ToString() + "   " + heaveArray[modCount]);

            // performing a manual test on framerate - results slightly over 12 seconds which does
            // approximate 30 fps

            if (count == 360)
            {
                var finishtime = DateTime.Now - starttime;
                print("**************" + finishtime.ToString());
            }
        }
    }
}