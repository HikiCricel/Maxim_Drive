namespace Maxim_Drive.OrderModel
{
    public class Order
    {
        public int Id { get; }
        public int X { get; set; }
        public int Y { get; set; }

        public Order(int id, int x, int y)
        {
            Id = id;
            X = x;
            Y = y;
        }
    }
}