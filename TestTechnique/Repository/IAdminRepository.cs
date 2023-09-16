
namespace TestTechnique.Repository;

public interface IAdminRepository
{
   
    Task<IEnumerable<Administrateur>> GetAdministrateur();
    Task<Administrateur> GetAdminById(int adminId);
    Task<Administrateur> AddAdmin(Administrateur admin);
    Task<Administrateur> UpdateAdmin(Administrateur admin);
    void DeleteAdmin(int adminId);


}
