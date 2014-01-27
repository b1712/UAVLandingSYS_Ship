using UnityEngine;
using System.Collections;
using Assets.ControlLayer;
using System.Collections.Generic;

namespace Asset.PresentationLayer
{

    public class ShipBehaviourScript : MonoBehaviour
    {

        public SeaState currentSeaState = SeaState.SeaState0;
        public WaveDirection currentWaveDirection = WaveDirection.Zero_Degrees;
        public ShipSpeed currentShipSpeed = ShipSpeed.Half;
        ShipModelController shipController;
        //private string test = "";
        private List<float> heaveArray;
        private int count;
        private int modCount;

        void Start()
        {
            shipController = new ShipModelController();
            heaveArray = shipController.initialShipSetup(currentSeaState, currentWaveDirection, currentShipSpeed);
            //print(test);
            count = 0;
        }

        void Update()
        {
            modCount = count % heaveArray.Count;

            //print(heaveArray[modCount].ToString());
            gameObject.transform.position = new Vector3(0, heaveArray[modCount], 0);
            count++;
        }


    }

}