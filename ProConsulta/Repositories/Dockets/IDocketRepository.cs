using ProConsulta.Models;

namespace ProConsulta.Repositories.Dockets;

public interface IDocketRepository
{
    Task<List<Docket>> GetAllAsync();
    Task AddAsync(Docket docket);
    Task DeleteByIdAsync(int id);
    Task<Docket?> GetByIdAsync(int id);
}