using Microsoft.EntityFrameworkCore;
using PilotoWebAPI.Models;
using PilotoWebAPI.Repositories.IRepositories;

namespace PilotoWebAPI.Repositories
{
    public class PaisRepository : IPaisRepository
    {
        private readonly PilotLoginContext _DbContext;

        public PaisRepository(PilotLoginContext pilotLoginContext)
        {
            _DbContext = pilotLoginContext;
        }

        public async Task<List<Paise>> GetAllPais()
        {
            return await _DbContext.Paises.ToListAsync();
        }
    }
}
