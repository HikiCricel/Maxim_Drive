using System;
using System.Collections.Generic;
using System.Text;

namespace Maxim_Drive.Map
{
    public abstract class AbstractMap
    {
        public int X {  get; set; }
        public int Y { get; set; }

        protected AbstractMap(int x , int y)
        {
            X = x;
            Y = y;
        }

        public abstract string[,] BuildMap();
    }
}
