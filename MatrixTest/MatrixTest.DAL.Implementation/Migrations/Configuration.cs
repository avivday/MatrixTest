using MatrixTest.Models;
using MatrixTest.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace MatrixTest.DAL.Implementation.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MainContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            List<Trainer> trainers = new List<Trainer>();

            trainers.Add(new Trainer()
            {
                Fullname = "Aviv Day",
                Email = "avivday@gmail.com",
                Password = "$2a$12$rWMPUlGdcKHChisPE42LGO7Ix0cYGZ50OtY24wi28nOrv58rtZOdW", // pass is : Aa123456!
                Heroes = new List<Hero>() {
                    new Hero() {
                        ID = 1,
                        Name = "Superman",
                        GuidID = Guid.NewGuid(),
                        Ability = Ability.Attacker,
                        CurrentPower = 14,
                        FirstTrainingDate = new DateTimeOffset(2020, 1, 1, 0, 0, 0, new TimeSpan()),
                        LastTrainingDate = new DateTimeOffset(2020, 1, 1, 0, 0, 2, new TimeSpan()),
                        StartingPower = 1,
                        SuitColor = "blue",
                        TrainerID = 1,
                        TrainingSessionsToday = 2
                    },
                    new Hero() {
                        ID = 1,
                        Name = "Batman",
                        GuidID = Guid.NewGuid(),
                        Ability = Ability.Defender,
                        CurrentPower = 0,
                        FirstTrainingDate = new DateTimeOffset(2020, 11, 8, 14, 0, 0, new TimeSpan()),
                        LastTrainingDate = new DateTimeOffset(2020, 11, 11, 0, 0, 2, new TimeSpan()),
                        StartingPower = 1,
                        SuitColor = "yellow",
                        TrainerID = 1,
                        TrainingSessionsToday = 5
                    }
                }
            });

            trainers.Add(new Trainer()
            {
                Fullname = "Israel Israeli",
                Email = "israel@gmail.com",
                Password = "$2a$12$gB6RIxqwIiFHdd0G17aUxuYfLQwUpoLXlwMYrFChbkUYdEfuV0tYq", // pass is : Aa123456!
                Heroes = new List<Hero>() {
                    new Hero() {
                        ID = 1,
                        Name = "Spiderman",
                        GuidID = Guid.NewGuid(),
                        Ability = Ability.Attacker,
                        CurrentPower = 6,
                        FirstTrainingDate = new DateTimeOffset(2020, 1, 1, 1, 1, 1, new TimeSpan()),
                        LastTrainingDate = new DateTimeOffset(2020, 1, 1, 1, 1, 1, new TimeSpan()),
                        StartingPower = 1,
                        SuitColor = "Red",
                        TrainerID = 1,
                        TrainingSessionsToday = 1
                    }
                }
            });

            context.Trainers.AddRange(trainers);

            context.SaveChanges("Seed");
        }
    }
}
