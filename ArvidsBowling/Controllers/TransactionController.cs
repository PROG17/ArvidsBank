using System;
using ArvidsBank.Models.Transaction;
using ArvidsBowling.Data;
using Microsoft.AspNetCore.Mvc;

namespace ArvidsBank.Controllers
{
    public class TransactionController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Withdraw(TransactionVM model)
        {
            var repo = BankRepository.Instance();

            if (ModelState.IsValid)
            {
                try
                {
                    var account = repo.GetAccount(model.AccountNum);
                    repo.Withdrawal(account, model.Amount);

                    var accountVm = AccountVM.Create(account);
                    return View("TransactionSuccess", accountVm);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return View("Index", model);

        }

        public IActionResult Deposit(TransactionVM model)
        {
            var repo = BankRepository.Instance();

            if (ModelState.IsValid)
            {
                try
                {
                    var account = repo.GetAccount(model.AccountNum);
                    repo.Deposit(account, model.Amount);

                    var accountVM = AccountVM.Create(account);
                    return View("TransactionSuccess", accountVM);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return View("Index", model);
        }
    }
}