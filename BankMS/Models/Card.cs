namespace BankMS.Models;

public class Card
{
    public int Id { get; set; }
    public string CardNumber { get; set; }
    public string CardType { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string CardStatus { get; set; }

}
