﻿// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Catching all kind of exceptions", Scope = "member", Target = "~M:MatrixTest.WebAPI.Security.AuthenticatedAttribute.OnActionExecuting(System.Web.Http.Controllers.HttpActionContext)")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Action cannot be static", Scope = "member", Target = "~M:MatrixTest.WebAPI.Controllers.AboutController.About~MatrixTest.WebAPI.Models.AboutModel")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Application_Start cannot be static", Scope = "member", Target = "~M:MatrixTest.WebAPI.WebApiApplication.Application_Start")]
