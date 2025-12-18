using BankMS.Models;

namespace BankMS.Repository;

public interface IAccountRepository
{
    Task<IEnumerable<Account>> GetAllAccountsAsync();
    Task<Account> GetAccountByIdAsync(int accountId);
    Task<Account> GetAddAsynce(Account account);
    Task<Account> GetUpdateAsync(Account account);
    Task<Account> GetDeleteAsync(int id);
}
