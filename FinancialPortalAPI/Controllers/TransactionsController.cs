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
    /// This is the transaction controller for the financial portal
    /// </summary>
    public class TransactionsController : ApiController
    {
        private APIDbContext db = new APIDbContext();

        //=========================Get All Transaction Data==========================//
        /// <summary>
        /// Returns all Transaction data
        /// </summary>
        /// <returns>Returns all Transaction data</returns>
        [Route("GetAllTransactionData")]
        public async Task<List<Transaction>> GetAllTransactionData()
        {
            return await db.GetAllTransactionData();
        }

        //===================Get Transaction Data by Id======================//
        /// <summary>
        /// Returns Transaction data for a single account
        /// </summary>
        /// <param name="id">FK for the Transaction</param>
        /// <returns>Returns Transaction data for a single account</returns>
        [Route("GetTransactionDataById")]
        public async Task<Transaction> GetTransactionDataById(int id)
        {
            return await db.GetTransactionDataById(id);
        }

        //===========================Delete============================//
        /// <summary>
        /// Delete a single Transaction
        /// </summary>
        /// <param name="id">The PK of the Transaction</param>
        /// <returns>Delete a single Transaction by Id</returns>
        [Route("DeleteTransactionDataById")]
        [HttpDelete]
        public int DeleteTransactionData(int id)
        {
            return db.DeleteTransactionDataById(id);
        }

        //================================Create==================================//
        /// <summary>
        /// Create a transaction
        /// </summary>
        
        /// <param name="aId">Account Id tied to the transaction</param>
        /// <param name="biId">The budget item id tied to the transaction</param>
        /// <param name="owner">The owner that created the transaction</param>
        /// <param name="transactionType">The transaction type</param>
        /// <param name="amount">The amount of the transaction</param>
        /// <param name="memo">What the purchase was made for</param>
        /// <returns>Create a transaction</returns>
        [Route("InsertTransactionData")]
        public int InsertTransactionData(int aId, int biId, string owner, TransactionType transactionType, decimal amount, string memo)
        {
            return db.InsertTransactionData(aId, biId, owner, transactionType, amount, memo);
        }

        //=======================Update============================//
        /// <summary>
        /// Update a transaction
        /// </summary>
        /// <param name="id">FK of the transaction</param>
        /// <param name="aId">Account Id tied to the transaction</param>
        /// <param name="biId">The budget item id tied to the transaction</param>
        /// <param name="owner">The owner that created the transaction</param>
        /// <param name="transactionType">The transaction type</param>
        /// <param name="amount">The amount of the transaction</param>
        /// <param name="memo">What the purchase was made for</param>
        /// <returns>Update a transaction</returns>
        public int UpdateTransactionDataById(int id, int aId, int biId, string owner, TransactionType transactionType, decimal amount, string memo)
        {
            return db.UpdateTransactionDataById(id, aId, biId, owner, transactionType, amount, memo);
        }
    }
}
