using System.Collections.Generic;
using System.Threading.Tasks;
using AGL.Catlovers.FindMyCatAPI.Interfaces;
using AGL.Catlovers.FindMyCatAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AGL.Catlovers.FindMyCatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        private readonly ICatsInterface _catsInterface;

        public CatsController(ICatsInterface catsInterface)
        {
            _catsInterface = catsInterface;
        }

        /// <summary>
        /// Get Method to return result without any input
        /// This Method is implemented just to see Result to reduce your efforts on Post call
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        public async Task<List<CatsResult>> Get()
        {
            return await _catsInterface.GetCatsByOwnerGender();
        }

        /// <summary>
        /// This method can be tested with Post action with different inputs
        /// </summary>
        /// <param name="petsJsonData"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<CatsResult>> Post([FromBody]List<PetOwners> petsJsonData)
        {
            return await _catsInterface.GetCatsByGender(petsJsonData);
        }
    }
}