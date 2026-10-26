using System;

namespace MyLibrary
{
    public class MyClass
    {
        public void FetchResource(string uriString) // Noncompliant
        {
            Console.WriteLine(uriString);
        }

        public void FetchResource(Uri uri)
        {
            Console.WriteLine(uri);
        }

        public void Download(string url)
        {
            Download(new Uri(url));
        }

        public void Download(Uri url)
        {
            Console.WriteLine(url);
        }
    }
}
