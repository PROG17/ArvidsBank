namespace ArvidsBowling.Data
{
    public class Account
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string AccountNr { get; set; }
        public decimal Balance { get; set; }

        public void TransferBetweenAccounts(int targetAccount, decimal amount)
        {

        }
    }
}
