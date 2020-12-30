﻿using Aleph1.Logging;
using MatrixTest.Models.Security;
using MatrixTest.Security.Contracts;

using NLog;

using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;
using System.Web.Http.Filters;

namespace MatrixTest.WebAPI.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    internal sealed class AuthenticatedAttribute : ActionFilterAttribute
    {
        public bool AllowAnonymous { get; set; }

        /// <summary>Authenticates the request.</summary>
        /// <param name="actionContext">The action context.</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                // Get the DI container for the request scope
                IDependencyScope DI = actionContext.Request.GetDependencyScope();
                ISecurity securityService = DI.GetService(typeof(ISecurity)) as ISecurity;

                //read the ticket
                AuthenticationInfo authInfo = actionContext.GetAuthenticationInfoFromCookie(securityService);

                if (!AllowAnonymous && !securityService.IsAllowedForContent(authInfo))
                {
                    LogManager.GetCurrentClassLogger().LogAleph1(LogLevel.Warn, $"{authInfo?.Email ?? "UNKNOWN"} tried to access {actionContext.Request.RequestUri}");
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "");
                    return;
                }

                //Regenerating a ticket with the same data - to reset the ticket life span
                actionContext.Request.AddAuthenticationInfo(securityService, authInfo);
            }
            catch (Exception ex)
            {
                if (!AllowAnonymous)
                {
                    LogManager.GetCurrentClassLogger().LogAleph1(LogLevel.Warn, actionContext.Request.RequestUri.ToString(), ex);
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "");
                }
            }
        }

        /// <summary>pass the AuthenticationInfo value from the request to the response - if present</summary>
        /// <param name="actionExecutedContext">action context</param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            string authValue = actionExecutedContext.Request.GetAuthenticationInfo();
            actionExecutedContext.AddAuthenticationInfoValueToCookie(authValue);
        }
    }
}