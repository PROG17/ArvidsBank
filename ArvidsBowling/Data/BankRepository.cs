using System.Collections.Generic;

namespace ArvidsBowling.Data
{
    public class BankRepository
    {
        private static BankRepository _instance;
        private static IList<Customer> _customers;
        private static IList<Account> _accounts;

        private BankRepository()
        {
            _customers = new List<Customer>
            {
                new Customer { Id = 1, FirstName = "Arvid", LastName = "Zetterberg" },
                new Customer { Id = 2, FirstName = "Victor", LastName = "Hermansson" },
                new Customer { Id = 3, FirstName = "Gustaw", LastName = "Westberg" }
            };

            _accounts = new List<Account>
            {
                new Account { Id = 1, CustomerId = 1, Balance = 1000, AccountNr = "11-1"},
                new Account { Id = 2, CustomerId = 2, Balance = 90000, AccountNr = "11-2"},
                new Account { Id = 3, CustomerId = 3, Balance = 22000, AccountNr = "11-3"},
                new Account { Id = 4, CustomerId = 3, Balance = 123_000_000, AccountNr = "99-Vip-1"},
            };
        }

        public static BankRepository Instance()
        {
            _instance = _instance ?? new BankRepository();
            return _instance;
        }

        public IList<Account> Accounts { get => _accounts; }
        public IList<Customer> Customers { get => _customers; }
    }
}
