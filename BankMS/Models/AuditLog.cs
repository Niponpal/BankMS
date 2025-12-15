namespace BankMS.Models;

public class AuditLog
{
    public int Id { get; set; }
    public string Action { get; set; }
    public DateTime LogDate { get; set; }

}
