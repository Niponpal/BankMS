using BankMS.Models;

namespace BankMS.Repository;

public interface ILoanRepository
{
    Task<IEnumerable<Loan>> GetAllLoanAsync();
    Task<Loan> GetLoantByIdAsync(int id);
    Task<Loan> GeLoantAddAsynce(Loan  loan);
    Task<Loan> GetLoanUpdateAsync(Loan loan);
    Task<Loan> GetLoanDeleteAsync(int id);
}
