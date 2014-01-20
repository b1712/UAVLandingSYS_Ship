using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


interface IMotion
{
    void calcutateRollAngle();
    void calculatePitchAngle();
    void calculateHeaveHeight();

    float RollAngle;
    float PitchAngle;
    float HeaveHeight;
}

