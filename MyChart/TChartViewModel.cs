using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace MyChart
{
    public class TChartViewModel : INotifyPropertyChanged
    {

        #region Private

        private const double _internalYRange = 100;
        private double _upperLimit = 100;

        private double _xScale = 10;
        private int _intervals = 25;
        private double _yCoeff = 1;

        bool isScaling = false;

        #endregion

        #region PublicProperties

        public int Intervals
        {
            get { return _intervals; }
            private set { _intervals = value; }
        }

        private ObservableCollection<Point> _points = new ObservableCollection<Point>();
        public ObservableCollection<Point> Points
        {
            get { return _points; }
            set { _points = value; }
        }

        private double _width = 0;
        public double Width
        {
            get { return _width; }
            set
            {
                if (_width != value)
                {
                    _width = value;
                    RecalculateScale();
                }
            }
        }

        private double _height = 0;
        public double Height
        {
            get { return _height; }
            set
            {
                if ((int)_height != (int)value)
                {
                    _height = value;
                    RecalculateScale();
                }
            }
        }

        public bool AutoScale { get; set; }
        public double UpperLimit
        {
            get { return _upperLimit; }
            set { _upperLimit = value; }
        }

        private ObservableCollection<double> _axisCaption = new ObservableCollection<double>();
        public ObservableCollection<double> AxisCaption
        {
            get { return _axisCaption; }
        }

        #endregion

        public TChartViewModel(int intervals)
        {
            Intervals = intervals;
            _width = _xScale * _intervals;
            _height = _internalYRange;
            Initialize();
        }

        private void Initialize()
        {
            //start and end values used for correct fill
            Points.Add(new Point(0, PrepareData(0))); //start value
            for (int i = 0; i < Intervals; i++)
            {
                Points.Add(new Point(i * _xScale, PrepareData(0)));
            }
            Points.Add(new Point((Intervals - 1) * _xScale, PrepareData(0))); //end value

            for (int i=0; i<10; i++)
            {
                _axisCaption.Add((i+1) * UpperLimit / 10);
            }
        }

        public void RecieveAndShift(int newValue)
        {
            if (!isScaling)
            {
                for (int i = 1; i < Intervals; i++)
                {
                    _points[i] = new Point((i - 1) * _xScale, _points[i + 1].Y);
                }
                _points[Intervals] = new Point((Intervals - 1) * _xScale, PrepareData(newValue));
                InvokePropertyChanged("Points");
            }
        }

        private double PrepareData(double data)
        {
            if (AutoScale)
            {
                CalculateUpperLimit(data);
            }

            var normalizedData = _internalYRange * data / _upperLimit;
            return (_internalYRange - normalizedData) * _yCoeff;
        }

        private void CalculateUpperLimit(double data)
        {
            if (data > UpperLimit)
            { 
                var changeLimitCoeff = data / UpperLimit;

                UpperLimit = data;  
            
                for (int i=1; i<_points.Count -1; i++)
                {
                    _points[i] = new Point(_points[i].X, _points[i].Y * changeLimitCoeff);
                }

                for (int i = 0; i < 10; i++ )
                {
                    _axisCaption[i] = (i+1) * UpperLimit / 10;
                }

                    InvokePropertyChanged("Points");
                    InvokePropertyChanged("AxesCaption");
            }
        }

        private void RecalculateScale()
        {
            _yCoeff = _height / _internalYRange;
            _xScale = _width / (_intervals - 1);

            double changeCoeff = _height / _points[0].Y;
            CorrectChart(changeCoeff);
        }

        private void CorrectChart(double changeCoeff)
        {
            isScaling = true;

            CorrectFirstPoint(changeCoeff);
            CorrectPoints(changeCoeff);
            CorrectLastPoint(changeCoeff);

            InvokePropertyChanged("Points");
            isScaling = false;
        }

        private void CorrectFirstPoint(double changeCoeff)
        {
            var visualZero = _points[0].Y * changeCoeff;
            _points[0] = new Point(0, visualZero);
        }

        private void CorrectPoints(double changeCoeff)
        {
            for (int i = 1; i < _points.Count - 1; i++)
            {
                var Y = _points[i].Y;
                _points[i] = new Point((i - 1) * _xScale, Y * changeCoeff);
            }
        }

        private void CorrectLastPoint(double changeCoeff)
        {
            var visualZero = _points[_points.Count - 1].Y * changeCoeff;
            _points[_points.Count - 1] = new Point((Intervals - 1) * _xScale, visualZero);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void InvokePropertyChanged(string param)
        {
            if (param != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(param));

            }
        }
    }
}
