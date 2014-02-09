using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.BusinessLayer;
using Assets.ServiceLayer;

namespace Assets.ControlLayer
{

public class ShipModelController{

    ShipMotion shipMotion;
    UDPConnectionShipCoordinates connectionUAV;

    public List<List<float>> initialShipSetup(SeaState state, WaveDirection wind, ShipSpeed speed)
    {
        //will be returning an array of floats
        
        shipMotion = new ShipMotion(state, wind, speed);

        // float array = 
        //string message = 

        return shipMotion.calculateShipMotion();

        

    }

    public void postShipCoordinates(float[] coordinates)
    {
        connectionUAV = new UDPConnectionShipCoordinates();
        connectionUAV.postShipCoordinates(coordinates);
    }
 
}

}
