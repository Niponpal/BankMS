using BankMS.Models;
using BankMS.Repository;
using Microsoft.AspNetCore.Mvc;
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
    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(int id) { 
        if (id == 0)
        {
          return View(new Transaction());
        }
        else
        {
            var data = await _transactionRepository.GetTransactionByIdAsync(id);
            return View(data);
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(Transaction transaction)
    {
        if (transaction.Id == 0)
        {
            await _transactionRepository.GetAddTransactionAsynce(transaction);
            return RedirectToAction("Index");
        }
        else
        {
            await _transactionRepository.GetUpdateTransactionAsync(transaction);
            return RedirectToAction("Index");
        }
    }
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var data = await _transactionRepository.GetTransactionByIdAsync(id);
          if(data != null)
        {
            return View(data);
        }
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await _transactionRepository.GetDeleteTransactionAsync(id);
        
            return RedirectToAction("Index");
        
        
    }
}
