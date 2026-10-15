namespace Tests.Performance
{
    class Chars
    {
        void M()
        {
            string str = "some string";
            foreach (var c in str.ToCharArray()) // Noncompliant
            {
                System.Console.Write(c);
            }
            var first = str.ToCharArray()[0]; // Noncompliant
            foreach (var c in str)
            {
                System.Console.Write(c);
            }
        }
    }
}
