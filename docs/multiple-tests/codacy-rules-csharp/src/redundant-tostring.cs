namespace Tests.Style
{
    class Strings
    {
        void M(int count)
        {
            var s = "foo";
            var t = "fee fie foe " + s.ToString(); // Noncompliant
            var someObject = new object();
            var u = "" + someObject.ToString(); // Noncompliant
            var v = "Count: " + count.ToString();
        }
    }
}
