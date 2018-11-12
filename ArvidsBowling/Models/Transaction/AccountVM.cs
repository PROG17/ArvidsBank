using System.ComponentModel.DataAnnotations;
using ArvidsBowling.Data;

namespace ArvidsBank.Models.Transaction
{
    public class AccountVM
    {
        [Display(Name = "Kontonummer")]
        public string AccountNr { get; set; }

        [Display(Name = "Saldo")]
        public decimal Amount { get; set; }

        public static AccountVM Create(Account account)
        {
            return new AccountVM
            {
                AccountNr = account.AccountNr,
                Amount = account.Balance
            };
        }
    }
}
