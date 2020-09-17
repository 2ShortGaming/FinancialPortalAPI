using FinancialPortalAPI.Enums;
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
    /// The Bank account controller for the financial portal
    /// </summary>
    [RoutePrefix("api/BankAccounts")]
    public class BankAccountsController : ApiController
    {
        private APIDbContext db = new APIDbContext();

        //=========================Get All Bank Data==========================//
        /// <summary>
        /// Returns all bank account data
        /// </summary>
        /// <returns>Returns all bank account data</returns>
        [Route("GetAllBankData")]
        public async Task<List<BankAccount>> GetAllBankData()
        {
            return await db.GetAllBankData();
        }

        //===================Get Bank Data by Id======================//
        /// <summary>
        /// Returns bank data for a single account
        /// </summary>
        /// <param name="id">FK for the bank account</param>
        /// <returns>Returns bank data for a single account</returns>
         [Route("GetBankDataById")]
         public async Task<BankAccount> GetBankDataById(int id)
        {
            return await db.GetBankDataById(id);
        }

        //===========================Delete============================//
        /// <summary>
        /// Delete a single bank account
        /// </summary>
        /// <param name="id">The PK of the bank account</param>
        /// <returns>Delete a single bank account by Id</returns>
        [Route("DeleteBankDataById")]
        [HttpDelete]
        public int DeleteBankData(int id)
        {
            return db.DeleteBankDataById(id);
        }

        //================================Create==================================//
        /// <summary>
        /// Create a single bank account
        /// </summary>
        /// <param name="hId">The PK for the bank account</param>
        /// <param name="owner">The owner of the account</param>
        /// <param name="name">The name of the account the user provided</param>
        /// <param name="startingBalance">The starting balance the user inputs</param>
        /// <param name="currentBalance">This is the current balance of the account</param>
        /// <param name="warningBalance">This is the warning balance of the account when it gets low on funds</param>
        /// <param name="accountType">This is the account type of the account</param>
        /// <returns>Create a single bank account</returns>
        [Route("InsertBankData")]
        public int InsertBankData(int hId, string owner, string name, decimal startingBalance, decimal currentBalance, decimal warningBalance, AccountType accountType)
        {
            return db.InsertBankData(hId, owner, name, startingBalance, currentBalance, warningBalance, accountType);
        }

        //========================Get Bank and Transaction Data======================//
        /// <summary>
        /// Get all bank and transaction data
        /// </summary>
        /// <param name="id">The FK of the bank to the transaction data</param>
        /// <returns>Returns all bank and transaction data</returns>
        [Route("GetAllBankAndTransactionData")]
        public async Task<List<BankAccount>> GetAllBankAndTransactionData(int id)
        {
            return await db.GetBankAndTransactionData(id);
        }

        //=======================Update============================//
        /// <summary>
        /// Update the bank account information
        /// </summary>
        /// <param name="hId">FK for the bank account</param>
        /// <param name="name">The name of the account the user provided</param>
        /// <param name="owner">The owner of the account</param>
        /// <param name="startingBalance">The starting balance the user inputs</param>
        /// <param name="currentBalance">This is the current balance of the account</param>
        /// <param name="warningBalance">This is the warning balance of the account when it gets low on funds</param>
        /// <param name="accountType">This is the account type of the account</param>
        /// <returns>Update the bank account information</returns>
        public int UpdateBankDataById(int hId, string owner, string name, decimal startingBalance, decimal currentBalance, decimal warningBalance, AccountType accountType)
        {
            return db.UpdateBankDataById(hId, owner, name, startingBalance, currentBalance, warningBalance, accountType);
        }
    }
}
