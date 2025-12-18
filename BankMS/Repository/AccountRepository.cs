using BankMS.Data;
using BankMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BankMS.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly ApplicationDbContext _context;
    public AccountRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Account> GetAccountByIdAsync(int accountId)
    {
       var data = await _context.Accounts.FindAsync(accountId);
        if (data == null)
        {
            return null;
        }
        return data;
    }

    public async Task<Account> GetAddAsynce(Account account)
    {
        await _context.Accounts.AddAsync(account);
        await  _context.SaveChangesAsync();
        return account;
    }

    public async Task<IEnumerable<Account>> GetAllAccountsAsync()
    {
       var data = await _context.Accounts.ToListAsync();
        if (data != null)
        {
            return data;
        }
        return null;
    }

    public async Task<Account> GetDeleteAsync(int id)
    {
        var data = await _context.Accounts.FindAsync(id);
        if(data != null)
        {
            _context.Accounts.Remove(data);
            await _context.SaveChangesAsync();
            return data;
        }
        return null;
    }

    public async Task<Account> GetUpdateAsync(Account account)
    {
        var data = await _context.Accounts.FindAsync(account.Id);
        if(data != null)
        {
            data.AccountNumber = account.AccountNumber;
            data.AccountType = account.AccountType;
            data.Balance = account.Balance;
            data.Status = account.Status;
            await _context.SaveChangesAsync();
            return data;
        }
        return null;
    }
}
