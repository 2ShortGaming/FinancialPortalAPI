using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialPortalAPI.Models
{
    /// <summary>
    /// The model of the Budget for household in the financial portal
    /// </summary>
    public class Budget
    {
        /// <summary>
        /// The FK for the Budget
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The PK of the household
        /// </summary>
        public int HouseholdId { get; set; }
        /// <summary>
        /// The Owner of the bank account
        /// </summary>
        public string OwnerId { get; set; }
        /// <summary>
        /// The time the bank account was created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// The name of the budget
        /// </summary>
        public string BudgetName { get; set; }

        //this is how much the user spent in this category
      /// <summary>
      /// The amount the user spent in this category 
      /// </summary>
        public decimal CurrentAmount { get; set; }
        /// <summary>
        /// The projected total of the category for the month based on the budget items
        /// </summary>
        public decimal TargetAmount { get; }

        // this is the projected total of this cat for the month based on the budget items
       
        //public decimal TargetAmount
        //{
        //    get
        //    {
        //        var target = db.BudgetItems.Where(bI => bI.BudgetId == Id).Count();
        //        return target != 0 ? db.BudgetItems.Where(bI => bI.BudgetId == Id).Sum(s => s.TargetAmount) : 0;
        //    }
        //}

    

    }
}