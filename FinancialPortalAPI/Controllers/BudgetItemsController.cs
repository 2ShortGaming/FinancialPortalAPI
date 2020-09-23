using FinancialPortalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FinancialPortalAPI.Controllers
{
    /// <summary>
    /// This is the Budget Item controller for the financial portal
    /// </summary>
    public class BudgetItemsController : ApiController
    {
        private APIDbContext db = new APIDbContext();

        //=========================Get All Budget Item Data==========================//
        /// <summary>
        /// Returns all budget item data
        /// </summary>
        /// <returns>Returns all budget item data</returns>
        [Route("GetAllBudgetItemData")]
        public async Task<List<BudgetItem>> GetAllBudgetItemData()
        {
            return await db.GetAllBudgetItemData();
        }

        //===================Get Budget Item Data by Id======================//
        /// <summary>
        /// Returns budget item data for a single account
        /// </summary>
        /// <param name="id">FK for the budget item</param>
        /// <returns>Returns budget item data for a single account</returns>
        [Route("GetBudgetItemById")]
        public async Task<BudgetItem> GetBudgetItemById(int id)
        {
            return await db.GetBudgetItemById(id);
        }

        //===========================Delete============================//
        /// <summary>
        /// Delete a single budget item
        /// </summary>
        /// <param name="id">The PK of the budget item</param>
        /// <returns>Delete a single budget by Id item</returns>
        [Route("DeleteBudgetItemDataById")]
        [HttpDelete]
        public int DeleteBudgetItemData(int id)
        {
            return db.DeleteBudgetItemDataById(id);
        }

        //================================Create==================================//
        /// <summary>
        /// Create a single budget item
        /// </summary>
        /// <param name="bId">The PK for the budget item</param>
        /// <param name="itemName">The name of the budget item</param>
        /// <param name="targetAmount">Target amount of the budget item</param>
        /// <param name="currentAmount">The current amount the user inputs</param>
        /// <returns>Create a single budget item</returns>
        [Route("InsertBudgetItemData")]
        public int InsertBudgetItemData(int bId, string itemName, decimal targetAmount, decimal currentAmount)
        {
            return db.InsertBudgetItemData(bId, itemName, targetAmount, currentAmount);
        }

        //=======================Update============================//
        /// <summary>
        /// Create a single budget item
        /// </summary>
        /// <param name="bId">The PK for the budget item</param>
        /// <param name="itemName">The name of the budget item</param>
        /// <param name="targetAmount">Target amount of the budget item</param>
        /// <param name="currentAmount">The current amount the user inputs</param>
        /// <returns>Create a single budget item</returns>
        [Route("UpdateBudgetItemDataById")]
        [HttpPut]
        public int UpdateBudgetItemDataById(int bId, string itemName, decimal targetAmount, decimal currentAmount)
        {
            return db.UpdateBudgetItemDataById(bId, itemName, targetAmount, currentAmount);
        }
    }
}
