using Microsoft.AspNetCore.Mvc;
using Redis.Repository;
using System.Threading.Tasks;

namespace Redis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NarutoController : ControllerBase
    {
        private readonly NarutoJutsuRepository _repository;

        public NarutoController(NarutoJutsuRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string teste = await _repository.Jutsu();
            return Ok(teste);
        }
    }
}
