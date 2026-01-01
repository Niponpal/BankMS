using BankMS.Data;
using BankMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BankMS.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<User> GetAddUserAsynce(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<IEnumerable<User>> GetAllUserAsync()
    {
       var data = await _context.Users.ToListAsync();
        if(data != null)
        {
            return data;
        }
        return null;
    }

    public async Task<User> GetDeleteUserAsync(int id)
    {
        var users = await _context.Users.FindAsync(id);
        if (users != null)
        {
            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            return users;
        }
        return null;
    }

    public async Task<User> GetUpdateUserAsync(User user)
    {
       var users = await _context.Users.FindAsync(user.Id);
        if(users != null)
        {
            users.FullName = user.FullName;
            users.Email = user.Email;
            users.PhoneNumber = user.PhoneNumber;
            users.PasswordHash = user.PasswordHash;
            users.Role = user.Role;
            users.IsActive = user.IsActive;
            await _context.SaveChangesAsync();
            return users;
        }
        return null;
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
       var users = await _context.Users.FindAsync(id);
        if(users != null)
        {
            return users;
        }
        return null;
    }
}
