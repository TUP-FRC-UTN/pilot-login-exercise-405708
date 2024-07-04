using PilotoWebAPI.Dtos;
using PilotoWebAPI.Models;

namespace PilotoWebAPI.Repositories.IRepositories
{
    public interface IPilotoRepository
    {
        Task<Piloto> AddPiloto(Piloto piloto);
        Task<Piloto> GetPilotoById(int idPiloto);
        Task<Piloto> UpdatePiloto(PilotoDtoUpdate pilotoDtoUpdate);
        Task<List<Piloto>> GetPilotosByEmail(string email);
    }
}
