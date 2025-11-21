using System;
using System.Collections.Generic;
using System.Text;

namespace Maxim_Drive.Map
{
    public class DefaultMap: AbstractMap
    {
        public DefaultMap(int x, int  y) : base(x, y) { }

        public override string[,] BuildMap()
        {
            string[,] map = new string[Y, X];

            string value = "*";
            for(int i = 0; i < Y; i++)
            {
                for(int j = 0; j < X; j++)
                {
                    map[i, j] = value;
                }
            }

            return map;
        }
    }
}
