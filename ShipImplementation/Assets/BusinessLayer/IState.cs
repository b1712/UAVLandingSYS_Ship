using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.BusinessLayer
{
	interface IState
	{
        
        float WaveHeight
        {
            get;
            set;
        }

        float Wavelength
        {
            get;
            set;
        }

        float WaveSpeed
        {
            get;
            set;
        }

        float MaxPitch
        {
            get;
        }

        float MaxRoll
        {
            get;
        }

        void newWaveStatistics();
	}
}
