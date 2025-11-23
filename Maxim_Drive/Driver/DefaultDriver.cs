using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Maxim_Drive.Driver
{
    public class DefaultDriver : AbstractDriver
    {
        public DefaultDriver() : base(int.Parse(GenerateId())) { }
        private static readonly HashSet<(int X, int Y)> _occupiedCoordinates = new();

        private static int _counter = 0;

        private static string GenerateId()
        {
            return $"{++_counter}";
        }


        public override void SetCoordinates(int x, int y)
        {
            var newCoord = (x, y);
            var oldCoord = (X, Y);

            if (oldCoord != (0, 0) || X != 0 || Y != 0)
            {
                _occupiedCoordinates.Remove(oldCoord);
            }

            if (_occupiedCoordinates.Contains(newCoord))
            {
                _occupiedCoordinates.Add(oldCoord);
                throw new InvalidOperationException($"Координаты ({x}, {y}) уже заняты другим водителем");
            }
            X = x;
            Y = y;
            _occupiedCoordinates.Add(newCoord);
        }
        public static void Reset()
        {
            _occupiedCoordinates.Clear();
            _counter = 0;
        }
    }
}