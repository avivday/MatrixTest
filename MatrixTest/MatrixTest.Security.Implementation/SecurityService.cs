using Aleph1.Logging;
using Aleph1.Security.Contracts;
using MatrixTest.DAL.Contracts;
using MatrixTest.Models;
using MatrixTest.Models.Security;
using MatrixTest.Security.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixTest.Security.Implementation
{
    internal class SecurityService : ISecurity
    {
        private readonly ICipher CipherService;
        private readonly HashHelpers HashHelpers;
        private readonly IDAL DAL;

        public SecurityService(ICipher cipherService, IDAL dal, HashHelpers hashHelpers)
        {
            CipherService = cipherService;
            DAL = dal;
            HashHelpers = hashHelpers;
        }

        public string GenerateTicket(AuthenticationInfo authenticationInfo, string userUniqueID)
        {
            return CipherService.Encrypt(SettingsManager.AppPrefix, userUniqueID, authenticationInfo, SettingsManager.TicketDurationTimeSpan);
        }
        public AuthenticationInfo ReadTicket(string ticketValue, string userUniqueID)
        {
            try
            {
                return CipherService.Decrypt<AuthenticationInfo>(SettingsManager.AppPrefix, userUniqueID, ticketValue);
            }
            catch
            {
                return null;
            }
        }


        [Logged(LogParameters = false, LogReturnValue = true)]
        public AuthenticationInfo Login(string email, string password)
        {
            Trainer trainer = DAL.GetTrainerByEmail(email);

            if(!HashHelpers.ValidatePassword(password, trainer.Password))
            {
                throw new UnauthorizedAccessException("Access Denied");
            }

            return new AuthenticationInfo() { Email = email, UserID = trainer.ID };
        }

        [Logged(LogParameters = false, LogReturnValue = true)]
        public bool IsAllowedForContent(AuthenticationInfo authenticationInfo)
        {
            return authenticationInfo != default;
        }

        [Logged(LogParameters = false, LogReturnValue = true)]
        public Trainer SignUp(string email, string fullname, string password)
        {
            Trainer trainer = new Trainer()
            {
                Email = email,
                Fullname = fullname,
                Password = HashHelpers.HashPassword(password)
            };

            Trainer newTrainer = DAL.SignUp(trainer);
            DAL.SaveChanges();

            return new Trainer() { ID = newTrainer.ID, Email = newTrainer.Email, Fullname = newTrainer.Email, Heroes = newTrainer.Heroes };
        }
    }
}
