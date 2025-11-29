namespace Maxim_Drive.OrderModel
{
    public class Order
    {
        public int Id { get; }
        public int X { get; set; }
        public int Y { get; set; }

        public Order(int id, int x, int y)
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
    }
}