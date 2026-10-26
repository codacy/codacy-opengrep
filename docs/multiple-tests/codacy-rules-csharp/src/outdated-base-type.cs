using System;
using System.Collections;

namespace MyLibrary
{
    public class MyCollection : CollectionBase  // Noncompliant
    {
    }

    public class MyError : ApplicationException // Noncompliant
    {
    }

    internal class InternalCollection : CollectionBase
    {
    }
}
