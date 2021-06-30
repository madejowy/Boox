using Boox.Models;
using Boox.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Boox.Controllers
{
    public class AccountController : Controller
    {
        private readonly BooxContext _context;
        public AccountController(BooxContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            var account = new Account
            {
                Username = viewModel.Username.ToString(),
                Password = viewModel.Password.ToString(),
                AccountType = AccountType.StandardUser
            };

            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, GetPrincipal(account));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Username == viewModel.Username);
            if (account is null)
            {
                return RedirectToAction("Index","Home");
            }
            if (account.Password == viewModel.Password)
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, GetPrincipal(account));
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
                
            
        }
        public async Task<Account> GetAccountFromLogin(LoginViewModel viewModel)
        {
            var account = await _context.Accounts
                .SingleOrDefaultAsync(x => x.Username == viewModel.Username);
            return account;
        }

 

        public static ClaimsPrincipal GetPrincipal(Account account)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, account.Username),
                new Claim(ClaimTypes.Role, account.AccountType.ToString())
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            return new ClaimsPrincipal(identity);
        }
    }
}
