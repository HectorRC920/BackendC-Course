using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IBeerService
    {
        public Task<IEnumerable<BeerDTO>> GetBeersAsync();

        public Task<BeerDTO> GetBeerAsync(int id);

        public Task<BeerDTO> CreateBeerAsync(BeerInsertDTO beerInsertDto);
    }
}
