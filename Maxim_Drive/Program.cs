using Maxim_Drive.DriverModel;
using Maxim_Drive.MapModel;
using Maxim_Drive.OrderModel;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Threading.Channels;

namespace Maxim_Drive
{
    public class Functions
    {
        public void DrawMap(int mapWidth, int mapLenght, (int x, int y) oCoord, Driver[] drivers)
        {
            var map_b = new Map(mapLenght, mapWidth);
            string[,] map = map_b.BuildMap();
            map[oCoord.x, oCoord.y] = "O";
            foreach(var d in drivers)
            {
                map[d.X, d.Y] = $"{d.Id}";
            }
            Console.WriteLine("Result:");
            for (int i = 0; i < map_b.X; i++)
            {
                Console.Write('|');
                for (int j = 0; j < map_b.Y; j++)
                {
                    Console.Write($"{map[j, i],3}");
                }
                Console.Write('|');
                Console.WriteLine();
            }


            return;
        }
    }
    class Program
    {
        public static void Main()
        {
            var f = new Functions();
            Console.Write("Введите длину:");
            int mapWidth = int.Parse(Console.ReadLine());
            Console.Write("Введите ширину:");
            int mapLenght = int.Parse(Console.ReadLine());
            if (mapWidth <= 0 || mapLenght <= 0)
            {
                Console.WriteLine("Wrong coordinates");
                return;
            }

            Console.Write("Enter driver quantity: ");
            int n = int.Parse(Console.ReadLine());
            if (n <= 0 || n >= (mapLenght*mapWidth))
            {
                Console.WriteLine("Wrong number");
                return;
            }

            Driver[] drivers = new Driver[n];
            var uniq = new HashSet<(int x, int y)>();

            var random = new Random();

            int yOrd = random.Next(0, mapLenght);
            int xOrd = random.Next(0, mapWidth);
            var order = new Order(1, xOrd, yOrd);
            var oCoord = (xOrd, yOrd);
            uniq.Add(oCoord);

            for (int i = 0; i < n; i++)
            {
                int yCoord = random.Next(0, mapLenght);
                int xCoord = random.Next(0, mapWidth);

                var coord = (xCoord, yCoord);

                if (uniq.Contains(coord))
                {
                    i--;
                }
                else
                {
                    uniq.Add(coord);
                    drivers[i] = new Driver(i, xCoord, yCoord);
                }
            }
            foreach (var d in uniq)
            {
                Console.WriteLine($"{d}");
            }
            Console.WriteLine($"{order.X},  {order.Y}");
            f.DrawMap(mapWidth, mapLenght, oCoord, drivers);
        }
    }

}