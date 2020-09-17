using FinancialPortalAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialPortalAPI.Models
{
    /// <summary>
    /// The model for the Bank Account unit in the financial portal
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// The FK of the Bank account
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The PK of the household
        /// </summary>
        public int? HouseholdId { get; set; }
        /// <summary>
        /// The Owner of the bank account
        /// </summary>
        public string OwnerId { get; set; }
        /// <summary>
        /// The account name of the bank the owner input for their preferred bank
        /// </summary>
        public string AccountName { get; set; }
        /// <summary>
        /// The time the bank account was created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// The input starting balance of the owner's bank account
        /// </summary>
        public decimal StartingBalance { get; internal set; }
        /// <summary>
        /// The current balance of the owner's bank account after any transactions are preformed
        /// </summary>
        public decimal CurrentBalance { get; set; }
        /// <summary>
        /// The warning balance for when the account is getting low on funds
        /// </summary>
        public decimal WarningBalance { get; set; }
        /// <summary>
        /// Soft delete boolean value
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// The account type of the account
        /// </summary>
        public AccountType AccountType { get; set; }
       
    }
}