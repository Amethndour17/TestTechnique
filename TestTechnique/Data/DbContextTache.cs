

namespace TestTechnique.Data;

public class DbContextTache : DbContext
{
    public DbContextTache(DbContextOptions context) : base(context)
    {

    }
    public DbSet<Administrateur> Administrateurs { get; set; }
    public DbSet<Professeur> Professeurs { get; set; }
    public DbSet<Eleve> Eleves { get; set; }
    public DbSet<Taches> Tache { get; set; }

}
