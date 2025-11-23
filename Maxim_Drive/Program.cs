using Maxim_Drive.Driver;
using Maxim_Drive.Map;
using System;
using System.Data;
using System.Threading.Channels;

namespace Maxim_Drive
{
    public class Functions
    {
        public void Map()
        {
            Console.Write("Enter X:");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Enter Y:");
            int y = int.Parse(Console.ReadLine());
            if (x <= 0 || y <= 0)
            {
                Console.WriteLine("Wrong coordinates");
                return;
            }
            var map_b = new DefaultMap(x, y);
            string[,] map = map_b.BuildMap();
            Console.WriteLine("Result:");
            for (int i = 0; i < map_b.Y; i++)
            {
                Console.Write('|');
                for (int j = 0; j < map_b.X; j++)
                {
                    Console.Write($"{map[i, j],3}");
                }
                Console.Write('|');
                Console.WriteLine();
            }
            return;
        }

        public void Drivers()
        {
            DefaultDriver.Reset();
            Console.Write("Enter driver quantity: ");
            int n = int.Parse(Console.ReadLine());
            if (n <= 0)
            {
                Console.WriteLine("Wrong number");
                return;
            }

            var drivers = new DefaultDriver[n];

            for (int i = 0; i < n; i++)
            {
                int x, y;
                bool flag;

                do
                {
                    Console.Write("Enter X: ");
                    flag = int.TryParse(Console.ReadLine(), out x);
                    if (!flag) Console.WriteLine("Wrong X. Try again");

                } while (!flag);

                do
                {
                    Console.Write("Enter Y: ");
                    flag = int.TryParse(Console.ReadLine(), out y);
                    if (!flag) Console.WriteLine("Wrong Y. Try again");

                } while (!flag);

                try
                {
                    var driver = new DefaultDriver();
                    driver.SetCoordinates(x, y);
                    drivers[i] = driver;
                    Console.WriteLine($"Driver {driver.Id}: ({x}, {y})");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    i--;
                }
            }
        }

    }
    class Program
    {
        public static void Main()
        {
            var f = new Functions();
            f.Map();
            f.Drivers();
        }
    }

}