using Boox.Models;
using Boox.ViewModels.Account;

namespace CQuerMVC.Models
{
    public class RegisterStandardUserViewModel : RegisterViewModel
    {
        public new AccountType AccountType { get; } = AccountType.StandardUser;
    }
}