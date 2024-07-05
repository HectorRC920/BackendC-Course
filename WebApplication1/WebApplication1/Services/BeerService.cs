using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class BeerService : IBeerService
    {
        private StoreContext _storeContext;

        public BeerService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<IEnumerable<BeerDTO>> GetBeersAsync()
        {
            var beers =  _storeContext.Beers.Select( b => new BeerDTO()
            {
                Id = b.BeerId,
                Name = b.Name,
                BrandId = b.BrandId,
                Alcohol = b.Alcohol,
            });
            return await beers.ToListAsync();
            
        }
        public async Task<BeerDTO> GetBeerAsync(int id)
        {
            var beer = await  _storeContext.Beers.FindAsync(id);

            if (beer == null)
            {
                return null;
            }
            return new BeerDTO()
            {
                Id = id,
                Name = beer.Name,
                BrandId = beer.BrandId,
                Alcohol = beer.Alcohol,
            };
        }
        public async Task<BeerDTO> CreateBeerAsync(BeerInsertDTO beerInsertDto)
        {

            var beer = new Beer()
            {
                Name = beerInsertDto.Name,
                Alcohol = beerInsertDto.Alcohol,
                BrandId = beerInsertDto.BrandId
            };
            await _storeContext.Beers.AddAsync(beer);
            await _storeContext.SaveChangesAsync();

            var beerDto = new BeerDTO()
            {
                Id = beer.BeerId,
                Name = beerInsertDto.Name,
                Alcohol = beerInsertDto.Alcohol,
                BrandId = beerInsertDto.BrandId
            };
            return beerDto;
        }
    }
}
