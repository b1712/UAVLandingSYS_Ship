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
        /// Setup A_1
        /// For SS6 in head on waves at max speed the relative speed should be between 20.0 and 24.1 m/s.
        /// 
        /// </summary>
        [TestMethod]
        public void TestCalculateRelativeSpeed_Setup1()
        {

            ShipMotion target = new ShipMotion(SeaState.SeaState6, WaveDirection.Zero_Degrees, ShipSpeed.Full);

            //typeof(ShipMotion).GetMethod("calculateRelativeValues", 
            //    BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);
            
            float actual = (float)typeof(ShipMotion).GetField("relativeSpeed", 
                BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target);

            float expectedLow = 20.0f;
            float expectedHigh = 24.1f;

            Assert.IsTrue(actual >= expectedLow);
            Assert.IsTrue(actual <= expectedHigh);
        }


        /// <summary>
        /// This test method uses reflection to invoke the private method calculateRelativeSpeed() and
        /// check the private field relativeSpeed is within expected limits.
        /// Setup A_2
        /// For SS3 in 45 degree waves at half speed the relative speed should be between 9.6 and 11.4 m/s.
        /// 
        /// </summary>
        [TestMethod]
        public void TestCalculateRelativeSpeed_Setup2()
        {

            ShipMotion target = new ShipMotion(SeaState.SeaState3, WaveDirection.FortyFive_Degrees, ShipSpeed.Half);

            typeof(ShipMotion).GetMethod("calculateRelativeValues",
                BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            float actual = (float)typeof(ShipMotion).GetField("relativeSpeed",
                BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target);

            float expectedLow = 9.6f;
            float expectedHigh = 11.4f;

            Assert.IsTrue(actual >= expectedLow);
            Assert.IsTrue(actual <= expectedHigh);
        }

        /// <summary>
        /// This test method uses reflection to invoke the private method calculateRelativeSpeed() and
        /// check the private field relativeSpeed is within expected limits.
        /// Setup A_3
        /// For SS0 in no waves at zero speed the relative speed should be between 0 m/s.
        /// 
        /// </summary>
        [TestMethod]
        public void TestCalculateRelativeSpeed_Setup3()
        {

            ShipMotion target = new ShipMotion(SeaState.SeaState0, WaveDirection.Zero_Degrees, ShipSpeed.Stop);

            typeof(ShipMotion).GetMethod("calculateRelativeValues",
                BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            float actual = (float)typeof(ShipMotion).GetField("relativeSpeed",
                BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target);

            float expected = 0.0f;

            Assert.AreEqual(expected, actual);
        }

        

        /// <summary>
        /// This test method uses reflection to invoke the private method populateHeaveArray() and
        /// check the private collection heaveArray is within expected limits.
        /// Setup B_1
        /// For SS6 in head on waves at max speed the maximum wave amplitude should be less than 6.0 m.
        /// 
        /// </summary>
        [TestMethod]
        public void TestPopulateHeaveArray_S_S_6()
        {

            ShipMotion target = new ShipMotion(SeaState.SeaState6, WaveDirection.Zero_Degrees, ShipSpeed.Full);
            float actualMax = float.MinValue;
            float actualMin = float.MaxValue;


            typeof(ShipMotion).GetMethod("populateHeaveArray",
                BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            IList<float> heaveArray = typeof(ShipMotion).GetField("heaveArray",
               BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target) as IList<float>;

            foreach (float value in heaveArray)
            {
                if (value > actualMax)
                {
                    actualMax = value;
                }
                if (value < actualMin)
                {
                    actualMin = value;
                }
            }

            // As the wave is sinusoidal the max and min values are an equal distance from 0 in the positive and 
            // negative directions.

            float expectedMax = 6.0f;
            float expectedMin = -6.0f;

            Assert.IsTrue(expectedMax >= actualMax);
            Assert.IsTrue(expectedMin <= actualMin);

        }


        /// <summary>
        /// This test method uses reflection to invoke the private method populateHeaveArray() and
        /// check the private collection heaveArray is within expected limits.
        /// Setup B_2
        /// For SS3 in head on waves at max speed the maximum wave amplitude should be less than 1.25 m.
        /// 
        /// </summary>
        [TestMethod]
        public void TestPopulateHeaveArray_S_S_3()
        {

            ShipMotion target = new ShipMotion(SeaState.SeaState3, WaveDirection.Zero_Degrees, ShipSpeed.Full);
            float actualMax = float.MinValue;
            float actualMin = float.MaxValue;


            typeof(ShipMotion).GetMethod("populateHeaveArray",
                BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            IList<float> heaveArray = typeof(ShipMotion).GetField("heaveArray",
               BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target) as IList<float>;

            foreach (float value in heaveArray)
            {
                if (value > actualMax)
                {
                    actualMax = value;
                }
                if (value < actualMin)
                {
                    actualMin = value;
                }
            }

            // As the wave is sinusoidal the max and min values are an equal distance from 0 in the positive and 
            // negative directions.

            float expectedMax = 1.25f;
            float expectedMin = -1.25f;

            Assert.IsTrue(expectedMax >= actualMax);
            Assert.IsTrue(expectedMin <= actualMin);

        }


        /// <summary>
        /// This test method uses reflection to invoke the private method populateHeaveArray() and
        /// check the private collection heaveArray is within expected limits.
        /// Setup B_3
        /// For SS0 in head on waves at max speed there are no waves so the amplitude is 0.
        /// 
        /// </summary>
        [TestMethod]
        public void TestPopulateHeaveArray_S_S_0()
        {

            ShipMotion target = new ShipMotion(SeaState.SeaState0, WaveDirection.Zero_Degrees, ShipSpeed.Full);
            float actualMax = float.MinValue;
            float actualMin = float.MaxValue;


            typeof(ShipMotion).GetMethod("populateHeaveArray",
                BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            IList<float> heaveArray = typeof(ShipMotion).GetField("heaveArray",
               BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target) as IList<float>;

            foreach (float value in heaveArray)
            {
                if (value > actualMax)
                {
                    actualMax = value;
                }
                if (value < actualMin)
                {
                    actualMin = value;
                }
            }

            // As the wave is sinusoidal the max and min values are an equal distance from 0 in the positive and 
            // negative directions.

            float expectedMax = 0.0f;
            float expectedMin = 0.0f;

            Assert.AreEqual(expectedMax, actualMax);
            Assert.AreEqual(expectedMin, actualMin);

        }


        /// <summary>
        /// This test method uses reflection to invoke the private method populatePitchArray() and
        /// check the private collection heaveArray is within expected limits.
        /// Setup C_1
        /// For SS6 in head on waves at max speed, the maximum pitch angle is +/- 3.0 degrees.
        /// 
        /// </summary>
        [TestMethod]
        public void TestPopulatePitchArray_S_S_6()
        {

            ShipMotion target = new ShipMotion(SeaState.SeaState6, WaveDirection.Zero_Degrees, ShipSpeed.Full);
            float actualMax = float.MinValue;
            float actualMin = float.MaxValue;

            // There is a dependence on data generated from the populateHeaveArray so it must
            // be invoked first.
            typeof(ShipMotion).GetMethod("populateHeaveArray",
                BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            typeof(ShipMotion).GetMethod("populatePitchArray",
                BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            IList<float> pitchArray = typeof(ShipMotion).GetField("pitchArray",
               BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target) as IList<float>;

            foreach (float value in pitchArray)
            {
                if (value > actualMax)
                {
                    actualMax = value;
                }
                if (value < actualMin)
                {
                    actualMin = value;
                }
            }

            // As the wave is sinusoidal the max and min values are an equal distance from 0 in the positive and 
            // negative directions.

            float expectedMax = 3.0f;
            float expectedMin = -3.0f;

            Assert.IsTrue(expectedMax >= actualMax);
            Assert.IsTrue(expectedMin <= actualMin);

        }


        /// <summary>
        /// This test method uses reflection to invoke the private method populatePitchArray() and
        /// check the private collection heaveArray is within expected limits.
        /// Setup C_2
        /// For SS3 in head on waves at max speed, the maximum pitch angle is +/- 0.53 degrees.
        /// 
        /// </summary>
        [TestMethod]
        public void TestPopulatePitchArray_S_S_3()
        {

            ShipMotion target = new ShipMotion(SeaState.SeaState3, WaveDirection.Zero_Degrees, ShipSpeed.Full);
            float actualMax = float.MinValue;
            float actualMin = float.MaxValue;

            // There is a dependence on data generated from the populateHeaveArray so it must
            // be invoked first.
            typeof(ShipMotion).GetMethod("populateHeaveArray",
                BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            typeof(ShipMotion).GetMethod("populatePitchArray",
                BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            IList<float> pitchArray = typeof(ShipMotion).GetField("pitchArray",
               BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target) as IList<float>;

            foreach (float value in pitchArray)
            {
                if (value > actualMax)
                {
                    actualMax = value;
                }
                if (value < actualMin)
                {
                    actualMin = value;
                }
            }

            // As the wave is sinusoidal the max and min values are an equal distance from 0 in the positive and 
            // negative directions.

            float expectedMax = 0.53f;
            float expectedMin = -0.53f;

            Assert.IsTrue(expectedMax >= actualMax);
            Assert.IsTrue(expectedMin <= actualMin);

        }


        /// <summary>
        /// This test method uses reflection to invoke the private method populatePitchArray() and
        /// check the private collection heaveArray is within expected limits.
        /// Setup C_3
        /// For SS0 in to 90 degree waves at max speed, there are no waves so the pitch angle is 0.
        /// 
        /// </summary>
        [TestMethod]
        public void TestPopulatePitchArray_S_S_0()
        {

            ShipMotion target = new ShipMotion(SeaState.SeaState0, WaveDirection.Ninety_Degrees, ShipSpeed.Full);
            float actualMax = float.MinValue;
            float actualMin = float.MaxValue;


            typeof(ShipMotion).GetMethod("populatePitchArray",
                BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            IList<float> pitchArray = typeof(ShipMotion).GetField("pitchArray",
               BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target) as IList<float>;

            foreach (float value in pitchArray)
            {
                if (value > actualMax)
                {
                    actualMax = value;
                }
                if (value < actualMin)
                {
                    actualMin = value;
                }
            }

            // As the wave is sinusoidal the max and min values are an equal distance from 0 in the positive and 
            // negative directions.

            float expectedMax = 0.0f;
            float expectedMin = 0.0f;

            Assert.AreEqual(expectedMax, actualMax);
            Assert.AreEqual(expectedMin, actualMin);

        }


        /// <summary>
        /// This test method uses reflection to invoke the private method populateRollArray() and
        /// check the private collection heaveArray is within expected limits.
        /// Setup D_1
        /// For SS6 in 90 degree waves at max speed, the maximum roll angle is +/- 16.0 degrees.
        /// 
        /// </summary>
        [TestMethod]
        public void TestPopulateRollArray_S_S_6()
        {

            ShipMotion target = new ShipMotion(SeaState.SeaState6, WaveDirection.Ninety_Degrees, ShipSpeed.Full);
            float actualMax = float.MinValue;
            float actualMin = float.MaxValue;

            // There is a dependence on data generated from the populateHeaveArray so it must
            // be invoked first.
            typeof(ShipMotion).GetMethod("populateHeaveArray",
                BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            typeof(ShipMotion).GetMethod("populateRollArray",
                BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            IList<float> rollArray = typeof(ShipMotion).GetField("rollArray",
               BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target) as IList<float>;

            foreach (float value in rollArray)
            {
                if (value > actualMax)
                {
                    actualMax = value;
                }
                if (value < actualMin)
                {
                    actualMin = value;
                }
            }

            // As the wave is sinusoidal the max and min values are an equal distance from 0 in the positive and 
            // negative directions.

            float expectedMax = 16.0f;
            float expectedMin = -16.0f;

            Assert.IsTrue(expectedMax >= actualMax);
            Assert.IsTrue(expectedMin <= actualMin);

        }


        /// <summary>
        /// This test method uses reflection to invoke the private method populateRollArray() and
        /// check the private collection heaveArray is within expected limits.
        /// Setup D_2
        /// For SS3 in 90 degree waves at max speed, the maximum roll angle is +/- 8.0 degrees.
        /// 
        /// </summary>
        [TestMethod]
        public void TestPopulateRollArray_S_S_3()
        {

            ShipMotion target = new ShipMotion(SeaState.SeaState3, WaveDirection.Ninety_Degrees, ShipSpeed.Full);
            float actualMax = float.MinValue;
            float actualMin = float.MaxValue;

            // There is a dependence on data generated from the populateHeaveArray so it must
            // be invoked first.
            typeof(ShipMotion).GetMethod("populateHeaveArray",
                BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            typeof(ShipMotion).GetMethod("populateRollArray",
                BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            IList<float> rollArray = typeof(ShipMotion).GetField("rollArray",
               BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target) as IList<float>;

            foreach (float value in rollArray)
            {
                if (value > actualMax)
                {
                    actualMax = value;
                }
                if (value < actualMin)
                {
                    actualMin = value;
                }
            }

            // As the wave is sinusoidal the max and min values are an equal distance from 0 in the positive and 
            // negative directions.

            float expectedMax = 8.0f;
            float expectedMin = -8.0f;

            Assert.IsTrue(expectedMax >= actualMax);
            Assert.IsTrue(expectedMin <= actualMin);

        }


        /// <summary>
        /// This test method uses reflection to invoke the private method populateRollArray() and
        /// check the private collection heaveArray is within expected limits.
        /// Setup D_3
        /// For SS0 in 90 degree waves at max speed, there are no waves so the roll angle is 0.
        /// 
        /// </summary>
        [TestMethod]
        public void TestPopulateRollArray_S_S_0()
        {

            ShipMotion target = new ShipMotion(SeaState.SeaState0, WaveDirection.Ninety_Degrees, ShipSpeed.Full);
            float actualMax = float.MinValue;
            float actualMin = float.MaxValue;

            // There is a dependence on data generated from the populateHeaveArray so it must
            // be invoked first.
            typeof(ShipMotion).GetMethod("populateHeaveArray",
                BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            typeof(ShipMotion).GetMethod("populateRollArray",
                BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            IList<float> rollArray = typeof(ShipMotion).GetField("rollArray",
               BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target) as IList<float>;

            foreach (float value in rollArray)
            {
                if (value > actualMax)
                {
                    actualMax = value;
                }
                if (value < actualMin)
                {
                    actualMin = value;
                }
            }

            // As the wave is sinusoidal the max and min values are an equal distance from 0 in the positive and 
            // negative directions.

            float expectedMax = 0.0f;
            float expectedMin = 0.0f;

            Assert.AreEqual(expectedMax, actualMax);
            Assert.AreEqual(expectedMin, actualMin);

        }
    }
}
