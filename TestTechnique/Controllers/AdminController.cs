
namespace TestTechnique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _repository;
        public AdminController(IAdminRepository repository)
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
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Administrateur>> GetAdminById(int id)
        {
            try
            {
                var result = await _repository.GetAdminById(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "La donnée n'existe pas");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Administrateur>> UpdateAdmin(int id, Administrateur admin)
        {
            try
            {
                if (id != admin.Id)
                    return BadRequest();

                var admins = await _repository.GetAdministrateur();

                if (admins == null)
                    return NotFound();

                return await _repository.UpdateAdmin(admin);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erreur de mise à jour");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Administrateur>> DeleteAdmin(int id)
        {
            try
            {
                var admin = await _repository.GetAdminById(id);

                if (admin == null)
                {
                    return NotFound();
                }

                return await _repository.DeleteAdmin(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error server");
            }
        }
    }
}

