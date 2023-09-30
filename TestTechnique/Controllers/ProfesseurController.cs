using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestTechnique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesseurController : ControllerBase
    {
        private readonly IProfesseurRepository _repository;
        public ProfesseurController(IProfesseurRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professeur>>> GetAllProfesseur()
        {
            return Ok(await _repository.GetProfesseur());
        }
        [HttpPost]
        public async Task<ActionResult<Professeur>> CreateProf(Professeur prof)
        {
            try
            {
                if (prof == null)
                    return BadRequest();

                var createProf = await _repository.AddProfesseur(prof);

                return CreatedAtAction(nameof(GetAllProfesseur),
                    new { id = createProf.Id }, createProf);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erreur serveur");
            }

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Professeur>> GetAdminById(int id)
        {
            try
            {
                var result = await _repository.GetProfesseurById(id);

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
        public async Task<ActionResult<Administrateur>> UpdateProf(int id, Professeur prof)
        {
            try
            {
                if (id != prof.Id)
                    return BadRequest();

                var profs = await _repository.GetProfesseur();

                if (profs == null)
                    return NotFound();

                return await _repository.UpdateProfesseur(profs);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erreur de mise à jour");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Administrateur>> DeleteAdmin(int prof)
        {
            try
            {
                var profs = await _repository.GetProfesseurById(prof);

                if (profs == null)
                {
                    return NotFound();
                }

                return await _repository.DeleteAdmin(profs);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error server");
            }
        }
    }
}
