using System.Collections.Generic;
using System.Threading.Tasks;
using usuario_sis.Models;

namespace usuario_sis.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
        Task<bool> SaveAsync();
    }
}