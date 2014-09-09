using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMSystem.Model;

namespace ATMSystem.Data
{
    public static class CardAccountService
    {
        private static string connection;
        public static decimal WithdrawCash(string cardNumber, string cardPin, decimal money, string connectionString)
        {
            connection = connectionString;
            try
            {
                if (ValidateCard(cardNumber, cardPin))
                {
                    var ctx = new ATMSystemDbContext(connection);
                    using (ctx)
                    {
                        var card = ctx.CardAccounts.FirstOrDefault(a => a.CardNumber == cardNumber && a.CardPIN == cardPin);
                        if (AmountCheck(card.CardCash, money))
                        {
                            card.CardCash = card.CardCash - money;
                            ctx.SaveChanges();
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    return money;
                }
                throw new ArgumentException("Invalid credentials, please try again!");
            }
            catch (ArgumentException ex)
            {
                throw new Exception("Withdrawal failed! - " + ex.Message);
            }
        }

        public static decimal CashCheck(string cardNumber, string cardPin, string connectionString)
        {
            var money = 0m;
            connection = connectionString;
            try
            {
                if (ValidateCard(cardNumber, cardPin))
                {
                    var ctx = new ATMSystemDbContext(connection);
                    using (ctx)
                    {
                        var card = ctx.CardAccounts.FirstOrDefault(a => a.CardNumber == cardNumber && a.CardPIN == cardPin); 
                            money = card.CardCash;
                            ctx.SaveChanges();
                    }
                    return money;
                }
                throw new ArgumentException("Invalid credentials, please try again!");
            }
            catch (ArgumentException ex)
            {
                throw new Exception("Cash checking failed! - " + ex.Message);
            }
        }

        private static bool ValidateCard(string cardNumber, string cardPin)
        {
            var ctx = new ATMSystemDbContext(connection);
            using (ctx)
            {
                var card = ctx.CardAccounts.FirstOrDefault(a => a.CardNumber == cardNumber && a.CardPIN == cardPin);
                if (card == null)
                {
                    return false;
                }
                return true;
            }
        }

        private static bool AmountCheck(decimal amount, decimal money)
        {
            if (money <= 0)
            {
                throw new ArgumentException("Invalid money amount!");
            }
            else if (amount < money)
            {
                throw new ArgumentException("Insufficient amount of cash in account");
            }
            else return true;
        }

        public static int AddSampleData(string connectionString)
        {
            using (var ctx = new ATMSystemDbContext())
            {
                for (int i = 0; i < 15; i++)
                {
                    var account = new CardAccount
                    {
                        CardNumber = (1000000000 + i).ToString(),
                        CardPIN = (1000 + i).ToString(),
                        CardCash = i * 100
                    };
                    ctx.CardAccounts.Add(account);
                }
                var changesResult = ctx.SaveChanges();
                return changesResult;
            }
        }
    }
}

