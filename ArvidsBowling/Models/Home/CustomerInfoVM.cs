using ArvidsBowling.Data;
using System.Collections.Generic;

namespace ArvidsBowling.Models.Home
{
    public class CustomerInfoVM
    {
        public Customer Customer { get; set; }
        public IList<Account> Accounts { get; set; }

        public CustomerInfoVM()
        {
            Accounts = new List<Account>();
        }
    }
}
