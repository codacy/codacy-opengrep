using System;
using System.ComponentModel.DataAnnotations;

namespace Tests.Bugs
{
    internal class Account
    {
        public DateTime Id { get; set; } // Noncompliant
        public string Name { get; set; }
    }

    internal class Person
    {
        [Key]
        public DateTime PersonIdentifier { get; set; } // Noncompliant
        public string Name { get; set; }
    }

    internal class Order
    {
        public DateTime OrderId { get; set; } // Noncompliant
        public DateTime CreatedAt { get; set; }
    }

    internal class Product
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
    }
}
