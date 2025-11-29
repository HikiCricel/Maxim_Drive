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
            if (x < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(x), $"Enter positive coordinates");
            }
            if (y < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(y), $"Enter positive coordinates");
            }
            Id = id;
            X = x;
            Y = y;
        }

        public double GetDistanceTo(int x, int y)
        {
            int dx = this.X - x;
            int dy = this.Y - y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public double GetDistanceTo(OrderModel.Order order)
        {
            return GetDistanceTo(order.X, order.Y);
        }
    }
}