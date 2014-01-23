using UnityEngine;
using System.Collections;
using Assets.ControlLayer;

namespace Asset.PresentationLayer
{

    public class ShipBehaviourScript : MonoBehaviour
    {

        public SeaState currentSeaState = SeaState.SeaState1;
        public WaveDirection currentWaveDirection = WaveDirection.Zero_Degrees;
        public ShipSpeed currentShipSpeed = ShipSpeed.Half;
        ShipModelController shipController;
        private string test = "";

        void Start()
        {
            shipController = new ShipModelController();
            test = shipController.initialShipSetup(currentSeaState, currentWaveDirection, currentShipSpeed);
            print(test);
        }

        void Update()
        {
            
        }


    }

}