using PilotoWebAPI.Models;

namespace PilotoWebAPI.Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAndPassword(string email, string password);
    }
}
