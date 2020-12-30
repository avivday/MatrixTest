using Aleph1.Logging;
using MatrixTest.DAL.Contracts;
using MatrixTest.Models;
using System.Data.Entity;
using System.Linq;

namespace MatrixTest.DAL.Implementation
{
    internal class DAL : IDAL
    {
        private readonly MainContext Context;

        public DAL(MainContext context)
        {
            Context = context;
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        [Logged(LogParameters = false)]
        public Trainer SignUp(Trainer trainer)
        {
            return Context.Trainers.Add(trainer);
        }

        [Logged]
        public Trainer GetTrainerByID(int trainerID)
        {
            return Context.Trainers.Find(trainerID);
        }

        [Logged]
        public Trainer GetTrainerByEmail(string email)
        {
            return Context.Trainers.FirstOrDefault(t => t.Email == email);
        }

        [Logged]
        public IQueryable<Hero> GetHeroesByTrainerID(int trainerID)
        {
            return Context.Heroes.Where(h => h.TrainerID == trainerID).AsNoTracking();
        }

        public Hero GetHeroByID(int heroID)
        {
            return Context.Heroes.Find(heroID);
        }
    }
}
