namespace Tests.Performance
{
    class Fruit { }

    class Casts
    {
        void M(object x)
        {
            if (x is Fruit)
            {
                var f = (Fruit)x; // Noncompliant
                Use(f);
            }
            if (x is Fruit fruit)
            {
                Use(fruit);
            }
        }

        void Use(Fruit f) { }
    }
}
