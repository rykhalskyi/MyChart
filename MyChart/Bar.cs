namespace MyChart
{
    public class Bar: BaseViewModel
    {
        private double _value;
        public double Value
        {
            get { return _value; }
            set 
            {
                _value = value;
                FireEvent("Value");
            }
        }

        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                FireEvent("isSelected");
            }
        }
    }
}
