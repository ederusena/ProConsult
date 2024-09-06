using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Dockets;

public class DocketRepository : IDocketRepository
{
    private readonly ApplicationDbContext _context;

    public DocketRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Docket docket)
    {
        _context.Dockets.Add(docket);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var docket = await GetByIdAsync(id);
        if (docket != null)
        {
            _context.Dockets.Remove(docket);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Docket>> GetAllAsync()
    {
        return await _context
            .Dockets
            .Include(x => x.Patient)
            .Include(x => x.Doctor)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Docket?> GetByIdAsync(int id)
    {
        return await _context
            .Dockets
            .Include(x => x.Patient)
            .Include(x => x.Doctor)
            .SingleOrDefaultAsync(d => d.Id == id);
    }
}