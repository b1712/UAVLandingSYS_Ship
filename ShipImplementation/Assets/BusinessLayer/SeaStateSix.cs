using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.BusinessLayer
{
	public class SeaStateSix : IState
    {
        #region fields

        private readonly float MIN_HEIGHT = 4.0f;
        private readonly float MAX_HEIGHT = 6.0f;
        private readonly float MIN_LENGTH = 50.0f;
        private readonly float MAX_LENGTH = 100.0f;
        private readonly float MIN_WAVESPEED = 4.0f;
        private readonly float MAX_WAVESPEED = 8.1f;

        private float waveHeight;
        private float wavelength;
        private float waveSpeed;

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
            get { return waveSpeed; }
            set { waveSpeed = value; }
        }

        #endregion


        public void newWaveStatistics()
        {
            waveHeight = selectFromRange(MIN_HEIGHT, MAX_HEIGHT);
            wavelength = selectFromRange(MIN_LENGTH, MAX_LENGTH);
            waveSpeed = selectFromRange(MIN_WAVESPEED, MAX_WAVESPEED);
        }


        public float selectFromRange(float min, float max)
        {
            Random radom = new Random();
            float randomNumberFromRange = (float)(radom.NextDouble() * (max - min) + min);

            return randomNumberFromRange;
        }
    }
}
