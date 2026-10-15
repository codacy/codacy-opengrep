namespace MyLibrary
{
    public class MyClass
    {
        private string myUri;

        public string MyUri // Noncompliant
        {
            get { return myUri; }
            set { myUri = value; }
        }

        public string Name { get; set; }
    }
}
