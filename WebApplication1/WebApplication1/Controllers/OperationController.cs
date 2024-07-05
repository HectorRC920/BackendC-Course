using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        [HttpGet]
        public decimal Add(decimal a,decimal b)
        { return a + b; }
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var body = await reader.ReadToEndAsync();
                // Do something with the body
                return Ok(new { Body = body });
            }
        }
        [HttpPost("/ola")]
        public decimal Sub([FromHeader] string Host, [FromBody] Numbers numbers)
        {

            Console.WriteLine(Host);
            return numbers.a - numbers.b;
        }
    }
    public class Numbers
    {
        public decimal a { get; set; }
        public decimal b { get; set; }
    }
}
