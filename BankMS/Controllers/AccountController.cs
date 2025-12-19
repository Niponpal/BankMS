using BankMS.Models;
using BankMS.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankMS.Controllers;

public class AccountController : Controller
{
    private readonly IAccountRepository _accountRepository;
    public AccountController(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<IActionResult> Index()
    {  var data = await _accountRepository.GetAllAccountsAsync();
        return View(data);
    }

    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(int? id)
    {
        if (id == null || id == 0)
        {
            // Create new account
            var newAccount = new Account
            {
                Status = "Active", // Default status
                CreatedDate = DateTime.Now
            };
            return View(newAccount);
        }
        else
        {
            // Edit existing account
            var account = await _accountRepository.GetAccountByIdAsync(id.Value);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateOrEdit(Account account)
    {
        if (ModelState.IsValid)
        {
            try
            {
                if (account.Id == 0)
                {
                    // Create new account
                    await _accountRepository.GetAddAsynce(account);
                    TempData["SuccessMessage"] = "Account created successfully!";
                    TempData["MessageType"] = "success";
                }
                else
                {
                    // Update existing account
                    await _accountRepository.GetUpdateAsync(account);
                    TempData["SuccessMessage"] = "Account updated successfully!";
                    TempData["MessageType"] = "info";
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Log error here
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                TempData["ErrorMessage"] = "An error occurred while saving the account.";
                TempData["MessageType"] = "error";
            }
        }

        // If we got this far, something failed
        return View(account);
    }


}
