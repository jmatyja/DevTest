﻿using System;

namespace DeveloperTest.Models
{
    public class BaseJobModel
    {
        public string Engineer { get; set; }

        public DateTime When { get; set; }

        public Customer Customer { get; set; }
    }
}
