namespace Tests.Style
{
    public class Car
    {
        private string _make;
        public string Make // Noncompliant
        {
            get { return _make; }
            set { _make = value; }
        }

        private int _speed;
        public int Speed
        {
            get { return _speed; }
            set { _speed = value < 0 ? 0 : value; }
        }

        private string _model;
        public string Model { get => _model; set => _model = value; } // Noncompliant
    }
}
