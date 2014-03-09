using UnityEngine;
using Assets.ControlLayer;
using Assets.BusinessLayer;
using System.Collections.Generic;
using System;

namespace Assets.PresentationLayer
{

    public class ShipBehaviourScript : MonoBehaviour
    {
        #region class fields
        
        // first 3 fields are public so they are accessible from Unity Interface
        public SeaState CurrentSeaState = SeaState.SeaState0;
        public WaveDirection CurrentWaveDirection = WaveDirection.Zero_Degrees;
        public ShipSpeed CurrentShipSpeed = ShipSpeed.Half;
        private ShipModelController _shipController;
        private List<float> _heaveArray;
        private List<float> _pitchArray;
        private List<float> _rollArray;
        private List<List<float>> _motionArray = new List<List<float>>();
        private int _count;
        private int _modCount;
        private DateTime _starttime;
        private readonly float[] _shipCoordinates = new float[18];

        #endregion

        void Start()
        {
            _shipController = new ShipModelController();
            _motionArray = _shipController.InitialShipSetup(CurrentSeaState, CurrentWaveDirection, CurrentShipSpeed);

            _count = 0;

            _heaveArray = _motionArray[0];
            _pitchArray = _motionArray[1];
            _rollArray = _motionArray[2];

            // refresh rate is set to half the screen refresh rate which is 60Hz
            QualitySettings.vSyncCount = 2;

            // time for manual test
            _starttime = DateTime.Now;
        }

        void Update()
        {
            _modCount = _count % _heaveArray.Count;

            gameObject.transform.Translate(0, _heaveArray[_modCount] * Time.deltaTime, 0,Space.World);

            transform.eulerAngles = new Vector3(-_pitchArray[_modCount], 0, -_rollArray[_modCount]); //rollArray[modCount] * Time.deltaTime);           
            
            _count++;

            RecordCoordinates();

            // performing a manual test on framerate - results slightly over 12 seconds which does
            // approximate 30 fps

            if (_count % 360 == 0)
            {
                var finishtime = DateTime.Now - _starttime;
                print("Time in seconds for 360 frames: " + finishtime.ToString());
                _starttime = DateTime.Now;
            }

        }

        private void RecordCoordinates()
        {
            var findFpc = GameObject.Find("12Outer");
            Vector3 point12Outer = findFpc.transform.position;
            findFpc = GameObject.Find("4Outer");
            Vector3 point4Outer = findFpc.transform.position;
            findFpc = GameObject.Find("8Outer");
            Vector3 point8Outer = findFpc.transform.position;
            findFpc = GameObject.Find("12Inner");
            Vector3 point12Inner = findFpc.transform.position;
            findFpc = GameObject.Find("4Inner");
            Vector3 point4Inner = findFpc.transform.position;
            findFpc = GameObject.Find("8Inner");
            Vector3 point8Inner = findFpc.transform.position;

            _shipCoordinates[0] = point12Outer.x;
            _shipCoordinates[1] = point12Outer.y;
            _shipCoordinates[2] = point12Outer.z;
            _shipCoordinates[3] = point4Outer.x;
            _shipCoordinates[4] = point4Outer.y;
            _shipCoordinates[5] = point4Outer.z;
            _shipCoordinates[6] = point8Outer.x;
            _shipCoordinates[7] = point8Outer.y;
            _shipCoordinates[8] = point8Outer.z;

            _shipCoordinates[9] = point12Inner.x;
            _shipCoordinates[10] = point12Inner.y;
            _shipCoordinates[11] = point12Inner.z;
            _shipCoordinates[12] = point4Inner.x;
            _shipCoordinates[13] = point4Inner.y;
            _shipCoordinates[14] = point4Inner.z;
            _shipCoordinates[15] = point8Inner.x;
            _shipCoordinates[16] = point8Inner.y;
            _shipCoordinates[17] = point8Inner.z;

            _shipController.PostShipCoordinates(_shipCoordinates);
        }
    }
}