using System;

namespace DeveloperTest.Models
{
    public abstract class CustomerBase
    {
        public string Name { get; set; }

        public CustomerType Type { get; set; }
    }
}
