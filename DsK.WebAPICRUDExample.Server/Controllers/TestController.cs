using DsK.DataService;
using DsK.DataService.Models;
using Microsoft.AspNetCore.Mvc;

namespace DsK.WebAPICRUDExample.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly RepositoryService _repositoryService;

        public TestController(RepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        [HttpGet]
        public ActionResult<List<Client>> Get()
        {
            return Ok(_repositoryService.ClientRepository.GetAll());
        }
    }
}
