
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
        [HttpPost]
        public async Task<ActionResult<Administrateur>> CreateAdmin(Administrateur admin)
        {
            try
            {
                if (admin == null)
                    return BadRequest();

                var createTask = await _repository.AddAdmin(admin);

                return CreatedAtAction(nameof(GetAllAdmin),
                    new { id = createTask.Id }, createTask);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erreur serveur");
            }


    }
   
}
}
