using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Specialities;

public class SpecialityRepository : ISpecialityRepository
{
    private readonly ApplicationDbContext _context;

    public SpecialityRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Speciality>> GetAllAsync()
    {
        return await _context.Speciality.AsNoTracking().ToListAsync();
    }
}