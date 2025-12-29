using BankMS.Models;
using BankMS.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankMS.Controllers;

public class LoanController : Controller
{
    private readonly ILoanRepository _loanRepository;
    public LoanController(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }
    public async Task<IActionResult> Index()
    {
        var data = await _loanRepository.GetAllLoanAsync();
        return View(data);
    }
    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(int id) { 
        if (id == 0)
        {
            return View(new Models.Loan());
        }
        else
        {
            var data = await _loanRepository.GetLoantByIdAsync(id);
            return View(data);
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(Loan loan)
    {
        if (loan.Id == 0)
        {
            await _loanRepository.GeLoantAddAsynce(loan);
            return RedirectToAction("Index");
        }
        else
        {
            await _loanRepository.GetLoanUpdateAsync(loan);
            return RedirectToAction("Index");
        }
       
    }
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await _loanRepository.GetLoanDeleteAsync(id);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var data = await _loanRepository.GetLoantByIdAsync(id);
        return View(data);
    }
}
