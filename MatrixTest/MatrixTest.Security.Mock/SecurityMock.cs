using MatrixTest.Models;
using MatrixTest.Models.Security;
using MatrixTest.Security.Contracts;

namespace MatrixTest.Security.Mock
{
    internal class SecurityMock : ISecurity
    {
        public string GenerateTicket(AuthenticationInfo authenticationInfo, string userUniqueID)
        {
            return "MockTicket";
        }

        public AuthenticationInfo ReadTicket(string ticketValue, string userUniqueID)
        {
            return new AuthenticationInfo() { UserID = 1, Email = "avivday@gmail.com" };
        }

        public AuthenticationInfo Login(string email, string password)
        {
            return new AuthenticationInfo() { UserID = 1, Email = "avivday@gmail.com" };
        }

        public bool IsAllowedForContent(AuthenticationInfo authenticationInfo)
        {
            return true;
        }

        public Trainer SignUp(string email, string fullname, string password)
        {
            return new Trainer();
        }

    }
}
