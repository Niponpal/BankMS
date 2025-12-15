namespace BankMS.Models;

public class Loan
{
    public int Id { get; set; }
    public string LoanType { get; set; }
    public decimal LoanAmount { get; set; }
    public double InterestRate { get; set; }
    public int DurationMonths { get; set; }
    public string LoanStatus { get; set; }
    public DateTime AppliedDate { get; set; }

}
