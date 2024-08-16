using Jug_Water_API.Models;

namespace Jug_Water_API.Services
{
    public interface JugWaterInterface
    {
        List<Message> GetMessagesJugWater(int jug1Capacity, int jug2Capacity, int targetAmount);
    }
}
