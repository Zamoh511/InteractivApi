using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InteractiveAssesment_API.Models
{
    public class Transactions
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int PersonId { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public TransactionType StatementType { get; set; }

    }
    public enum TransactionType
    {
        Transact,
        Delete,
        SelectById
    }
}