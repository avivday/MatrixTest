using MatrixTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixTest.DAL.Contracts
{
    /// <summary>Handles data access</summary>
    public interface IDAL : IDisposable
    {
        #region Auth

        /// <summary>
        /// Save Changes
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Sign up
        /// </summary>
        /// <param name="trainer">Trainer Model</param>
        /// <returns>Trainer</returns>
        Trainer SignUp(Trainer trainer);
        #endregion

        #region Trainer
        /// <summary>
        /// Get Trainer by ID
        /// </summary>
        /// <param name="trainerID">trainer ID</param>
        /// <returns>Trainer</returns>
        Trainer GetTrainerByID(int trainerID);

        /// <summary>
        /// Get Trainer By Email
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>Trainer</returns>
        Trainer GetTrainerByEmail(string email);
        #endregion

        #region Heroes
        /// <summary>
        /// Get hero list by trainer ID
        /// </summary>
        /// <param name="trainerID">Trainer ID</param>
        /// <returns>Hero List</returns>
        IQueryable<Hero> GetHeroesByTrainerID(int trainerID);
        
        /// <summary>
        /// Get hero by ID
        /// </summary>
        /// <param name="heroID">hero ID</param>
        /// <returns>Hero</returns>
        Hero GetHeroByID(int heroID);
        #endregion
    }
}
