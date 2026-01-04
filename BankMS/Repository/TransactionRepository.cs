using BankMS.Data;
using BankMS.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BankMS.Repository;

public class TransactionRepository : ITransactionRepository
{
    private readonly ApplicationDbContext _context;

    public TransactionRepository (ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Transaction> GetAddTransactionAsynce(Transaction transaction)
    {
        await _context.AddAsync(transaction);
        await _context.SaveChangesAsync();
        return transaction;
    }

    public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
    {
       var data = await _context.Transactions.ToListAsync();
        if (data != null)
        {
            return data;
        }
        return null;
    }

    public async Task<Transaction> GetDeleteTransactionAsync(int id)
    {
       var data = await _context.Transactions.FindAsync(id);
        if (data != null)
        {
            _context.Remove(data);
           await _context.SaveChangesAsync();
        }
        return null;
    }

    public async Task<Transaction> GetTransactionByIdAsync(int id)
    {
        var data = await _context.Transactions.FindAsync(id);
        if (data != null)
        {
            return data;
        }
        return null;
    }

    public async Task<Transaction> GetUpdateTransactionAsync(Transaction transaction)
    {
       var data = await _context.Transactions.FindAsync(transaction.Id);
        if (data != null)
        {
            data.TransactionDate = transaction.TransactionDate;
            data.TransactionType = transaction.TransactionType;
            data.Amount = transaction.Amount;
            data.AccountId = transaction.AccountId;
            data.Reference = transaction.Reference;
            await _context.SaveChangesAsync();
            return data;
        }
        return null!;
    }
}
