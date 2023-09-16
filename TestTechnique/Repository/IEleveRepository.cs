namespace TestTechnique.Repository;

public interface IEleveRepository
{
    Task<IEnumerable<Eleve>> GetEleve();
    Task<Eleve> GetEleveById(int eleve);
    Task<Eleve> AddEleve(Eleve eleve);
    Task<Eleve> UpdateEleve(Eleve eleve);
    void DeletEleve(int eleve);
}
