using BankMS.Models;

namespace BankMS.Repository;

public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
    Task<Transaction> GetTransactionByIdAsync(int id);
    Task<Transaction> GetAddTransactionAsynce(Transaction  transaction);
    Task<Transaction> GetUpdateTransactionAsync(Transaction  transaction);
    Task<Transaction> GetDeleteTransactionAsync(int id);
}
