using MatrixTest.DAL.Contracts;
using MatrixTest.Models;
using MatrixTest.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixTest.DAL.Mock
{
    internal class DALMock : IDAL
    {
        List<Trainer> trainers = new List<Trainer>()
        {
            new Trainer()
            {
                ID = 1,
                Email = "avivday@gmail.com",
                Fullname = "Aviv Day",
                Password = null,
            }
        };

        public DALMock()
        {

        }

        public void SaveChanges() { }
        public void Dispose() { }

        public Trainer SignUp(Trainer trainer)
        {
            trainers.Add(trainer);

            return trainer;
        }

        public Trainer GetTrainerByID(int trainerID)
        {
            return trainers.FirstOrDefault(t => t.ID == trainerID);
        }

        public Trainer GetTrainerByEmail(string email)
        {
            return trainers.FirstOrDefault(t => t.Email == email);
        }

        public IQueryable<Hero> GetHeroesByTrainerID(int trainerID)
        {
            return new List<Hero>()
            {
                new Hero()
                {
                    ID = 1,
                    GuidID = Guid.NewGuid(),
                    Ability = Ability.Attacker,
                    CurrentPower = 20,
                    FirstTrainingDate = DateTimeOffset.Now,
                    LastTrainingDate = DateTimeOffset.Now,
                    StartingPower = 0,
                    SuitColor = "Black",
                    TrainerID = 1,
                    TrainingSessionsToday = 1
                }
            }.AsQueryable();
        }

        public Hero GetHeroByID(int heroID)
        {
            return new Hero()
            {
                ID = 1,
                GuidID = Guid.NewGuid(),
                Ability = Ability.Attacker,
                CurrentPower = 20,
                FirstTrainingDate = DateTimeOffset.Now,
                LastTrainingDate = DateTimeOffset.Now,
                StartingPower = 0,
                SuitColor = "Black",
                TrainerID = 1,
                TrainingSessionsToday = 1
            };
        }
    }
}
