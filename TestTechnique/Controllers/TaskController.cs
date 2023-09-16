using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestTechnique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _repository;
        public TaskController(ITaskRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Taches>>> GetAllTache()
        {
            return Ok(await _repository.GetTask());
        }
        [HttpPost]
        public async Task<ActionResult<Taches>> CreateTache(Taches taches)
        {
            try
            {
                if (taches == null)
                    return BadRequest();

                var createTask = await _repository.AddTask(taches);

                return CreatedAtAction(nameof(GetAllTache),
                    new { id = createTask.Id }, createTask);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erreur serveur");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Taches>> GetTacheById(int id)
        {
            try
            {
                var result = await _repository.GetTaskById(id);

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
        public async Task<ActionResult<Taches>> UpdateTask(int id, Taches task)
        {
            try
            {
                if (id != task.Id )
                    return BadRequest();

                var tasks = await _repository.GetTask();

                if ( tasks== null)
                    return NotFound();

                return await _repository.UpdateTask(task);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erreur de mise à jour");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Task>> DeleteTask(int id)
        {
            try
            {
                var admin = await _repository.GetTaskById(id);

                if (admin == null)
                {
                    return NotFound();
                }

                return await _repository.DeleteTask(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error server");
            }
        }
    }
    

}
