namespace BankMS.Models;

public class Customer
{
    public int Id { get; set; }
    public string NIDNumber { get; set; }
    public string Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string KYCStatus { get; set; }
}
