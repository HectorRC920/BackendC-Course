using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : Controller
    {
        private IPeopleService _peopleService;
        public PeopleController([FromKeyedServices("people2Service")] IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }
        [HttpGet("all")]
        public List<People> GetPeople() => Repository.People;
        //Route params
        [HttpGet("{id}")]
        public ActionResult<People> Get(int id)
        {
           var people = Repository.People.FirstOrDefault(x => x.Id == id);
            if (!_peopleService.Validate(people))
            {
                return NotFound();
            }
            return Ok();
        } 
        [HttpGet("search/{search}")]
        public List<People> Get(string search) => Repository.People
                                         .Where(x => x.Name.ToUpper().Contains(search.ToUpper())).ToList();

        [HttpPost]
        public IActionResult actionResult(People people)
        {
            if(!_peopleService.Validate(people))
            {
                return BadRequest("Ola");
            }
            Repository.People.Add(people);
            return NoContent();
        }
    }
    public class Repository
    {
        public static List<People> People = new List<People>
        {
            new People(){
                Id = 1, Name="Pancho", BirthDate=new DateTime(1990,2,12)
             },
            new People(){
                Id = 2, Name="Pepe", BirthDate=new DateTime(1990,2,12)
             },new People(){
                Id = 3, Name="Paco", BirthDate=new DateTime(1990,2,12)
             },
        };
    }
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
