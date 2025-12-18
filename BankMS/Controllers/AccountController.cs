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

}
