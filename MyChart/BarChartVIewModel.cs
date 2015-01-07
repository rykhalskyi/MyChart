using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace MyChart
{
    class BarChartVIewModel: BaseViewModel
    {

        private double _yScale = 1;
        
        private ObservableCollection<double> _bars = new ObservableCollection<double>();
        public ObservableCollection<double> Bars
        {
            get { return _bars; }
            set 
            {
                _bars = value;
                FireEvent("Bars");
            }
        }

        private double _width = 1;
        public double Width 
        {
            get { return _width; }
            set
            {
                _width = value;
                RecalculateScale();
            }
        }

        private double _height = 1;
        public double Height
        {
            get { return _height; } 
            set
            {
                _height = value;
                RecalculateScale();
            }
        }

        private double _barWidth;
        public double BarWidth
        {
            get { return _barWidth; }
            set
            {
                _barWidth = value;
                FireEvent("BarWidth");
                FireEvent("BarMargin");
            }
        }

        public Thickness BarMargin
        {
            get { return new Thickness(BarWidth / 2, 0, BarWidth / 2, 0); }
        }

         private void RecalculateScale()
        {
            var oldYScale = _yScale;
            _yScale =  _height / 100;

            BarWidth = (_width / 2) / Bars.Count;

            RefreshBarsValues(oldYScale);
        }

        
        private void RefreshBarsValues(double oldYScale)
        {
            var barHeaderPercentsDelta = (10 / _yScale) - (10 / oldYScale);

            for (int i=0; i<Bars.Count; i++)
            {
                _bars[i] = ((Bars[i]/oldYScale)-barHeaderPercentsDelta) * _yScale;
            }
        }

        public void AddBar(double barValue)
         {
             var barHeaderPercents = 10 / _yScale; 
             Bars.Add((barValue-barHeaderPercents)*_yScale);
             FireEvent("Bars");
         }
    }
}
