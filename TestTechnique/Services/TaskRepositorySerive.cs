

namespace TestTechnique.Services;

public class TaskRepositorySerive : ITaskRepository, AdminRepositoryService
{
    private readonly DbContextTache _context;
    private readonly AdminRepositoryService _service;


    public TaskRepositorySerive(DbContextTache context, AdminRepositoryService service)
    {
        _context = context;
        _service = service;

    }

    public async Task<IEnumerable<Taches>> GetTask()
    {
        return await _context.Tache.ToListAsync();
    }

    public async Task<Taches> GetTaskById(int admin)
    {
        return await _context.Tache
            .FirstOrDefaultAsync(e => e.Id == admin);
    }

    public async Task<Taches> AddTask(Taches admin)
    {
        //var user = await _service.FindAsync(admin.Id);
        //if (user == null)
        //    return null;
        var result = await _context.Tache.AddAsync(admin);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Taches> UpdateTask(Taches task)
    {

        var result = await _context.Tache
            .FirstOrDefaultAsync(e => e.Id == task.Id);

        if (result != null)
        {
            result.Tittre = task.Tittre;
            result.DateDebut = task.DateDebut;
            result.DateFin = task.DateFin;
            result.Description = task.Description;
            
            await _context.SaveChangesAsync();

            return result;
        }

        return null;
    }

    public async void DeleteTask(int id)
    {
        var result = await _context.Tache
            .FirstOrDefaultAsync(e => e.Id == id);
        if (result != null)
        {
            _context.Tache.Remove(result);
            await _context.SaveChangesAsync();
        }
    }

   

   

   
}
