using Aleph1.Logging;
using MatrixTest.BL.Contracts;
using MatrixTest.DAL.Contracts;
using MatrixTest.Models;
using MatrixTest.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixTest.BL.Implementation
{
    internal class BL : IBL
    {
        private readonly IDAL DAL;
        private readonly AuthenticationInfo CurrentUser;

        private readonly int MAX_TRAINING_SESSIONS = 5;

        public BL(IDAL DAL, AuthenticationInfo currentUser)
        {
            this.DAL = DAL;
            CurrentUser = currentUser;
        }

        public void Dispose()
        {
            DAL.Dispose();
        }

        [Logged]
        public IEnumerable<Hero> GetHeroes()
        {
            return DAL.GetHeroesByTrainerID(CurrentUser.UserID).AsEnumerable();
        }

        public Hero TrainHero(int heroID)
        {
            Hero hero = DAL.GetHeroByID(heroID);

            if(hero.TrainerID != CurrentUser.UserID)
            {
                throw new Exception("Hero not belong to this user");
            }

            if(hero.TrainingSessionsToday == MAX_TRAINING_SESSIONS)
            {
                if( (DateTimeOffset.Now - hero.LastTrainingDate).Value.TotalDays < 1)
                {
                    throw new Exception("Your hero reached his max training sessions for today");
                }

                hero.TrainingSessionsToday = 1;
            } else
            {
                hero.TrainingSessionsToday++;
            }

            hero.LastTrainingDate = DateTimeOffset.Now;

            if (hero.FirstTrainingDate == null)
            {
                hero.FirstTrainingDate = hero.LastTrainingDate;
            }

            Random random = new Random();
            hero.CurrentPower += (random.Next(0, 10) * hero.CurrentPower) / 100;

            DAL.SaveChanges();

            return hero;
        }
    }
}
