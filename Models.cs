using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Models
{
    class Transaction
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public int AccountNumber { get; set; }
        public string Action { get; set; }
        public decimal AmountChanged { get; set; }
        public decimal NewAmount { get; set; }
    }
}
