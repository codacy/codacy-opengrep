using System;

namespace Tests.Style
{
    enum Fruit { Apple, Orange, Banana }

    public class Defaults
    {
        void PrintName(Fruit fruit)
        {
            switch (fruit)
            {
                case Fruit.Apple:
                    Console.WriteLine("apple");
                    break;
                default:
                    break; // Noncompliant@-1
            }

            switch (fruit)
            {
                case Fruit.Apple:
                    Console.WriteLine("apple");
                    break;
                default:
                    // nothing to do for other fruits
                    break;
            }
        }
    }
}
