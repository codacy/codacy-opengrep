namespace Tests.Style
{
    class X
    {
        public X() { } // Noncompliant
        static X() { }  // Noncompliant
        ~X() { } // Noncompliant
        public int Value { get; set; }
    }

    class Y : X
    {
        public Y(int parameter) : base() // Noncompliant
        {
            Value = parameter;
        }
    }

    class Z
    {
        public Z() { }
        public Z(int value) { }
    }
}
