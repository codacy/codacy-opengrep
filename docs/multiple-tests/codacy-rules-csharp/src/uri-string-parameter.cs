namespace MyLibrary
{
    public class MyClass
    {
        public void FetchResource(string uriString) { } // Noncompliant
        public void Download(string sourceUrl) { } // Noncompliant
        public void Format(string returnValue) { }
        private void Internal(string url) { }
    }
}
