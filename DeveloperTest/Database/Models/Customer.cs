using DeveloperTest.Models;
using System;
using System.Collections.Generic;

namespace DeveloperTest.Database.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CustomerType Type { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}
