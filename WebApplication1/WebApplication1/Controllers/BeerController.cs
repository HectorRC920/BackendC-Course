using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        IBeerService _beerService;
        public BeerController([FromServices] IBeerService beerService)
        {
            _beerService = beerService;
        }
        [HttpGet("all")]
        public async Task<IEnumerable<BeerDTO>> GetAll()
        {
            return await _beerService.GetBeersAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOne(int id)
        {
            var beer =  await _beerService.GetBeerAsync(id);
            if(beer == null)
            {
                return NotFound();
            }
            return Ok(beer);
        }
        [HttpPost]
        public async Task<ActionResult> CreateOneAync([FromBody] BeerInsertDTO beerInsertDTO)
        {
            var beer = await _beerService.CreateBeerAsync(beerInsertDTO);

            return CreatedAtAction(nameof(GetOne), new { id = beer.Id }, beer);
        }      
    }
}
