using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using contact_api.Services;
using contact_api.Models;

namespace contact_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleServices _peopleServices;

        public PeopleController(PeopleServices peopleServices)
        {
            _peopleServices = peopleServices;
        }

        [HttpGet]
        public async Task<List<People>> GetPeople()
            => await _peopleServices.GetAsync();

        [HttpDelete]
        public async Task<string> RemovePeople(string id)
        {
            await _peopleServices.RemoveAsync(id);
            return id;
        }

        [HttpPut]
        public async Task<People> UpdatePeople(string id, People people)
        {
            await _peopleServices.UpdateAsync(id, people);
            return people;
        }
        [HttpPost]
        public async Task<People> PostPeople(People people)
        {
            await _peopleServices.CreateAsync(people);

            return people;
        }
    }
}
