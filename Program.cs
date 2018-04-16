using Transactions.DataContext;
using Transactions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddTransaction(12345);
            //AddTransaction(12345);


            var transactions = FindTransactionsFromToday();

            Console.WriteLine("Printing transactions for today");

            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction.AccountNumber + " - " + transaction.Action + " - " + transaction.AmountChanged);
            }

            transactions = TenMostRecent(12345);

            Console.WriteLine("Printing 10 most recent transactions");

            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction.AccountNumber + " - " + transaction.Action + " - " + transaction.AmountChanged);
            }

            transactions = TransactionsForDay(12345, new DateTime(2018, 4, 16));

            Console.WriteLine("Printing transactions for 4/16");

            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction.AccountNumber + " - " + transaction.Action + " - " + transaction.AmountChanged);
            }

            Console.Read();
        }

        private static void AddTransaction(int accountNumber)
        {
            var db = new TransactionContext();

            var transaction = new Transaction
            {
                Timestamp = new DateTime(2018, 4, 16),
                Action = "Deposit",
                AccountNumber = accountNumber,
                AmountChanged = 100.00m,
                NewAmount = 150.00m
            };

            db.Transactions.Add(transaction);

            db.SaveChanges();
        }

        private static List<Transaction> FindTransactionsFromToday()
        {
            var db = new TransactionContext();

            return db.Transactions.Where(t => t.Timestamp >= DateTime.Today).ToList();
        }

        private static List<Transaction> TenMostRecent(int accountNumber)
        {
            var db = new TransactionContext();

            return db.Transactions.Where(t => t.AccountNumber == accountNumber).OrderByDescending(t => t.Timestamp).Take(10).ToList();
        }

        private static List<Transaction> TransactionsForDay(int accountnumber, DateTime date)
        {
            var db = new TransactionContext();

            return db.Transactions.ToList().Where(t => t.AccountNumber == accountnumber && Convert.ToDateTime(t.Timestamp).Date == date.Date).OrderBy(t => t.Timestamp).ToList();
        }
    }
}
