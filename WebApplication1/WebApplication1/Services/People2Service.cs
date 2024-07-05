using WebApplication1.Controllers;

namespace WebApplication1.Services
{
    public class People2Service : IPeopleService
    {
        public bool Validate(People people)
        {
            if (string.IsNullOrEmpty(people.Name) || people.Name.Length < 3) return false;

            return true;
        }
    }
}
