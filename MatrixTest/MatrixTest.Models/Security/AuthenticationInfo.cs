namespace MatrixTest.Models.Security
{
    /// <summary>The information that the server needs for determining if a user is allowed for a resource</summary>
    public class AuthenticationInfo
    {
        // TODO: put your real implementation here

        /// <summary>
        /// user ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// user Email
        /// </summary>
        public string Email { get; set; }
    }
}
