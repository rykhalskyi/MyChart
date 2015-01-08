using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyChart;
using System.Threading;

namespace ChartTest
{
    [TestClass]
    public class UnitTest1
    {
  
        [TestMethod]
        public void IsRightLength_ReturnsTrue()
        {
            //Asign
            int dataListLength = 50;
            int controlValue = 5;
            int timeInterval = 100;
            var dataProvider = new DataGeneratorStub(timeInterval, controlValue);
            var chart = new TChartViewModel(dataListLength);
            dataProvider.GetNewData += chart.RecieveAndShift;

            //Action
            dataProvider.Start();
            Thread.Sleep(timeInterval * dataListLength + 500);
            dataProvider.GetNewData -= chart.RecieveAndShift;
            //Assert
            Assert.AreEqual(chart.Points.Count, dataListLength + 2);
        }

        [TestMethod]
        public void HaveCorrectStartPoint_ReturnsTrue()
        {
            //Asign
            int dataListLength = 50;
            //Action
            var chart = new TChartViewModel(dataListLength);
            //Assert
            Assert.AreEqual(chart.Points[0].X, 0);
            Assert.AreEqual(chart.Points[1].X, 0);
        }

        [TestMethod]
        public void HaveCorrectEndPoint_ReturnsTrue()
        {
            //Asign
            int dataListLength = 50;
            //Action
            var chart = new TChartViewModel(dataListLength);
            chart.RecieveAndShift(30);
            //Assert
            Assert.AreEqual(chart.Points[dataListLength].X, chart.Points[dataListLength + 1].X);
        }

        [TestMethod]
        public void ChartPerformsShift_ReturnsTrue()
        {
            //Asign
            int dataListLength = 50;
            int controlValue = 5;
            int timeInterval = 100;
            var dataProvider = new DataGeneratorStub(timeInterval, controlValue);
            var chart = new TChartViewModel(dataListLength);
            dataProvider.GetNewData += chart.RecieveAndShift;

            //Action
            dataProvider.Start();
            Thread.Sleep(timeInterval * dataListLength+500);
            dataProvider.GetNewData -= chart.RecieveAndShift;
            //Assert
            bool isNotZero = true;
            for (int i=1; i<dataListLength; i++)
            {
                // chart.Point[0] - visual 0 on Y axis
                if (chart.Points[i].Y != chart.Points[0].Y - controlValue)
                { isNotZero = false; }
            }
            Assert.IsTrue(isNotZero);
            //start and end point Y are the same
            Assert.AreEqual(chart.Points[dataListLength + 1].Y, chart.Points[0].Y);
            //the last item X = X of the previous item
            Assert.AreEqual(chart.Points[dataListLength].X, chart.Points[dataListLength + 1].X);
        }

        [TestMethod]
        public void CorrectYScale_ReturnsTrue()
        { //Asign
            int dataListLength = 50;
            int newHeight = 30;
            //Action
            var chart = new TChartViewModel(dataListLength);
            chart.Height = newHeight;
            //Assert
            Assert.AreEqual(chart.Points[0].Y, newHeight);
            Assert.AreEqual(chart.Points[dataListLength + 1].Y, chart.Points[0].Y);
            //the last item X = X of the previous item
            Assert.AreEqual(chart.Points[dataListLength].X, chart.Points[dataListLength + 1].X);
        }
        
        [TestMethod]
        public void CorrectXScale_ReturnsTrue()
        {
            //Asign
            int dataListLength = 50;
            int newWidth = 30;
            //Action
            var chart = new TChartViewModel(dataListLength);
            chart.Width = newWidth;
            //Assert
            var measuredDelta = chart.Points[2].X - chart.Points[1].X;
            var expectedDelta = (double)newWidth / (double)(dataListLength -1);
            Assert.AreEqual(measuredDelta, expectedDelta);
        }

        [TestMethod]
        public void CorrectUpperLimit_Returns_True()
        {
            //Assign
            int dataListLength = 40;
            int upperLimit = 200;
            int controlValue = 150;
            int timeInterval = 100;
            var dataProvider = new DataGeneratorStub(timeInterval, controlValue);
            var chart = new TChartViewModel(dataListLength);
            chart.UpperLimit = upperLimit;
            dataProvider.GetNewData += chart.RecieveAndShift;

            //Action
            dataProvider.Start();
            Thread.Sleep(timeInterval * dataListLength + 500);
            dataProvider.GetNewData -= chart.RecieveAndShift;

            //Assert
            double expectedValue = 100 - (100 * controlValue / upperLimit);
            Assert.AreEqual(chart.Points[1].Y, expectedValue);
        }
    }
}
