using Jug_Water_API.Controllers;
using Jug_Water_API.Models;
using Jug_Water_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using Xunit;

namespace TestJugWater
{
    public class UnitTest1
    {
        JugController _jugController;
        JugWaterInterface _jugWaterInterface;

        public UnitTest1()
        {
            _jugWaterInterface = new WaterJugService();
            _jugController = new JugController(_jugWaterInterface);
        }

        /*[Fact]
        public void TestCorrectJSON()
        {

            WaterJugService service = new WaterJugService();




        }*/
        

        [Fact]
        public void TestNoSolution()
        {
            WaterJugService service = new WaterJugService();

            List<Message> listMessage = service.GetMessagesJugWater(2, 6, 5);

            string errorMessage = listMessage.Select(x => x.action).SingleOrDefault();

            Assert.Equal("No Solution", errorMessage);
        }
    }
}