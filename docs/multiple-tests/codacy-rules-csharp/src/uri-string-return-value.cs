namespace MyLibrary
{
    public class MyClass
    {
        public string GetParentUri() // Noncompliant
        {
            return "http://www.mysite.com";
        }

        public string GetName()
        {
            return "name";
        }
    }
}
