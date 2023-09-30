using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestTechnique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EleveController : ControllerBase
    {
        private readonly IEleveRepository _repository;
        public EleveController(IEleveRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Eleve>>> GetAllEleve()
        {
            return Ok(await _repository.GetEleve());
        }
        [HttpPost]
        public async Task<ActionResult<Eleve>> CreateProf(Eleve eleve)
        {
            try
            {
                if (eleve == null)
                    return BadRequest();

                var createEleve = await _repository.AddEleve(eleve);

                return CreatedAtAction(nameof(GetAllEleve),
                    new { id = createEleve.Id }, createEleve);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erreur serveur");
            }

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Eleve>> GetGetById(int id)
        {
            try
            {
                var result = await _repository.GetEleveById(id);

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
        public async Task<ActionResult<Eleve>> UpdateProf(int id, Eleve eleve)
        {
            try
            {
                if (id != eleve.Id)
                    return BadRequest();

                var profs = await _repository.GetEleve();

                if (profs == null)
                    return NotFound();

                return await _repository.UpdateEleve(eleve);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erreur de mise à jour");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Eleve>> DeleteAdmin(int eleve)
        {
            try
            {
                var eleves = await _repository.GetEleveById(eleve);

                if (eleves == null)
                {
                    return NotFound();
                }

                return await _repository.DeletEleve(eleve);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error server");
            }
        }
    }
}
}
