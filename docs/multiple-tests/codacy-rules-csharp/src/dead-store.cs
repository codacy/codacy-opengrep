namespace Tests.Performance
{
    class Stores
    {
        int Foo(int y)
        {
            int x = 100; // Noncompliant
            x = 150;
            x = x + 1;
            int z = 0;
            z = 5;
            int w;
            w = 7; // Noncompliant
            w = 8;
            return x + y + z + w;
        }
    }
}
