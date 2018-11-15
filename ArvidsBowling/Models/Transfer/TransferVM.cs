using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ArvidsBank.Models.Transaction;

namespace ArvidsBank.Models.Transfer
{
    public class TransferVM
    {
        [Display(Name = "Belopp")]
        public decimal Amount { get; set; }

        [Display(Name = "Från konto")]
        [Required(ErrorMessage = "Kontonummer måste anges")]
        public string fromAccountNumber { get; set; }

        [Display(Name = "Till konto")]
        [Required(ErrorMessage = "Kontonummer måste anges")]
        public string recievingAccountNumber { get; set; }



        public AccountVM FromAccount { get; set; }
        public AccountVM RecievingAccount { get; set; }
    }
}
