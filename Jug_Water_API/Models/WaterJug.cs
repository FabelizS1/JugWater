namespace Jug_Water_API.Models
{
    public class WaterJug
    {
        public int Capacity { get; set; }
        public int Amount { get; set; }



        public WaterJug(int capacity)
        {
            Capacity = capacity;
            Amount = 0;
        }
        public override string ToString()
        {
            return $"({Amount}/{Capacity})";
        }
    }

}
