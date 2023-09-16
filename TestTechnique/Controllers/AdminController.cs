using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestTechnique.Model;
using TestTechnique.Repository;

namespace TestTechnique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _repository;
        public  AdminController(IAdminRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrateur>>> GetAllAdmin()
        {
            return Ok(await _repository.GetAdministrateur());
        }

    }
   
}
