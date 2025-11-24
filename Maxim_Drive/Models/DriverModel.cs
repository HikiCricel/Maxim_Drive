using System;
using System.Collections.Generic;
using System.Text;

namespace Maxim_Drive.DriverModel
{
    public class Driver
    {
        public int Id { get; }
        public int X { get; set; }
        public int Y { get; set; }

        public Driver(int id, int x, int y)
        {
            Id = id;
            X = x;
            Y = y;
        }
    }
}