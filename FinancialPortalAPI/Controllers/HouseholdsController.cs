using FinancialPortalAPI.Models;
using Newtonsoft.Json;
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
    /// Controller for the Household
    /// </summary>
    [RoutePrefix("api/Households")]
    public class HouseholdsController : ApiController
    {
        private APIDbContext db = new APIDbContext();

        /// <summary>
        /// Endpoint to return all household data
        /// </summary>
        /// <returns>List of all household data</returns>
        [Route("GetAllHouseData")]
        public async Task<List<Household>> GetAllHouseholdData()
        {
            return await db.GetAllHouseholdData();
        }
        /// <summary>
        /// Endpoint to return all household data
        /// </summary>
        /// <returns>List of all household data by Json</returns>
        [Route("GetAllHouseholdDataAsJson")]
        public async Task<IHttpActionResult> GetDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllHouseholdData());
            return Ok(json);
        }
        /// <summary>
        /// Returns the information for a single household
        /// </summary>
        /// <param name="id">The Pk of the household you want to view</param>
        /// <returns>Single household for model</returns>
        [Route("GetHouseholdById")]
        public async Task<Household> GetHouseholdById(int id)
        {
            return await db.GetHouseholdById(id);
        }
        /// <summary>
        /// Returns the information for a single household by Json
        /// </summary>
        /// <param name="id">The PK of the household you want to view</param>
        /// <returns>Single household for model by Json</returns>
        [Route("GetHouseholdbyId")]
        public async Task<Household> GetHouseId(int id)
        {
            //var json = JsonConvert.SerializeObject(await db.GetHouseholdById(id));
            //return Ok(json);
            return await db.GetHouseholdById(id);
        }
        /// <summary>
        /// Soft delete of a household by Id
        /// </summary>
        /// <param name="id">The PK of the household you want to view</param>
        /// <returns>Soft delete of a household by Json</returns>
        
        [Route("DeleteHouseholdDataByID")]
        [HttpDelete]
        public int GetDeletedHHData(int id)
        {
            //var json = JsonConvert.SerializeObject(await db.DeleteHouseholdDataById(id));
            //return Ok(json);
            return db.DeleteHouseholdDataById(id);
        }
        /// <summary>
        /// The household and child data
        /// </summary>
        /// <param name="id">The PK of the household you want to view</param>
        /// <returns>Returns all household data with its child data by Json</returns>
        [Route("GetHouseholdAndChildData")]
        public async Task<Household> GetHouseholdAndChildData(int id)
        {
            //var json = JsonConvert.SerializeObject(await db.GetHouseholdAndChildData(id));
            //return Ok(json);
            return await db.GetHouseholdAndChildData(id);
        }
        /// <summary>
        /// Update data for household by Id
        /// </summary>
        /// <param name="id">The PK of the household</param>
        /// <returns>Updates the data for the household by Id</returns>
        [Route("UpdateHouseholdDataById")]
        public int UpdateHouseholdDataById(int id)
        {
            //var json = JsonConvert.SerializeObject(await db.UpdateHouseholdDataById(id));
            //return Ok(json);
            return db.UpdateHouseholdDataById(id);
        }
        /// <summary>
        /// Create data for a household
        /// </summary>
        /// <returns>Create data for a household</returns>
        [Route("InsertHouseholdData")]
        
        public int InsertHouseholdData(string name, string greeting)
        {
            //var json = JsonConvert.SerializeObject(await db.InsertHouseholdData(name, greeting));
            //return Ok();
            return db.InsertHouseholdData(name, greeting);
        }
    }
}
