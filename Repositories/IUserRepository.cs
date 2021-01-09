using System.Collections.Generic;
using System.Threading.Tasks;
using toDoApp.Models;

namespace toDoApp.Repositories
{
    public interface IUserRepository
    {
        Task<int> RegisterAsync(User user, string password);
        Task<string> LoginAsync(string username, string password);
        Task<bool> UserExistsAsync(string username);
    }
}