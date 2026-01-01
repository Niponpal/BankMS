using BankMS.Models;

namespace BankMS.Repository;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUserAsync();
    Task<User> GetUserByIdAsync(int id);
    Task<User> GetAddUserAsynce(User user);
    Task<User> GetUpdateUserAsync(User  user);
    Task<User> GetDeleteUserAsync(int id);
}
