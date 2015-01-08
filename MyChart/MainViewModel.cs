using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChart
{
    class MainViewModel
    {
        private RandomDataGeneratorStub _dataProvider2 = new RandomDataGeneratorStub(150, 95);
        //private DataGeneratorStub _dataProvider = new DataGeneratorStub(250, 125);
        private IncrementDataGenerationStub _dataProvider = new IncrementDataGenerationStub(250, 150);

        private BarChartViewModel _bars = new BarChartViewModel();
        public BarChartViewModel Bars 
        {
            get {return _bars;}
        }

        private TChartViewModel _chart = new TChartViewModel(50);
        public TChartViewModel Chart
        {
            get { return _chart; }
        }

        private TChartViewModel _chart2 = new TChartViewModel(50);
        public TChartViewModel Chart2
        {
            get { return _chart2; }
        }

        public MainViewModel()
        {
            //Chart.UpperLimit = 200;
            Chart.AutoScale = true;
            _dataProvider.GetNewData += Chart.RecieveAndShift;
            _dataProvider.Start();

            _dataProvider2.GetNewData += Chart2.RecieveAndShift;
            _dataProvider2.Start();

            _bars.AddBar(50, "Bar1");
            _bars.AddBar(25, "Bar2");
            _bars.AddBar(75, "Bar3");
        }
        
        public void Start()
        {
            _dataProvider.Start();
        }

    }
}
