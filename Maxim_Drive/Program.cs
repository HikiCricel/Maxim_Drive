using Maxim_Drive.Map;
using System;
using System.Threading.Channels;

class Program
{
    static void Main()
    {
        Console.Write("Enter map sizes:");
        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());
        var map_b = new DefaultMap(x,y);
        string[,] map = map_b.BuildMap();
        Console.WriteLine("Result:");
        for(int i = 0; i<map_b.Y; i++)
        {
            Console.Write('|');
            for(int j = 0; j<map_b.X; j++)
            {
                Console.Write($"{map[i,j], 3}");
            }
            Console.Write('|');
            Console.WriteLine();
        }
    }
}