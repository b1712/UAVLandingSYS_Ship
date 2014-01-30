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
        private float relativeWavelengthFactor = 0.0f;
        private List<int> samplesPerWaveList = new List<int>();
        private List<float> heaveArray = new List<float>();
        //private List<float> rollArray = new List<float>();
        private List<float> pitchArray = new List<float>();
        private List<List<float>> motionArray = new List<List<float>>();
        private float waveSampleFactor = 30.0f;
        private float nextPitchAngle = 0.0f;
        private float heaveValue = 0.0f;

        private readonly int NUMBER_OF_WAVES = 6;

        public ShipMotion(SeaState state, WaveDirection direction, ShipSpeed speed)
        {
            currentSeaState = state;
            currentWaveDirection = direction;
            currentShipSpeed = speed;

            setSeaStateStrategy();
            stateStrategy.newWaveStatistics();

            //calculate the relative speed only once for each run of the application
            calculateRelativeValues();
        }

        public List<List<float>> calculateShipMotion()
        {
            populateHeaveArray();
            //populateRollArray();
            populatePitchArray();

            motionArray.Add(heaveArray);
            motionArray.Add(pitchArray);

            return motionArray;
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

        private void calculateRelativeValues()
        {
            switch ((int)currentWaveDirection)
            {
                case 0:
                    relativeSpeed = (float)currentShipSpeed + stateStrategy.WaveSpeed;
                    relativeWavelengthFactor = 1.0f;
                    break;
                case 45:
                    relativeSpeed = (float)currentShipSpeed + stateStrategy.WaveSpeed / 2;
                    relativeWavelengthFactor = 1.5f;
                    break;
                case 90:
                    relativeSpeed = (float)stateStrategy.WaveSpeed;
                    relativeWavelengthFactor = 1.0f;
                    break;
                default:
                    //default is set to 0 degrees, the same as case 0 
                    relativeSpeed = (float)currentShipSpeed + stateStrategy.WaveSpeed;
                    relativeWavelengthFactor = 1.0f;
                    break;
            }

        }

        private void populateHeaveArray()
        {
            if (currentSeaState != SeaState.SeaState0)
            {

                for (int i = 0; i < NUMBER_OF_WAVES; i++)
                {
                    // wavelength / relative speed will give time in seconds to travel one wavelength.
                    // if this is multiplied by the waveSampleFactor (30) it should approximate
                    // 30 fps

                    int samples = (int)(stateStrategy.Wavelength * relativeWavelengthFactor 
                        / relativeSpeed * waveSampleFactor);

                    for (int j = 0; j < samples; j++)
                    {
                        heaveValue = stateStrategy.WaveHeight * (float)Math.Sin(2 * Math.PI * j / samples);
                        heaveArray.Add(heaveValue);
                    }
                    // Record the number of samples for each random wave
                    samplesPerWaveList.Add(samples);
                }

                stateStrategy.newWaveStatistics();
            }
            else
            {
                heaveArray.Add(stateStrategy.WaveHeight);
            }
        }

        private void populatePitchArray()
        {
            if (currentSeaState != SeaState.SeaState0)
            {
                for (int i = 0; i < NUMBER_OF_WAVES; i++)
                {
                    
                    for (int j = 0; j < samplesPerWaveList[i]; j++)
                    {
                        if ((int)currentWaveDirection != 90)
                        {
                            nextPitchAngle = (stateStrategy.MaxPitch * relativeWavelengthFactor
                                * (float)Math.Sin(2 * Math.PI * j / samplesPerWaveList[i]));
                        }
                        else
                        {
                            nextPitchAngle = 0.0f;
                        }
                        pitchArray.Add(nextPitchAngle);
                    }
                    
                }
            }
            else
            {
                pitchArray.Add(stateStrategy.MaxPitch);
            }
        }

        private void populateRollArray()
        {

        }

	}
}
