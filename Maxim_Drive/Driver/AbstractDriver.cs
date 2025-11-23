namespace Maxim_Drive.Driver
{
    public abstract class AbstractDriver
    {
        public int Id { get; }
        public int X { get; set; }
        public int Y { get; set; }

        protected AbstractDriver(int id)
        {
            Id = id;
            X = 0;
            Y = 0;
        }

        public abstract void SetCoordinates(int x, int y);
    }
}