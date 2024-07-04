using PilotoWebAPI.Models;

namespace PilotoWebAPI.Repositories.IRepositories
{
    public interface IPaisRepository
    {
        Task<List<Paise>> GetAllPais();
    }
}
