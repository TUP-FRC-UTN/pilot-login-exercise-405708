using Microsoft.EntityFrameworkCore;
using PilotoWebAPI.Dtos;
using PilotoWebAPI.Models;
using PilotoWebAPI.Repositories.IRepositories;

namespace PilotoWebAPI.Repositories
{
    public class PilotoRepository : IPilotoRepository
    {
        private readonly PilotLoginContext _DbContext;

        public PilotoRepository(PilotLoginContext pilotLoginContext)
        {
            _DbContext = pilotLoginContext;
        }

        public async Task<Piloto> AddPiloto(Piloto piloto)
        {
            _DbContext.Add(piloto);
            await _DbContext.SaveChangesAsync();
            return piloto;
        }

        public async Task<Piloto> GetPilotoById(int idPiloto)
        {
            var piloto = await _DbContext.Pilotos.FirstOrDefaultAsync(x => x.IdPiloto == idPiloto);
            if (piloto == null) {
                throw new Exception();
            }
            return piloto;
        }

        public async Task<List<Piloto>> GetPilotosByEmail(string email)
        {
            return await _DbContext.Pilotos
                                    .Include(p => p.PaisNavigation)
                                    .Where(p => p.Email == email)
                                    .ToListAsync();
        }

        public async Task<Piloto> UpdatePiloto(PilotoDtoUpdate pilotoDtoUpdate)
        {
            var entity = await _DbContext.Pilotos.FirstOrDefaultAsync(x => x.IdPiloto == pilotoDtoUpdate.Id);
            entity.IdPiloto = pilotoDtoUpdate.Id;
            entity.Nombre = pilotoDtoUpdate.Nombre;
            entity.CantHrVuelo = pilotoDtoUpdate.cant_hrs_vuelo;
            entity.Pais = pilotoDtoUpdate.idPais;
            entity.Email = pilotoDtoUpdate.Email;
            _DbContext.Update(entity);
            await _DbContext.SaveChangesAsync();
            
            return entity;
        }
    }
}
