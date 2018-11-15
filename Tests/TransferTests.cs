using System;
using System.Collections.Generic;
using System.Text;
using ArvidsBowling.Data;
using Xunit;

namespace Tests
{
    public class TransferTests
    {
        [Fact]
        public void CorrectAmountTransfered()
        {
            var repo = BankRepository.Instance();
            var fromAccount = repo.Accounts[0];
            var recievingAccount = repo.Accounts[1];

            decimal transfer = 100;
            var expectedFrom = 900;
            var expetedTo = 90100;
            repo.Transfer(fromAccount,recievingAccount,100);
            Assert.Equal(expectedFrom, fromAccount.Balance);
            Assert.Equal(expetedTo, recievingAccount.Balance);
        }

        [Fact]
        public void WithdrawlInsufficientFunds()
        {
            var repo = BankRepository.Instance();
            var fromAccount = repo.Accounts[0];
            var recievingAccount = repo.Accounts[1];

            decimal withdraw = 10000000;
            decimal expected = fromAccount.Balance;
            Assert.Throws<Exception>(() => repo.Transfer(fromAccount, recievingAccount, withdraw));
            Assert.Equal(expected, fromAccount.Balance);
        }
    }
}
