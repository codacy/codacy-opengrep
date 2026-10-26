using System.IO;

namespace Tests.Practices
{
    public class Foo
    {
        public string ListUsers()
        {
            string userListPath = "/home/mylogin/Dev/users.txt"; // Noncompliant
            string url = "https://api.example.com/v1/users"; // Noncompliant
            string windows = @"C:\Users\me\file.txt"; // Noncompliant
            string ns = "http://www.w3.org/2001/XMLSchema";
            string relative = "users.txt";
            return File.ReadAllText(userListPath);
        }
    }
}
