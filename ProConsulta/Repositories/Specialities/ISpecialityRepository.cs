using ProConsulta.Models;

namespace ProConsulta.Repositories.Specialities
{
    public interface ISpecialityRepository
    {
        Task<List<Speciality>> GetAllAsync();
    }
}
