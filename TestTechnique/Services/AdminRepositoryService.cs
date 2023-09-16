
namespace TestTechnique.Services;

public class AdminRepositoryService : IAdminRepository
{
    private readonly DbContextTache _context;

    public AdminRepositoryService(DbContextTache context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<Administrateur>> GetAdministrateur()
    {
        return await _context.Administrateurs.ToListAsync();
    }

    public async Task<Administrateur> GetAdminById(int admin)
    {
        return await _context.Administrateurs
            .FirstOrDefaultAsync(e => e.Id == admin);
    }

    public async Task<Administrateur> AddAdmin(Administrateur admin)
    {

        var result = await _context.Administrateurs.AddAsync(admin);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Administrateur> UpdateAdmin(Administrateur admin)
    {
        var result = await _context.Administrateurs
            .FirstOrDefaultAsync(e => e.Id == admin.Id);

        if (result != null)
        { 
             result.dateCreation = admin.dateCreation;
             result.NomEtPrenom = admin.NomEtPrenom;
            result.dateNaissance = admin.dateNaissance;
            result.lieuNaissance = admin.lieuNaissance;
            result.posteAdmin = admin.posteAdmin;
            
            await _context.SaveChangesAsync();

            return result;
        }

        return null;
    }

    public async void DeleteAdmin(int id)
    {
        var result = await _context.Administrateurs
            .FirstOrDefaultAsync(e => e.Id == id);
        if (result != null)
        {
            _context.Administrateurs.Remove(result);
            await _context.SaveChangesAsync();
        }
    }

  }

