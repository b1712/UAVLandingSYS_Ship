using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assets.BusinessLayer;

namespace TestBusinessLayer
{
    [TestClass]
    public class TestSeaStateZero
    {
        SeaStateZero target = new SeaStateZero();

        /// <summary>
        /// This test is to check the newWaveStatistics() method and returns the data for wave height, 
        /// wavelength and wave frequency for Sea State 0 all of which should be zero. 
        /// </summary>

        [TestMethod]
        public void TestNewWaveStatistics_S_S_Zero()
        {
            target.newWaveStatistics();

            float actualWaveHeight = target.WaveHeight;
            float actualWavelength = target.Wavelength;
            float actualSpeed = target.WaveSpeed;

            float expectedHeight = 0.0f;
            float expectedWavelength = 0.0f;
            float expectedSpeed = 0.0f;

            Assert.AreEqual(expectedHeight, actualWaveHeight);
            Assert.AreEqual(expectedWavelength, actualWavelength);
            Assert.AreEqual(expectedSpeed, actualSpeed);

        }
    }
}
