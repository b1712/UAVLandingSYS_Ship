using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


interface IMotion
{
    void calcutateRollAngle();
    void calculatePitchAngle();
    void calculateHeaveHeight();

    float RollAngle
    {
        get;
        set;
    }

    float PitchAngle
    {
        get;
        set;
    }

    float HeaveHeight
    {
        get;
        set;
    }
}

