using System.Collections.Generic;
using Assets.BusinessLayer;
using Assets.ServiceLayer;

namespace Assets.ControlLayer
{
    public class ShipModelController
    {
        private ShipMotion _shipMotion;
        private UdpConnectionShipCoordinates _connectionUav;

        public List<List<float>> InitialShipSetup(SeaState state, WaveDirection wind, ShipSpeed speed)
        {
            _shipMotion = new ShipMotion(state, wind, speed);

            return _shipMotion.calculateShipMotion();
        }

        public void PostShipCoordinates(float[] coordinates)
        {
            _connectionUav = new UdpConnectionShipCoordinates();
            _connectionUav.PostShipCoordinates(coordinates);
        }
    }

}
