using BankMS.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankMS.Controllers;

public class TransactionController : Controller
{
    private readonly ITransactionRepository _transactionRepository;
    public TransactionController(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }
    public async Task<IActionResult> Index()
    {
        var data= await _transactionRepository.GetAllTransactionsAsync();
        return View(data);
    }

}
