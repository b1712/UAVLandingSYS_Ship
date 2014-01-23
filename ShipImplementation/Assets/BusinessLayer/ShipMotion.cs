using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Assets.BusinessLayer
{
	public class ShipMotion
	{
        SeaState currentSeaState;
        WaveDirection currentWaveDirection;
        ShipSpeed currentShipSpeed;

        public ShipMotion(SeaState state, WaveDirection wind, ShipSpeed speed)
        {
            currentSeaState = state;
            currentWaveDirection = wind;
            currentShipSpeed = speed;
        }

        public string calculateShipMotion()
        {
            // will be returning an array of floats
            int wave = (int)currentWaveDirection;
            int state = (int)currentSeaState;
            int speed = (int)currentShipSpeed;

            string test1 = wave.ToString();
            string test2 = state.ToString();
            string test3 = speed.ToString();

            string message = "Wave direction = " + test1 +
                             ", Sea State = " + test2 + ", Ship Speed = " + test3;
            return message;
        }
	}
}
