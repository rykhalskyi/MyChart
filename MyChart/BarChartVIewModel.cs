using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace MyChart
{
    public class BarChartViewModel: BaseViewModel
    {

        private double _yScale = 1;
        private const int barHeaderHeight = 10;
        
        private ObservableCollection<Bar> _bars = new ObservableCollection<Bar>();
        public ObservableCollection<Bar> Bars
        {
            get { return _bars; }
            set 
            {
                _bars = value;
                FireEvent("Bars");
            }
        }

        private double _width;
        public double Width 
        {
            get { return _width; }
            set
            {
                _width = value;
                RecalculateScale();
            }
        }

        private double _height;
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

        private ObservableCollection<string> _xLegend = new ObservableCollection<string>();
        public ObservableCollection<string> XLegend
        {
            get {return _xLegend;}
        }


        public Thickness BarMargin
        {
            get { return new Thickness(BarWidth / 4, 0, BarWidth / 4, 0); }
        }

         private void RecalculateScale()
        {
            var oldYScale = _yScale;
            _yScale =  _height / 100;

            BarWidth = (_width / 1.5) / Bars.Count;

            RefreshBarsValues(oldYScale);
        }

        
        private void RefreshBarsValues(double oldYScale)
        {
            var barHeaderPercentsDelta = (barHeaderHeight / _yScale) - (barHeaderHeight / oldYScale);

            for (int i=0; i<Bars.Count; i++)
            {
                _bars[i].Value = ((Bars[i].Value/oldYScale)-barHeaderPercentsDelta) * _yScale;
            }
        }

        public void AddBar(double barValue, string legend, bool isSelected = false)
         {
             var barHeaderPercents = barHeaderHeight / _yScale;
             Bars.Add(new Bar() { Value = (barValue - barHeaderPercents) * _yScale, IsSelected = isSelected });
             XLegend.Add(legend);
             FireEvent("Bars");
             FireEvent("XLegend");
         }
    }
}
