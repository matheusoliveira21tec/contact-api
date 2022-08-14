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
        public async Task<List<People>> GetProdutos()
             => await _peopleServices.GetAsync();
        [HttpGet("{id}")]
        public async Task<People> GetProdutos(string id)
             => await _peopleServices.GetAsync(id);
        [HttpDelete("{id}")]
        public async Task<string> RemovePeople(string id)
        {
            await _peopleServices.RemoveAsync(id);
            return id;
        }

        [HttpPut("{id}")]
        public async Task<People> UpdatePeople(string id, People people)
        {
           People retorno= await _peopleServices.UpdateAsync(id, people);
            return retorno;
        }
        [HttpPost]
        public async Task<People> PostPeople(People people)
        {
            await _peopleServices.CreateAsync(people);

            return people;
        }
    }
}
