using DeveloperTest.Models;
using System;

namespace DeveloperTest.Database.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CustomerType Type { get; set; }
    }
}
