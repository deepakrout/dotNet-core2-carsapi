﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAPI.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Make { get; set; }
        public string  Model { get; set; }
        public string Year { get; set; }
    }
}
