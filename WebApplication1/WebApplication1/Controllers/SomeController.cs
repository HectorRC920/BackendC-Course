using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : Controller
    {
        [HttpGet("sync")]
        public IActionResult GetSync()
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();

            Thread.Sleep(1000);
            Console.WriteLine("Conexion a base de datos terminada");

            Thread.Sleep(1000);
            Console.WriteLine("Email enviado");

            Console.WriteLine("Todo ha terminado");

            sw.Stop();
            return Ok(sw.Elapsed);
        }
        [HttpGet("async")]
        public async Task<IActionResult> GetASync()
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            var task1 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Conexion a base de datos terminada");
                return 8;
            });
            task1.Start();

            Console.WriteLine("Hago otra cosa");

            var task2 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Email enviado");
                return 2;
            });
            task2.Start();

            await task2;
            var ola = await task1;
            var ola2 = await task2;
            sw.Stop();
            Console.WriteLine("Todo as tweminado");
            return Ok(ola + " " + ola2  + " " + sw.Elapsed);
        }
    }
}
