using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyChart;

namespace ChartTest
{
    [TestClass]
    public class BarChartTest
    {
        [TestMethod]
        public void BarWidsIsCorrect_ReturnsTrue()
        {
            //Assert
            var chart = new BarChartViewModel();
            int width = 200;
            int barCount = 5;

            //Action
            
            for (int i=0; i<barCount; i++)
            {
                chart.AddBar(20);
            }
            chart.Width = width;

            //Assert
            var expectedWidth = ((width / 2) / barCount);
            Assert.AreEqual(chart.BarWidth, expectedWidth);
        }
    }
}
