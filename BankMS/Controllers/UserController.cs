using BankMS.Models;
using BankMS.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankMS.Controllers; 

public class UserController : Controller
{
    private readonly IUserRepository _userRepository;
    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<IActionResult> Index()
    {
        var data = await _userRepository.GetAllUserAsync();
        return View(data);
    }
    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(int id)
    {
        if (id == 0)
        {
            return View(new User());
        }
        else
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user != null)
            {
                return View(user);
               
            }
            return NotFound();
        }

    }
    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(int id, User user)
    {
            if (id == 0)
            {
                await _userRepository.GetAddUserAsynce(user);
            return RedirectToAction(nameof(Index));
            }
            else
            {
                await _userRepository.GetUpdateUserAsync(user);
              return RedirectToAction(nameof(Index));
            }
    }
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        if (user != null)
        {
            return View(user);
        }
        return NotFound();

    }
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _userRepository.GetDeleteUserAsync(id);
        if (user != null)
        {
            return RedirectToAction("Index");
        }
        return NotFound();
    }
}
