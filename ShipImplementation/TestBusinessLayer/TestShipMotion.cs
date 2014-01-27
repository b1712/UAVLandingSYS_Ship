using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assets.BusinessLayer;
using System.Reflection;
//using Assets.PresentationLayer;

namespace TestBusinessLayer
{
    [TestClass]
    public class TestShipMotion
    {
        /// <summary>
        /// This test method uses reflection to invoke the private method calculateRelativeSpeed() and
        /// check the private field relativeSpeed is within expected limits.
        /// 
        /// Setup 1
        /// For SS6 in head on waves at max speed the relative speed should be between 20.0 and 24.1 m/s.
        /// 
        /// </summary>
        [TestMethod]
        public void TestCalculateRelativeSpeed_Setup1()
        {

            ShipMotion target = new ShipMotion(SeaState.SeaState6, WaveDirection.Zero_Degrees, ShipSpeed.Full);

            typeof(ShipMotion).GetMethod("calculateRelativeSpeed", 
                BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            float actual = (float)typeof(ShipMotion).GetField("relativeSpeed", 
                BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target);

            float expectedLow = 20.0f;
            float expectedHigh = 24.1f;

            Assert.IsTrue(actual > expectedLow);
            Assert.IsTrue(actual < expectedHigh);
        }


        /// <summary>
        /// This test method uses reflection to invoke the private method calculateRelativeSpeed() and
        /// check the private field relativeSpeed is within expected limits.
        /// Setup 2
        /// For SS3 in 45 degree waves at half speed the relative speed should be between 9.6 and 11.4 m/s.
        /// 
        /// </summary>
        [TestMethod]
        public void TestCalculateRelativeSpeed_Setup2()
        {

            ShipMotion target = new ShipMotion(SeaState.SeaState3, WaveDirection.FortyFive_Degrees, ShipSpeed.Half);

            typeof(ShipMotion).GetMethod("calculateRelativeSpeed",
                BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            float actual = (float)typeof(ShipMotion).GetField("relativeSpeed",
                BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target);

            float expectedLow = 9.6f;
            float expectedHigh = 11.4f;

            Assert.IsTrue(actual > expectedLow);
            Assert.IsTrue(actual < expectedHigh);
        }

        /// <summary>
        /// This test method uses reflection to invoke the private method calculateRelativeSpeed() and
        /// check the private field relativeSpeed is within expected limits.
        /// Setup 3
        /// For SS0 in no waves at zero speed the relative speed should be between 0 m/s.
        /// 
        /// </summary>
        [TestMethod]
        public void TestCalculateRelativeSpeed_Setup3()
        {

            ShipMotion target = new ShipMotion(SeaState.SeaState0, WaveDirection.Zero_Degrees, ShipSpeed.Stop);

            typeof(ShipMotion).GetMethod("calculateRelativeSpeed",
                BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            float actual = (float)typeof(ShipMotion).GetField("relativeSpeed",
                BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target);

            float expected = 0.0f;

            Assert.AreEqual(expected, actual);
        }
    }
}
