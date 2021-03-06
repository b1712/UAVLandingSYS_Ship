﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.BusinessLayer
{
    public class SeaStateZero : IState
    {
        #region fields

        private readonly float HEIGHT = 0.0f;
        private readonly float LENGTH = 0.0f;
        private readonly float FREQUENCY = 0.0f;
        private readonly float MAX_PITCH_ANGLE = 0.0f;
        private readonly float MAX_ROLL_ANGLE = 0.0f;

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

        public float MaxRoll
        {
            get { return MAX_ROLL_ANGLE; }
        }

        #endregion


        public void newWaveStatistics()
        {
            waveHeight = HEIGHT;
            wavelength = LENGTH;
            waveFrequency = FREQUENCY;
        }

    }
}
