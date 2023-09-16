using Microsoft.EntityFrameworkCore;
using System;
using TestTechnique.Data;
using TestTechnique.Model;
using TestTechnique.Repository;

namespace TestTechnique.Services;

public class AdminRepositoryService : IAdminRepository
{
    private readonly DbContextTache _context;

    public AdminRepositoryService(DbContextTache context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<Administrateur>> GetAdmin()
    {
        return await _context.Administrateurs.ToListAsync();
    }

    public async Task<Administrateur> GetByIdAdmin(int admin)
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
            result.dateNaissance = admin.dateNaissance;
            result.lieuNaissance = admin.lieuNaissance;
            result.Tache = admin.Tache;
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

    Task<IEnumerable<Administrateur>> IAdminRepository.GetAdministrateur()
    {
        throw new NotImplementedException();
    }

    Task<Administrateur> IAdminRepository.GetAdminById(int adminId)
    {
        throw new NotImplementedException();
    }
}
