using System;
using System.Collections.Generic;
using System.Text;

namespace Maxim_Drive.MapModel
{
    public class Map
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Map(int x, int y)
        {
            if (x < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(x), $"Enter positive coordinates");
            }
            if (y < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(y), $"Enter positive coordinates");
            }
            X = x;
            Y = y;
        }
        public string[,] BuildMap()
        {
            string[,] map = new string[Y, X];

            string value = "*";
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    map[j, i] = value;
                }
            }

            return map;
        }
    }


}