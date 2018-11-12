using System;
using ArvidsBowling.Data;
using Xunit;

namespace Tests
{
    public class TransactionsTests
    {
        [Fact]
        public void Deposit()
        {
            var repo = BankRepository.Instance();
            var account = repo.Accounts[0];

            decimal deposit = 1000.24m;
            var expected = account.Balance + deposit;

            repo.Deposit(account, deposit);

            Assert.Equal(expected, account.Balance);
        }

        [Fact]
        public void DepositNegativeAmmount()
        {
            var repo = BankRepository.Instance();
            var account = repo.Accounts[0];

            decimal deposit = -21;
            var expected = account.Balance;
            Assert.Throws<ArgumentException>(() => repo.Deposit(account, deposit));
            Assert.Equal(expected, account.Balance);
        }

        [Fact]
        public void Withdrawal()
        {
            var repo = BankRepository.Instance();
            var account = repo.Accounts[0];

            decimal withdraw = 100;
            decimal expected = account.Balance - withdraw;

            repo.Withdrawal(account, withdraw);
            Assert.Equal(expected, account.Balance);
        }

        [Fact]
        public void WithdrawlInsufficientFunds()
        {
            var repo = BankRepository.Instance();
            var account = repo.Accounts[0];

            decimal withdraw = 10000000;
            decimal expected = account.Balance;
            Assert.Throws<Exception>(() => repo.Withdrawal(account, withdraw));
            Assert.Equal(expected, account.Balance);
        }

        [Fact]
        public void WithdrawalNegativeAmmount()
        {
            var repo = BankRepository.Instance();
            var account = repo.Accounts[0];

            decimal withdraw = -21;
            var expected = account.Balance;
            Assert.Throws<ArgumentException>(() => repo.Deposit(account, withdraw));
            Assert.Equal(expected, account.Balance);
        }
    }
}
