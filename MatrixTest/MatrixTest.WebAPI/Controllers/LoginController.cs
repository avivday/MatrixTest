using Aleph1.Logging;
using MatrixTest.Models.Security;
using MatrixTest.Security.Contracts;
using MatrixTest.WebAPI.Models;
using MatrixTest.WebAPI.Security;
using Aleph1.WebAPI.ExceptionHandler;

using System.Diagnostics.Contracts;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MatrixTest.Models;

namespace MatrixTest.WebAPI.Controllers
{
    /// <summary>handle login</summary>
    public class LoginController : ApiController
    {
        private readonly ISecurity SecurityService;

        /// <summary></summary>
        public LoginController(ISecurity securityService)
        {
            SecurityService = securityService;
        }

        /// <summary>
        /// Sign up
        /// </summary>
        /// <returns>Trainer</returns>
        [Authenticated(AllowAnonymous = true), Logged(LogParameters = false), HttpPost, Route("api/sign-up"), FriendlyMessage("Signup error occured")]
        public Trainer Signup(SignUpModel signUpModel)
        {
            Contract.Requires(signUpModel != null);

            return SecurityService.SignUp(signUpModel.Email, signUpModel.Fullname, signUpModel.Password);
        }

        [Authenticated(AllowAnonymous = true), Logged(LogParameters = false), HttpPost, Route("api/login"), FriendlyMessage("Login error occured")]
        public AuthenticationInfo Login(LoginModel loginModel)
        {
            Contract.Requires(loginModel != null);

            AuthenticationInfo authenticationInfo = SecurityService.Login(loginModel.Email, loginModel.Password);
            Request.AddAuthenticationInfo(SecurityService, authenticationInfo);

            return authenticationInfo;
        }

        /// <summary>Logout from the application</summary>
        [Logged, HttpPost, Route("api/logout"), FriendlyMessage("Logout error occured")]
        public HttpResponseMessage Logout()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NoContent);
            response.RemoveAuthenticationInfoValueFromCookie();

            return response;
        }
    }
}
