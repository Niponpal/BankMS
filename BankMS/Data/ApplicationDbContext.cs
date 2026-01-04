using BankMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BankMS.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {

    }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<FundTransfer> FundTransfers { get; set; }  
    public DbSet<Loan> Loans { get; set; }
    public DbSet<Transaction> Transactions { get; set; }    
   
}
