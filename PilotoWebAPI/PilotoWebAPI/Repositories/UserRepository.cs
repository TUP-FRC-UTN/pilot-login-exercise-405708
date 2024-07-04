using Microsoft.EntityFrameworkCore;
using PilotoWebAPI.Models;
using PilotoWebAPI.Repositories.IRepositories;

namespace PilotoWebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly PilotLoginContext _DbContext;

        public UserRepository(PilotLoginContext pilotLoginContext)
        {
            _DbContext = pilotLoginContext;
        }

        public async Task<User> GetUserByEmailAndPassword(string email, string password)
        {
            var entity = await _DbContext.Users.FirstOrDefaultAsync(us =>
            us.UserEmail == email && us.Password == password);

            if (entity == null)
            {
                return null;
            }
            return entity;
        }
    }
}
