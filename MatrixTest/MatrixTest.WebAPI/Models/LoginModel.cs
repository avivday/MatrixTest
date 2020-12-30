namespace MatrixTest.WebAPI.Models
{
    /// <summary>Credentials for login</summary>
    public class LoginModel
    {
        /// <summary>The email</summary>
        public string Email { get; set; }


        /// <summary>The password (length must be 2-10)</summary>
        public string Password { get; set; }
    }
}