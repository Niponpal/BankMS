using BankMS.Data;
using BankMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BankMS.Repository;

public class LoanRepository : ILoanRepository
{
    private readonly ApplicationDbContext _context;
    public LoanRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Loan> GeLoantAddAsynce(Loan loan)
    {
        await _context.Loans.AddAsync(loan);
        await  _context.SaveChangesAsync();
        return loan;
    }

    public async Task<IEnumerable<Loan>> GetAllLoanAsync()
    {
       var data =await _context.Loans.ToListAsync();
         return data;
    }

    public async Task<Loan> GetLoanDeleteAsync(int id)
    {
       var data = await _context.Loans.FindAsync(id);
        if (data != null)
        {
            _context.Loans.Remove(data);
            await _context.SaveChangesAsync();
        }
        return data;
    }

    public async Task<Loan> GetLoantByIdAsync(int id)
    {
        var data = await _context.Loans.FindAsync(id);
        return data;
    }

    public async Task<Loan> GetLoanUpdateAsync(Loan loan)
    {
       var data = await _context.Loans.FindAsync(loan.Id);
        if (data != null)
        {
            data.LoanType = loan.LoanType;
            data.LoanAmount = loan.LoanAmount;
            data.InterestRate = loan.InterestRate;
            data.DurationMonths = loan.DurationMonths;
            data.LoanStatus = loan.LoanStatus;
            data.AppliedDate = loan.AppliedDate;
            await _context.SaveChangesAsync();
        }
        return data;
    }
}
