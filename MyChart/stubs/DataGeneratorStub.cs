using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MyChart
{
    public class DataGeneratorStub
    {
        private Timer _timer;
        private int _value;

        public event Action<int> GetNewData = null;
        
        public DataGeneratorStub(double interval, int value)
        {
            _timer = new Timer(interval);
            _value = value;
            _timer.Elapsed += FireData;
        }

        public void Start()
        {
            _timer.Start();
        }

        private void FireData(object obj, ElapsedEventArgs e)
        {
            if (GetNewData != null)
            {
                GetNewData(GenerateData());
            }
        }

        protected virtual int GenerateData()
        {
            return _value;
        }

        ~DataGeneratorStub()
        {
            _timer.Elapsed -= FireData;
            _timer.Dispose();
        }
    }

    
}
