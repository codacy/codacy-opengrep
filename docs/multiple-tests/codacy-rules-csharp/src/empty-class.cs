using System;

namespace Tests.Practices
{
    public class Empty { } // Noncompliant

    public partial class Generated { }

    public class CreateUserCommand { }

    public class MyException : Exception { }

    [Serializable]
    public class Marker { }

    public class NotEmpty
    {
        public int Value { get; set; }
    }
}
