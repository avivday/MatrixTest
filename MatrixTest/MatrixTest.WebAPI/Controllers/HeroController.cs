using Aleph1.Logging;
using Aleph1.WebAPI.ExceptionHandler;
using MatrixTest.BL.Contracts;
using MatrixTest.Models;
using MatrixTest.WebAPI.Security;
using System.Collections.Generic;
using System.Web.Http;

namespace MatrixTest.WebAPI.Controllers
{
    /// <summary>handle login</summary>
    public class HeroController : ApiController
    {
        private readonly IBL BL;

        /// <summary></summary>
        public HeroController(IBL bl)
        {
            BL = bl;
        }

        /// <summary>
        /// Get heroes
        /// </summary>
        /// <returns>Hero list for the current user</returns>
        [Authenticated(AllowAnonymous = false), Logged, HttpGet, Route("api/heroes"), FriendlyMessage("Can't fetch heroes, try again later")]
        public IEnumerable<Hero> GetHeroes()
        {
            return BL.GetHeroes();
        }

        /// <summary>
        /// Train hero
        /// </summary>
        /// <param name="heroID">Hero ID</param>
        /// <returns>The updated hero</returns>
        [Authenticated(AllowAnonymous = false), Logged, HttpPut, Route("api/hero/{heroID}/train"), FriendlyMessage("Can't train hero")]
        public Hero TrainHero(int heroID)
        {
            return BL.TrainHero(heroID);
        }
    }
}
