                                                                                                                               using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : Controller
    {
        private IRandomService _RandomServiceSingleton;
        private IRandomService _RandomServiceScoped;
        private IRandomService _RandomServiceTransient;

        private IRandomService _RandomService2Singleton;
        private IRandomService _RandomService2Scoped;
        private IRandomService _RandomService2Transient;

        public RandomController(
            [FromKeyedServices("RandomServiceSingleton")] IRandomService randomService,
            [FromKeyedServices("RandomServiceScoped")] IRandomService randomServiceScoped,
            [FromKeyedServices("RandomServiceTransient")] IRandomService randomServiceTransient,
            [FromKeyedServices("RandomServiceSingleton")] IRandomService randomService2,
            [FromKeyedServices("RandomServiceScoped")] IRandomService randomService2Scoped,
            [FromKeyedServices("RandomServiceTransient")] IRandomService randomService2Transient
            ) 
        {
            _RandomServiceSingleton = randomService;
            _RandomServiceScoped = randomServiceScoped;
            _RandomServiceTransient = randomServiceTransient;

            _RandomService2Singleton = randomService2;
            _RandomService2Scoped = randomService2Scoped;
            _RandomService2Transient = randomService2Transient;

        }
        [HttpGet]
        public ActionResult<Dictionary<string, int>> Index()
        {
            Dictionary<string, int> ola = new Dictionary<string, int>();
            ola.Add("Singleton", _RandomServiceSingleton.Value);
            ola.Add("Singleton2", _RandomService2Singleton.Value);
            ola.Add("Scoped", _RandomServiceScoped.Value);
            ola.Add("Scoped2", _RandomService2Scoped.Value);
            ola.Add("Transient", _RandomServiceTransient.Value);
            ola.Add("Transient2", _RandomService2Transient.Value);
            return ola;
        }
    }
}
