using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArvidsBank.Models.Transaction;
using ArvidsBank.Models.Transfer;
using ArvidsBowling.Data;
using Microsoft.AspNetCore.Mvc;

namespace ArvidsBank.Controllers
{
    public class TransferController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Transfer(TransferVM model)
        {
            var repo = BankRepository.Instance();

            if (ModelState.IsValid)
            {
                try
                {
                    var fromAccount = repo.GetAccount(model.fromAccountNumber);
                    var recievingAccount = repo.GetAccount(model.recievingAccountNumber);

                    repo.Transfer(fromAccount,recievingAccount,model.Amount);

                    //var accountVm = AccountVM.Create(account);
                    var transferVM = new TransferVM();
                    transferVM.FromAccount = AccountVM.Create(fromAccount);
                    transferVM.RecievingAccount = AccountVM.Create(recievingAccount);
                    return View("TransferSuccess", transferVM);
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