
namespace MyChart
{
    class IncrementDataGenerationStub: DataGeneratorStub
    {
        private int _currentData = 0;
        private int _shelf = 0;
        private int _max;
        
        public IncrementDataGenerationStub(double interval, int value): base(interval, value)
        {
            _max = value;
        }

        protected override int GenerateData()
        {
            _shelf++;
                if (_shelf==5)
                {
                    _shelf = 0;
                    _currentData += 10;

                    if (_currentData >= _max) _currentData = _max / 2;
                }
            

            return _currentData;
        } 
    }
}
