namespace TestTechnique.Services;

public class ProfesseurRepositoryService : IProfesseurRepository
{
    private readonly DbContextTache _context;

    public ProfesseurRepositoryService(DbContextTache context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<Professeur>> GetProfesseur()
    {
        return await _context.Professeurs.ToListAsync();
    }

    public async Task<Professeur> GetProfesseurById(int prof)
    {
        return await _context.Professeurs
            .FirstOrDefaultAsync(e => e.Id == prof);
    }

    public async Task<Professeur> AddProfesseur(Professeur prof)
    {
        var result = await _context.Professeurs.AddAsync(prof);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Professeur?> UpdateProfesseur(Professeur prof)
    {
        var result = await _context.Professeurs
            .FirstOrDefaultAsync(e => e.Id == prof.Id);

        if (result != null)
        {
            result.dateCreation = prof.dateCreation;
            result.NomEtPrenom = prof.NomEtPrenom;
            result.dateNaissance = prof.dateNaissance;
            result.lieuNaissance = prof.lieuNaissance;
            result.matiere = prof.matiere;
            await _context.SaveChangesAsync();

            return result;
        }

        return null;
    }

    public async void DeleteProfesseur(int id)
    {
        var result = await _context.Professeurs
            .FirstOrDefaultAsync(e => e.Id == id);
        if (result != null)
        {
            _context.Professeurs.Remove(result);
            await _context.SaveChangesAsync();
        }
    }

}
