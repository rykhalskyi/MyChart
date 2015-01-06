using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MyChart
{
    public class RandomDataGeneratorStub: DataGeneratorStub
    {
        Random _random = new Random();
        private int _maxValue = 30;
        
        public RandomDataGeneratorStub(double interval, int maxValue):base(interval, 0)
        {
            _maxValue = maxValue;
        }

        protected override int GenerateData()
        {
            return _random.Next(0, _maxValue); 
        }
    }
}
