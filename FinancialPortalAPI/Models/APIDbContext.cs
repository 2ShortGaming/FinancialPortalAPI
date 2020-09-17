using FinancialPortalAPI.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace FinancialPortalAPI.Models
{
    /// <summary>
    /// The model for the Database for the financial portal
    /// </summary>
    public class APIDbContext : DbContext
    {
        //=========================Connection String==============================//
        /// <summary>
        /// The connection string to the database
        /// </summary>
        public APIDbContext()
            : base("DefaultConnection")
        {

        }


        #region Household Data
        /// <summary>
        /// Returns all household data for all households
        /// </summary>
        /// <returns>All data for each household</returns>
        public async Task<List<Household>> GetAllHouseholdData()
        {
            return await Database.SqlQuery<Household>("GetAllHouseholdData").ToListAsync();
        }

        //=========================Single House Id=======================//
        /// <summary>
        /// Returns data for single household by Id
        /// </summary>
        /// <param name="id">The PK of the household you want to view</param>
        /// <returns>Returns data for household by Id</returns>
        public async Task<Household> GetHouseholdById(int id)
        {
            return await Database.SqlQuery<Household>("GetHouseholdById @Id",
                new SqlParameter("Id", id)).FirstOrDefaultAsync();
        }

        //===========================Delete=================================//
        /// <summary>
        /// Delete a single household
        /// </summary>
        /// <param name="id">The PK of the household</param>
        /// <returns>Delete a single household by Id</returns>
        public int DeleteHouseholdDataById(int id)
        {
            return Database.ExecuteSqlCommand("DeleteHouseholdDataById @Id",
                new SqlParameter("Id", id));
        }

        //=========================Get House and Child Data==========================//
        /// <summary>
        /// Returns all household and child data
        /// </summary>
        /// <param name="id">The PK of the household</param>
        /// <returns>Returns all house and child data for a household</returns>
        public async Task<Household> GetHouseholdAndChildData(int id)
        {
            return await Database.SqlQuery<Household>("GetHouseholdAndChildData @Id",
                new SqlParameter("Id", id)).FirstOrDefaultAsync();
        }

        //==============================Update===================================//
        /// <summary>
        /// Update data for a single household
        /// </summary>
        /// <param name="hId">The PK for the household</param>
        /// <returns>Update data for a single household by Id</returns>
        public int UpdateHouseholdDataById(int hId)
        {
            return Database.ExecuteSqlCommand("UpdateHouseholdDataById @hId",
                new SqlParameter("hId", hId));
        }

        //==============================Create==================================//
        /// <summary>
        /// Create a new household
        /// </summary>
        /// <returns>Create a new household</returns>
        public int InsertHouseholdData(string name, string greeting)
        {
            return Database.ExecuteSqlCommand("InsertHouseholdData @hhn, @greeting",
                new SqlParameter("hhn", name),
                new SqlParameter("greeting", greeting));
        }
        #endregion


        #region Bank Data
        /// <summary>
        /// Returns all bank data for all accounts
        /// </summary>
        /// <returns>Returns all bank data</returns>
        public async Task<List<BankAccount>> GetAllBankData()
        {
            return await Database.SqlQuery<BankAccount>("GetAllBankData").ToListAsync();
        }

        //=============================Get Bank Data by Id=============================//
        /// <summary>
        /// Returns bank data for a single account
        /// </summary>
        /// <param name="id">FK for the bank account</param>
        /// <returns>Returns bank data for a single account</returns>
        public async Task<BankAccount> GetBankDataById(int id)
        {
            return await Database.SqlQuery<BankAccount>("GetBankDataById @Id",
                new SqlParameter("Id", id)).FirstOrDefaultAsync();
        }

        //=====================================Delete===========================================//
        /// <summary>
        /// Delete a single bank account
        /// </summary>
        /// <param name="id">The PK for the Bank Account</param>
        /// <returns>Delete a single bank account by Id</returns>
        public int DeleteBankDataById(int id)
        {
            return Database.ExecuteSqlCommand("DeleteBankDataById @Id",
                new SqlParameter("Id", id));
        }

        //=======================================Create========================================//
        /// <summary>
        /// Create a new bank account
        /// </summary>
        /// <param name="hId">The PK for the household</param>
        /// <param name="name">The name of the bank account</param>
        /// <param name="owner">The owner of  the bank account</param>
        /// <param name="startingBalance">This is the starting balance of the account the user inputs</param>
        /// <param name="currentBalance">This is the current balance of the account</param>
        /// <param name="warningBalance">This is the warning balance of the account when it gets low on funds</param>
        /// <param name="accountType">This is the account type of the account</param>
        /// <returns>Create a new bank account by the user</returns>
        public int InsertBankData(int hId, string owner, string name, decimal startingBalance, decimal currentBalance, decimal warningBalance, AccountType accountType)
        {
            return Database.ExecuteSqlCommand("InsertBankData @hId, @oId, @an, @sb, @cb, @wb, @at",
                new SqlParameter("hId", hId),
                new SqlParameter("oId", owner),
                new SqlParameter("an", name),
                new SqlParameter("sb", startingBalance),
                new SqlParameter("cb", currentBalance),
                new SqlParameter("wb", warningBalance),
                new SqlParameter("at", accountType));
        }

        //===================================Update=====================================//
        /// <summary>
        /// Update a bank account by Id
        /// </summary>
        /// <param name="hId">The PK for the household</param>
        /// <param name="name">The name of the bank account</param>
        /// <param name="owner">The owner of  the bank account</param>
        /// <param name="startingBalance">This is the starting balance of the account the user inputs</param>
        /// <param name="currentBalance">This is the current balance of the account</param>
        /// <param name="warningBalance">This is the warning balance of the account when it gets low on funds</param>
        /// <param name="accountType">This is the account type of the account</param>
        /// <returns>Update a bank account by Id</returns>
        public int UpdateBankDataById(int hId, string owner, string name, decimal startingBalance, decimal currentBalance, decimal warningBalance, AccountType accountType)
        {
            return Database.ExecuteSqlCommand("UpdateBankDataById @hId",
                new SqlParameter("hId", hId),
                new SqlParameter("oId", owner),
                new SqlParameter("an", name),
                new SqlParameter("sb", startingBalance),
                new SqlParameter("cb", currentBalance),
                new SqlParameter("wb", warningBalance),
                new SqlParameter("at", accountType));
        }

        //==========================Bank and Transaction Data============================//
        /// <summary>
        /// Get all bank and transaction data
        /// </summary>
        /// <param name="id">FK of the bank account</param>
        /// <returns>Return all bank and transaction data</returns>
        public Task<List<BankAccount>> GetBankAndTransactionData(int id)
        {
            return Database.SqlQuery<List<BankAccount>>("GetBankAndTransactionData @Id",
                new SqlParameter("Id", id)).FirstOrDefaultAsync();
        }
        #endregion

        #region Budget Data
        //===================Get All Budget Data==================//
        /// <summary>
        /// Returns all budget data
        /// </summary>
        /// <returns>Returns all budget data</returns>
        public async Task<List<Budget>> GetAllBudgetData()
        {
            return await Database.SqlQuery<Budget>("GetAllBudgetData").ToListAsync();
        }

        //=========================Delete============================//
        /// <summary>
        /// Delete a single budget from a household
        /// </summary>
        /// <param name="id">FK for the budget</param>
        /// <returns>Delete a single budget for a household</returns>
        public int DeleteBudgetDataById(int id)
        {
            return Database.ExecuteSqlCommand("DeleteBudgetDataById @Id",
                new SqlParameter("Id", id));
        }

        //====================Get Budget by Id=======================//
        /// <summary>
        /// Returns a single budget for a household
        /// </summary>
        /// <param name="id">FK for the budget</param>
        /// <returns></returns>
        public async Task<Budget> GetBudgetDataById(int id)
        {
            return await Database.SqlQuery<Budget>("GetBudgetDataById @Id",
                new SqlParameter("Id", id)).FirstOrDefaultAsync();
        }

        //=======================Update========================//
        /// <summary>
        /// Update the budget data by Id
        /// </summary>
        /// <param name="hId">FK for the budget</param>
        /// <param name="owner">the owner that created the budget</param>
        /// <param name="budgetName">The name of the budget</param>
        /// <param name="currentAmount">Current amount for the budget</param>
        /// <returns>Update the budget data by Id</returns>
        public int UpdateBudgetDataById(int hId, string owner, string budgetName, decimal currentAmount)
        {
            return Database.ExecuteSqlCommand("UpdateBudgetDataById @hId, @oId, @bn, @ca",
                new SqlParameter("hId", hId),
                new SqlParameter("oId", owner),
                new SqlParameter("bn", budgetName),
                new SqlParameter("ca", currentAmount));
        }

        //=====================Create======================//
        /// <summary>
        /// Create the budget data by Id
        /// </summary>
        /// <param name="hId">FK for the budget</param>
        /// <param name="owner">the owner that created the budget</param>
        /// <param name="budgetName">The name of the budget</param>
        /// <param name="currentAmount">Current amount for the budget</param>
        /// <returns>Create the budget data by Id</returns>
        public int InsertBudgetData(int hId, string owner, string budgetName, decimal currentAmount)
        {
            return Database.ExecuteSqlCommand("InsertBudgetData @hId, @oId, @bn, @ca",
                new SqlParameter("hId", hId),
                new SqlParameter("oId", owner),
                new SqlParameter("bn", budgetName),
                new SqlParameter("ca", currentAmount));
        }

        #endregion


        #region Budget Item Data
        //======================Get All Budget Item Data==========================//
        /// <summary>
        /// Returns all budget item data
        /// </summary>
        /// <returns>Returns all budget item data</returns>
        public async Task<List<BudgetItem>> GetAllBudgetItemData()
        {
            return await Database.SqlQuery<BudgetItem>("GetAllBudgetItemData").ToListAsync();
        }

        //====================Get Budget Item by Id=========================//
        /// <summary>
        /// Returns a single budget item
        /// </summary>
        /// <param name="id">Fk for the budget item</param>
        /// <returns>Returns a single budget item</returns>
        public async Task<BudgetItem> GetBudgetItemById(int id)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemById @Id",
                new SqlParameter("Id", id)).FirstOrDefaultAsync();
        }

        //==========================Create=============================//
        /// <summary>
        /// Create a budget item for household
        /// </summary>
        /// <param name="bId">Fk for the budget Id</param>
        /// <param name="itemName">Item name for budget item</param>
        /// <param name="targetAmount">Target amount for the budget item</param>
        /// <param name="currentAmount">Current amount for the budget item</param>
        /// <returns>Create a budget item for household</returns>
        public int InsertBudgetItemData(int bId, string itemName, decimal targetAmount, decimal currentAmount)
        {
            return Database.ExecuteSqlCommand("InsertBudgetItemData @bi, @in, @ta, @ca",
                new SqlParameter("bi", bId),
                new SqlParameter("in", itemName),
                new SqlParameter("ta", targetAmount),
                new SqlParameter("ca", currentAmount));
        }

        //==========================Update===============================//
        /// <summary>
        /// Update a budget item for household
        /// </summary>
        /// <param name="bId">Fk for the budget Id</param>
        /// <param name="itemName">Item name for budget item</param>
        /// <param name="targetAmount">Target amount for the budget item</param>
        /// <param name="currentAmount">Current amount for the budget item</param>
        /// <returns>Update a budget item for household</returns>
        public int UpdateBudgetItemDataById(int bId, string itemName, decimal targetAmount, decimal currentAmount)
        {
            return Database.ExecuteSqlCommand("InsertBudgetItemDataById @bi, @in, @ta, @ca",
                new SqlParameter("bi", bId),
                new SqlParameter("in", itemName),
                new SqlParameter("ta", targetAmount),
                new SqlParameter("ca", currentAmount));
        }

        //=======================Delete============================//
        /// <summary>
        /// Delete a single budget item
        /// </summary>
        /// <param name="id">FK of the budget item</param>
        /// <returns>Delete a single budget item</returns>
        public int DeleteBudgetItemDataById(int id)
        {
            return Database.ExecuteSqlCommand("DeleteBudgetItemDataById @Id",
                new SqlParameter("Id", id));
        }

        #endregion

        #region Transaction Data
        //================Get All Transaction Data=======================//
        /// <summary>
        /// Returns all transactions for household
        /// </summary>
        /// <returns>Returns all transaction for household</returns>
        public async Task<List<Transaction>> GetAllTransactionData()
        {
            return await Database.SqlQuery<Transaction>("GetAllTransactionData").ToListAsync();
        }

        //==============Get Transaction Data by Id===================//
        /// <summary>
        /// Returns a single transaction by Id
        /// </summary>
        /// <param name="id">FK for the transaction</param>
        /// <returns>Returns a single transaction by Id</returns>
        public async Task<Transaction> GetTransactionDataById(int id)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDataById @Id",
                new SqlParameter("Id", id)).FirstOrDefaultAsync();
        }

        //====================Create============================//
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
        public int InsertTransactionData(int aId, int biId, string owner, TransactionType transactionType, decimal amount, string memo)
        {
            return Database.ExecuteSqlCommand("InsertTransactionData @aId, @biId, @oId, @tt, @amount, @memo",
                
                new SqlParameter("aId", aId),
                new SqlParameter("biId", biId),
                new SqlParameter("oId", owner),
                new SqlParameter("tt", transactionType),
                new SqlParameter("amount", amount),
                new SqlParameter("memo", memo));
        }

        //====================Update============================//
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
            return Database.ExecuteSqlCommand("InsertTransactionDataById @Id, @aId, @biId, @oId, @tt, @amount, @memo",
                new SqlParameter("Id", id),
                new SqlParameter("aId", aId),
                new SqlParameter("biId", biId),
                new SqlParameter("oId", owner),
                new SqlParameter("tt", transactionType),
                new SqlParameter("amount", amount),
                new SqlParameter("memo", memo));
        }

        //======================Delete==========================//
        /// <summary>
        /// Delete a single transaction
        /// </summary>
        /// <param name="id">The FK for the transaction</param>
        /// <returns>Delete a single transaction</returns>
        public int DeleteTransactionDataById(int id)
        {
            return Database.ExecuteSqlCommand("DeleteTransactionDataById @Id",
                new SqlParameter("Id", id));
        }
        #endregion
    }
}