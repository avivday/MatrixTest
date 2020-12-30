using MatrixTest.Models;
using System;
using System.Collections.Generic;

namespace MatrixTest.BL.Contracts
{
    /// <summary>Handles business logic</summary>
    public interface IBL : IDisposable
    {
        /// <summary>
        /// Get Heroes
        /// </summary>
        /// <returns>Hero List</returns>
        IEnumerable<Hero> GetHeroes();

        /// <summary>
        /// Train Hero
        /// </summary>
        /// <param name="heroID">hero ID</param>
        /// <returns>Hero</returns>
        Hero TrainHero(int heroID);
    }
}
