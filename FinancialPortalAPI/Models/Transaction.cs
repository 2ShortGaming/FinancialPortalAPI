using FinancialPortalAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialPortalAPI.Models
{
    /// <summary>
    /// The model of Transaction for the financial portal
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// The FK for the Transaction
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The account Id the transaction is tied to
        /// </summary>
        public int AccountId { get; set; }
        /// <summary>
        /// The budget item tied to the transaction
        /// </summary>
        public int? BudgetItemId { get; set; }
        /// <summary>
        /// The owner that created the transaction
        /// </summary>
        public string OwnerId { get; set; }
        /// <summary>
        /// The transaction type for the transaction
        /// </summary>
        public TransactionType TransactionType { get; set; }
        /// <summary>
        /// The time the transaction was created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// The amount for each transaction
        /// </summary>
        public decimal Amount { get; set; }

        //this will be things like McDs, Gas, car payments etc
        /// <summary>
        /// A note for what the transaction was for
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// Soft delete boolean value
        /// </summary>
        public bool IsDeleted { get; set; }



    }
}