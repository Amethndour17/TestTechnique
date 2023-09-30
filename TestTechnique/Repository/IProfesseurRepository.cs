namespace TestTechnique.Repository;

public interface IProfesseurRepository
{

    Task<IEnumerable<Professeur>> GetProfesseur();
    Task<Professeur> GetProfesseurById(int profId);
    Task<Professeur> AddProfesseur(Professeur prof);
    Task<Professeur> UpdateProfesseur(Professeur prof);
    void DeleteProfesseur(int profId);
}
