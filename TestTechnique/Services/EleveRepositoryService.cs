namespace TestTechnique.Services;

public class EleveRepositoryService : IEleveRepository
{
    private readonly DbContextTache _context;

    public EleveRepositoryService(DbContextTache context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<Eleve>> GetEleve()
    {
        return await _context.Eleves.ToListAsync();
    }

    public async Task<Eleve> GetEleveById(int prof)
    {
        return await _context.Eleves
            .FirstOrDefaultAsync(e => e.Id == prof);
    }

    public async Task<Eleve> AddEleve(Eleve eleve)
    {
        var result = await _context.Eleves.AddAsync(eleve);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Eleve?> UpdateEleve(Eleve eleve)
    {
        var result = await _context.Eleves
            .FirstOrDefaultAsync(e => e.Id == eleve.Id);

        if (result != null)
        {
            result.dateCreation = eleve.dateCreation;
            result.NomEtPrenom = eleve.NomEtPrenom;
            result.dateNaissance = eleve.dateNaissance;
            result.lieuNaissance = eleve.lieuNaissance;
            result.niveau = eleve.niveau;
            await _context.SaveChangesAsync();

            return result;
        }

        return null;
    }

    public async void DeleteEleve(int id)
    {
        var result = await _context.Eleves
            .FirstOrDefaultAsync(e => e.Id == id);
        if (result != null)
        {
            _context.Eleves.Remove(result);
            await _context.SaveChangesAsync();
        }
    }

  
}
