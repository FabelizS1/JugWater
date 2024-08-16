using Jug_Water_API.Models;
using System.Text.Json;

namespace Jug_Water_API.Services
{
    public class WaterJugService : JugWaterInterface
    {


        public List<Message> GetMessagesJugWater(int jug1Capacity, int jug2Capacity, int targetAmount)
        {

            var visited = new HashSet<(int, int)>(); 
            var queue = new Queue<(WaterJug, WaterJug, List<string>)>();

            List<Message> listMessage = new List<Message>();
            var jug1 = new WaterJug(jug1Capacity);
            var jug2 = new WaterJug(jug2Capacity);

            // If gcd of n and m does not divide d
            // then solution is not possible
            if ((targetAmount % gcd(jug2Capacity, jug1Capacity)) != 0)
            {
                Message message = new Message();
                message.action = "No Solution";
                listMessage.Add(message);
                return listMessage;
            }

            queue.Enqueue((jug1, jug2, new List<string>()));


            while (queue.Count > 0)
            {
                var (j1, j2, actions) = queue.Dequeue();

                
                if (j1.Amount == targetAmount || j2.Amount == targetAmount)
                {

                    int step = 1;                   

                    foreach (var action in actions)
                    {

                        string[] arrayMessage = action.Split("/");

                        Message message = new Message();
                        message.step = step;
                        message.bucketX = Int32.Parse(arrayMessage[1]);
                        message.bucketY = Int32.Parse(arrayMessage[2]);
                        message.action = arrayMessage[0];

                        listMessage.Add(message);
                        step++;
                    }


                    return listMessage;
                }



                
                if (visited.Contains((j1.Amount, j2.Amount)))
                    continue;

                visited.Add((j1.Amount, j2.Amount));

                // Fill jug1
                var newJ1 = new WaterJug(jug1Capacity);
                newJ1.Amount = jug1Capacity;
                queue.Enqueue((newJ1, j2, actions.Concat(new[] { $"Fill bucket y/" + newJ1.Amount + "/" + j2.Amount }).ToList()));


                // Fill jug2
                var newJ2 = new WaterJug(jug2Capacity);
                newJ2.Amount = jug2Capacity;
                queue.Enqueue((j1, newJ2, actions.Concat(new[] { $"Fill bucket y/" + j1.Amount + "/" + newJ2.Amount }).ToList()));


                // Empty jug1
                newJ1 = new WaterJug(jug1Capacity);
                queue.Enqueue((newJ1, j2, actions.Concat(new[] { $"Empty bucket x/" + newJ1.Amount + "/" + j2.Amount }).ToList()));


                // Empty jug2
                newJ2 = new WaterJug(jug2Capacity);
                queue.Enqueue((j1, newJ2, actions.Concat(new[] { $"Empty bucket y/" + j1.Amount + "/" + newJ2.Amount }).ToList()));


                // Pour jug1 into jug2
                var remaining = Math.Min(j1.Amount, jug2Capacity - j2.Amount);
                newJ1 = new WaterJug(jug1Capacity);
                newJ1.Amount = j1.Amount - remaining;
                newJ2 = new WaterJug(jug2Capacity);
                newJ2.Amount = j2.Amount + remaining;
                queue.Enqueue((newJ1, newJ2, actions.Concat(new[] { $"Transfer from bucket x to bucket y/" + newJ1.Amount + "/" + newJ2.Amount }).ToList()));


                // Pour jug2 into jug1
                remaining = Math.Min(j2.Amount, jug1Capacity - j1.Amount);
                newJ1 = new WaterJug(jug1Capacity);
                newJ1.Amount = j1.Amount + remaining;
                newJ2 = new WaterJug(jug2Capacity);
                newJ2.Amount = j2.Amount - remaining;
                queue.Enqueue((newJ1, newJ2, actions.Concat(new[] { $"Transfer from bucket y to bucket x/" + newJ1.Amount + "/" + newJ2.Amount }).ToList()));
            }

            return listMessage;
        }


        public int gcd(int a, int b)
        {
            if (b == 0)
                return a;

            return gcd(b, a % b);
        }



    }
}
