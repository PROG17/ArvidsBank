using ArvidsBowling.Data;
using ArvidsBowling.Models;
using ArvidsBowling.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ArvidsBowling.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new List<CustomerInfoVM>();
            var repo = BankRepository.Instance();
            var accounts = repo.Accounts;

            foreach (var customer in repo.Customers)
            {
                var customerAccounts = accounts.Where(a => a.CustomerId == customer.Id).ToList();
                model.Add(new CustomerInfoVM() { Customer = customer, Accounts = customerAccounts });
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
