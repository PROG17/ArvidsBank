using System;
using System.ComponentModel.DataAnnotations;

namespace ArvidsBank.Models.Transaction
{
    public class TransactionVM
    {
        [Display(Name = "Belopp")]
        public decimal Amount { get; set; }

        [Display(Name = "Kontonummer")]
        [Required(ErrorMessage = "Kontonummer måste anges")]
        public string AccountNum { get; set; }
    }
}
