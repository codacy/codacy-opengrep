namespace Tests.Bugs
{
    class MyObject
    {
        public bool IsCorrupted { get; set; }
    }

    class Creator
    {
        public void Method(MyObject myObject)
        {
            if (myObject is null)
            {
                new MyObject(); // Noncompliant
            }
            var other = new MyObject();
            Use(new MyObject());
        }

        void Use(MyObject o) { }
    }
}
