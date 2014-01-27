﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.BusinessLayer;

namespace Assets.ControlLayer
{

public class ShipModelController{

    ShipMotion shipMotion;

    public List<float> initialShipSetup(SeaState state, WaveDirection wind, ShipSpeed speed)
    {
        //will be returning an array of floats
        
        shipMotion = new ShipMotion(state, wind, speed);

        // float array = 
        //string message = 

        return shipMotion.calculateShipMotion();
    }
 
}

}
