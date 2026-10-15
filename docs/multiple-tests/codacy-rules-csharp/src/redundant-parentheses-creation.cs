using System;
using System.Collections.Generic;

namespace Tests.Style
{
    [Serializable()] // Noncompliant
    public class MyClass
    {
        public int MyProperty { get; set; }

        public static MyClass CreateNew(int propertyValue)
        {
            var list = new List<int>() { 1, 2 }; // Noncompliant
            var other = new List<int>(10);
            return new MyClass() // Noncompliant
            {
                MyProperty = propertyValue
            };
        }

        [Obsolete("Use the other one")]
        public static MyClass Create() => new MyClass { MyProperty = 1 };
    }
}
