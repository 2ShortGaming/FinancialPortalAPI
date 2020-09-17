using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialPortalAPI.Models
{
    /// <summary>
    /// The model of Budget Item for the financial portal
    /// </summary>
    public class BudgetItem
    {
        /// <summary>
        /// the FK for the budget item
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The PK of the budget the item is tied to
        /// </summary>
        public int BudgetId { get; set; }
        /// <summary>
        /// The time the budget item was created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// The item name of the budget item
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// The target amount to spend on the item
        /// </summary>
        public decimal TargetAmount { get; set; }
        /// <summary>
        /// The current amount spent on the item
        /// </summary>
        public decimal CurrentAmount { get; set; }
        /// <summary>
        /// Soft delete boolean value
        /// </summary>
        public bool IsDeleted { get; set; }

    }
}