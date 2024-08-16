using Jug_Water_API.Models;
using Jug_Water_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jug_Water_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class JugController : ControllerBase
    {

        private readonly JugWaterInterface _jugWaterInterface;

        public JugController(JugWaterInterface jugWaterInterface)
        {
            _jugWaterInterface = jugWaterInterface;
        }



        [HttpPost]
        public async Task<ActionResult<List<Message>>> GetJugInformation([FromBody] Jug jug)
        {

            List<Message> messages = _jugWaterInterface.GetMessagesJugWater(jug.x_capacity, jug.y_capacity, jug.z_capacity);

            if (messages.Count() == 0)
            {
                return BadRequest(messages);
            }
            else
            {
                return Ok(messages);
            }


        }
    }
}
