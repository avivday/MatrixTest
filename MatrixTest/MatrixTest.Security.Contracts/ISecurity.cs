using MatrixTest.Models;
using MatrixTest.Models.Security;

namespace MatrixTest.Security.Contracts
{
    /// <summary>Handles security (authentication/authorization)</summary>
    public interface ISecurity
    {
        #region GeneralAuth
        /// <summary>create an encrypted ticked that includes all the AuthenticationInfo - can only be opened for a specific user</summary>
        /// <param name="authenticationInfo">the data to encrypt</param>
        /// <param name="userUniqueID">ticket will be open-able for this user only</param>
        /// <returns>encrypted ticket</returns>
        string GenerateTicket(AuthenticationInfo authenticationInfo, string userUniqueID);

        /// <summary>decrypt a ticket</summary>
        /// <param name="ticketValue">the encrypted ticket</param>
        /// <param name="userUniqueID">the user that this ticket was encrypted to</param>
        /// <returns>the data</returns>
        AuthenticationInfo ReadTicket(string ticketValue, string userUniqueID);
        #endregion GeneralAuth

        /// <summary>Generate a AuthenticationInfo based on the given credentials</summary>
        /// <param name="username">the email</param>
        /// <param name="password">the password</param>
        /// <returns>an AuthenticationInfo representing the credentials of the user</returns>
        AuthenticationInfo Login(string email, string password);

        /// <summary>
        /// Signup
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="fullname">fullname</param>
        /// <param name="password">password</param>
        /// <returns>the new trainer created</returns>
        Trainer SignUp(string email, string fullname, string password);

        /// <summary>return whether the current user is allowed for content</summary>
        /// <param name="heroID">Hero ID</param>
        /// <returns>true if allowed, false otherwise</returns>
        bool IsAllowedForContent(AuthenticationInfo authenticationInfo);
    }
}
