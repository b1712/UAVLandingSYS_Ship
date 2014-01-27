using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assets.BusinessLayer;

namespace TestBusinessLayer
{
    [TestClass]
    public class TestSeaStateSix
    {
        SeaStateSix target = new SeaStateSix();
        
        /// <summary>
        /// This test is to check that a randomly generated wave height is within the range for Sea State 6
        ///  which is low = 4 metres and high = 6 metres.
        /// </summary>
        
        [TestMethod]
        public void TestSelectRangeForHeight_S_S_Six()
        {
            float actual = target.selectFromRange(4.0f, 6.0f);
            //Console.WriteLine(target.ToString());
            float expectedLow = 4.0f;
            float expectedHigh = 6.0f;

            Assert.IsTrue(actual > expectedLow);
            Assert.IsTrue(actual < expectedHigh);
        }


        /// <summary>
        /// This test is to check that a randomly generated wavelength is within the range for Sea State 6
        ///  which is between 50 and 100 metres.
        /// </summary>

        [TestMethod]
        public void TestSelectRangeForWavelength_S_S_Six()
        {
            float actual = target.selectFromRange(50.0f, 100.0f);
            float expectedLow = 50.0f;
            float expectedHigh = 100.0f;

            Assert.IsTrue(actual > expectedLow);
            Assert.IsTrue(actual < expectedHigh);
        }


        /// <summary>
        /// This test is to check that a randomly generated wave speed is within the range for Sea State 6
        ///  which is between 4.0 and 8.1 m/s.
        /// </summary>

        [TestMethod]
        public void TestSelectRangeForWaveSpeed_S_S_Six()
        {
            float actual = target.selectFromRange(4.0f, 8.1f);
            float expectedLow = 4.0f;
            float expectedHigh = 8.1f;

            Assert.IsTrue(actual > expectedLow);
            Assert.IsTrue(actual < expectedHigh);
        }


        /// <summary>
        /// This test is to check the newWaveStatistics() method which calls the selectFromRange() method
        /// 3 time once each to generate random data for wave height, wavelength and wave speed. All this 
        /// data is tested to ensure it is between limits for Sea State 6
        /// </summary>

        [TestMethod]
        public void TestNewWaveStatistics_S_S_Six()
        {
            target.newWaveStatistics();

            float actualWaveHeight = target.WaveHeight;
            float actualWavelength = target.Wavelength;
            float actualSpeed = target.WaveSpeed;

            float expectedWaveHeightLow = 4.0f;
            float expectedWaveHeightHigh = 6.0f;

            float expectedWavelengthtLow = 50.0f;
            float expectedWavelengthHigh = 100.0f;

            float expectedSpeedLow = 4.0f;
            float expectedSpeedHigh = 8.1f;

            Assert.IsTrue(actualWaveHeight > expectedWaveHeightLow);
            Assert.IsTrue(actualWaveHeight < expectedWaveHeightHigh);

            Assert.IsTrue(actualWavelength > expectedWavelengthtLow);
            Assert.IsTrue(actualWavelength < expectedWavelengthHigh);

            Assert.IsTrue(actualSpeed > expectedSpeedLow);
            Assert.IsTrue(actualSpeed < expectedSpeedHigh);
        }
    }
}
