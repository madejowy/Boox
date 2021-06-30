using Boox.Models;
using Boox.ViewModels.Account;


namespace CQuerMVC.Models
{
    public class RegisterAdminViewModel : RegisterViewModel
    {
        public new AccountType AccountType { get; set; } = AccountType.Administrator;
    }
}