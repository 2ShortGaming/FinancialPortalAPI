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
    /// This is the Budget controller for the financial portal
    /// </summary>
    public class BudgetsController : ApiController
    {
        private APIDbContext db = new APIDbContext();

        //=========================Get All Budget Data==========================//
        /// <summary>
        /// Returns all budget data
        /// </summary>
        /// <returns>Returns all budget data</returns>
        [Route("GetAllBudgetData")]
        public async Task<List<Budget>> GetAllBudgetData()
        {
            return await db.GetAllBudgetData();
        }

        //===================Get Budget Data by Id======================//
        /// <summary>
        /// Returns budget data for a single account
        /// </summary>
        /// <param name="id">FK for the budget</param>
        /// <returns>Returns budget data for a single account</returns>
        [Route("GetBankBudgetDataById")]
        public async Task<Budget> GetBudgetDataById(int id)
        {
            return await db.GetBudgetDataById(id);
        }

        //===========================Delete============================//
        /// <summary>
        /// Delete a single budget
        /// </summary>
        /// <param name="id">The PK of the budget</param>
        /// <returns>Delete a single budget by Id</returns>
        [Route("DeleteBudgetDataById")]
        [HttpDelete]
        public int DeleteBudgetData(int id)
        {
            return db.DeleteBudgetDataById(id);
        }

        //================================Create==================================//
        /// <summary>
        /// Create a single budget
        /// </summary>
        /// <param name="hId">The PK for the budget</param>
        /// <param name="owner">The owner of the account</param>
        /// <param name="budgetName">The name of the budget</param>
        /// <param name="currentAmount">The current amount the user inputs</param>
        /// <returns>Create a single budget</returns>
        [Route("InsertBudgetData")]
        public int InsertBudgetData(int hId, string owner, string budgetName, decimal currentAmount)
        {
            return db.InsertBudgetData(hId, owner, budgetName, currentAmount);
        }

        //=======================Update============================//
        /// <summary>
        /// Create a single budget
        /// </summary>
        /// <param name="hId">The PK for the budget</param>
        /// <param name="owner">The owner of the account</param>
        /// <param name="budgetName">The name of the budget</param>
        /// <param name="currentAmount">The current amount the user inputs</param>
        /// <returns>Create a single budget</returns>
        public int UpdateBudgetDataById(int hId, string owner, string budgetName, decimal currentAmount)
        {
            return db.UpdateBudgetDataById(hId, owner, budgetName, currentAmount);
        }
    }
}
