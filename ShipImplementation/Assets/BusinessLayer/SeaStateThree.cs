using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.BusinessLayer
{
	public class SeaStateThree : IState
    {
        #region fields

        private readonly float MIN_HEIGHT = 0.5f;
        private readonly float MAX_HEIGHT = 1.25f;
        private readonly float MIN_LENGTH = 50.0f;
        private readonly float MAX_LENGTH = 100.0f;
        private readonly float MIN_WAVESPEED = 3.3f;
        private readonly float MAX_WAVESPEED = 6.7f;
        private readonly float MAX_PITCH_ANGLE = 0.53f;

        private float waveHeight;
        private float wavelength;
        private float waveFrequency;

        #endregion

        #region Properties

        public float WaveHeight
        {
            get { return waveHeight; }
            set { waveHeight = value; }
        }

        public float Wavelength
        {
            get { return wavelength; }
            set { wavelength = value; }
        }

        public float WaveSpeed
        {
            get { return waveFrequency; }
            set { waveFrequency = value; }
        }

        public float MaxPitch
        {
            get { return MAX_PITCH_ANGLE; }
        }

        #endregion


        public void newWaveStatistics()
        {
            waveHeight = selectFromRange(MIN_HEIGHT, MAX_HEIGHT);
            wavelength = selectFromRange(MIN_LENGTH, MAX_LENGTH);
            waveFrequency = selectFromRange(MIN_WAVESPEED, MAX_WAVESPEED);
        }


        public float selectFromRange(float min, float max)
        {
            Random radom = new Random();
            float randomNumberFromRange = (float)(radom.NextDouble() * (max - min) + min);

            return randomNumberFromRange;
        }
    }
}
