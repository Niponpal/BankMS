namespace BankMS.Models;

public class Account
{
    public int Id { get; set; }
    public string AccountNumber { get; set; }
    public string AccountType { get; set; }
    public decimal Balance { get; set; }
    public string Status { get; set; }
    public DateTime CreatedDate { get; set; }

}
