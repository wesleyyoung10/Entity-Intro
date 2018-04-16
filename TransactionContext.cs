using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Models;


namespace Transactions.DataContext
{
    class TransactionContext : DbContext
    {

        public TransactionContext() : base(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=BankAccnt;Integrated Security=True")
        {

        }

        public DbSet<Transaction> Transactions { get; set; }

    }
}