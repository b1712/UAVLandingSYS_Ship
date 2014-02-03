using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assets.BusinessLayer;

namespace TestBusinessLayer
{
    [TestClass]
    public class TestSeaStateThree
    {
        SeaStateThree target = new SeaStateThree();

        /// <summary>
        /// This test is to check that a randomly generated wave height is within the range for Sea State 3
        ///  which is low = 0.5 metres and high = 1.25 metres.
        /// </summary>

        [TestMethod]
        public void TestSelectRangeForHeight_S_S_Three()
        {
            float actual = target.selectFromRange(0.5f, 1.25f);
            float expectedLow = 0.5f;
            float expectedHigh = 1.25f;

            Assert.IsTrue(actual > expectedLow);
            Assert.IsTrue(actual < expectedHigh);
        }


        /// <summary>
        /// This test is to check that a randomly generated wavelength is within the range for Sea State 3
        ///  which is between 50 and 100 metres.
        /// </summary>

        [TestMethod]
        public void TestSelectRangeForWavelength_S_S_Three()
        {
            float actual = target.selectFromRange(50.0f, 100.0f);
            float expectedLow = 50.0f;
            float expectedHigh = 100.0f;

            Assert.IsTrue(actual > expectedLow);
            Assert.IsTrue(actual < expectedHigh);
        }


        /// <summary>
        /// This test is to check that a randomly generated wave speed is within the range for Sea State 3
        ///  which is between 3.3 and 6.7 m/s.
        /// </summary>

        [TestMethod]
        public void TestSelectRangeForWaveSpeed_S_S_Three()
        {
            float actual = target.selectFromRange(3.3f, 6.7f);
            float expectedLow = 3.3f;
            float expectedHigh = 6.7f;

            Assert.IsTrue(actual > expectedLow);
            Assert.IsTrue(actual < expectedHigh);
        }


        /// <summary>
        /// This test is to check the newWaveStatistics() method which calls the selectFromRange() method
        /// 3 times once each to generate random data for wave height, wavelength and wave speed. All this 
        /// data is tested to ensure it is between limits for Sea State 3
        /// </summary>

        [TestMethod]
        public void TestNewWaveStatistics_S_S_Three()
        {
            target.newWaveStatistics();

            float actualWaveHeight = target.WaveHeight;
            float actualWavelength = target.Wavelength;
            float actualSpeed = target.WaveSpeed;

            float expectedWaveHeightLow = 0.5f;
            float expectedWaveHeightHigh = 1.25f;

            float expectedWavelengthtLow = 50.0f;
            float expectedWavelengthHigh = 100.0f;

            float expectedSpeedLow = 3.3f;
            float expectedSpeedHigh = 6.7f;

            Assert.IsTrue(actualWaveHeight > expectedWaveHeightLow);
            Assert.IsTrue(actualWaveHeight < expectedWaveHeightHigh);

            Assert.IsTrue(actualWavelength > expectedWavelengthtLow);
            Assert.IsTrue(actualWavelength < expectedWavelengthHigh);

            Assert.IsTrue(actualSpeed > expectedSpeedLow);
            Assert.IsTrue(actualSpeed < expectedSpeedHigh);
        }
    }
}
