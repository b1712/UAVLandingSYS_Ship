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
        IState stateStrategy;
        private float relativeSpeed = 0.0f;
        private List<float> heaveArray = new List<float>();
        //private List<float> rollArray = new List<float>();
        //private List<float> pitchArray = new List<float>();
        //private List<List<float>> motionArray = new List<List<float>>();
        private readonly int numberOfWaves = 6;
        private float waveSampleFactor = 20;
        private float heaveValue = 0;

        public ShipMotion(SeaState state, WaveDirection direction, ShipSpeed speed)
        {
            currentSeaState = state;
            currentWaveDirection = direction;
            currentShipSpeed = speed;

            setSeaStateStrategy();
            stateStrategy.newWaveStatistics();

            //calculate the relative speed only once for each run of the application
            calculateRelativeSpeed();

        }

        public List<float> calculateShipMotion()
        {
            populateHeaveArray();
            //populateRollArray();
            //populatePitchArray();

            return heaveArray;
        }

        private void setSeaStateStrategy()
        {
            switch ((int)currentSeaState)
            {
                case 0:
                    stateStrategy = new SeaStateZero();
                    break;
                case 3:
                    stateStrategy = new SeaStateThree();
                    break;
                case 6:
                    stateStrategy = new SeaStateSix();
                    break;
                default:
                    // default is set to Sea State 0 the same as case 0
                    stateStrategy = new SeaStateZero();
                    break;
            }
        }

        private void calculateRelativeSpeed()
        {
            switch ((int)currentWaveDirection)
            {
                case 0:
                    relativeSpeed = (float)currentShipSpeed + stateStrategy.WaveSpeed;
                    break;
                case 45:
                    relativeSpeed = (float)currentShipSpeed + stateStrategy.WaveSpeed / 2;
                    break;
                case 90:
                    relativeSpeed = (float)stateStrategy.WaveSpeed;
                    break;
                default:
                    //default is set to 0 degrees, the same as case 0 
                    relativeSpeed = (float)currentShipSpeed + stateStrategy.WaveSpeed;
                    break;
            }

        }

        private void populateHeaveArray()
        {
            if (currentSeaState != SeaState.SeaState0)
            {
                for (int i = 0; i < numberOfWaves; i++)
                {
                    float samples = stateStrategy.Wavelength / relativeSpeed * waveSampleFactor;

                    for (int j = 0; j < samples; j++)
                    {
                        heaveValue = stateStrategy.WaveHeight * (float)Math.Sin(2 * Math.PI * j / samples);

                        heaveArray.Add(heaveValue);
                    }

                    stateStrategy.newWaveStatistics();
                }
            }
            else
            {
                heaveArray.Add(stateStrategy.WaveHeight);
            }
            
        }

        private void populateRollArray()
        {

        }

        private void populatePitchArray()
        {

        }
	}
}
