using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class InitialShipMotion : IMotion
{
    #region fields

    private float rollAngle;
    private float pitchAngle;
    private float heaveHeight;
    private int seaState;
    private float waveFrequency;

    #endregion

    #region Properties

    public float RollAngle
    {
        get { return rollAngle; }
        set { rollAngle = value; }
    }

    public float PitchAngle
    {
        get { return pitchAngle; }
        set { pitchAngle = value; }
    }

    public float HeaveHeight
    {
        get { return heaveHeight; }
        set { heaveHeight = value; }
    }

    #endregion

    #region Constructor

    public InitialShipMotion(int seaState, float waveFrequency)
    {
        this.seaState = seaState;
        this.waveFrequency = waveFrequency;
    }

    #endregion

    public void calcutateRollAngle()
    {
        throw new NotImplementedException();
    }

    public void calculatePitchAngle()
    {
        throw new NotImplementedException();
    }

    public void calculateHeaveHeight()
    {
        throw new NotImplementedException();
    }
}

