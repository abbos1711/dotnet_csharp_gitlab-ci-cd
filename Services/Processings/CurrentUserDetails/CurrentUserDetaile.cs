using System;
using System.Security.Claims;
using dosLogistic.API.Models.Foundations.Users;
using Microsoft.AspNetCore.Http;

namespace dosLogistic.API.Services.Processings.CurrentUserDetails
{
    public static class CurrentUserDetaile
    {
        public static IHttpContextAccessor contextAccessor;

        public static Guid UserId() =>
            Guid.Parse(contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value);

        public static string Email() =>
            contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email).Value;

        public static string FirstName() =>
            contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.GivenName).Value;

        public static string UserRole() =>
            contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role).Value;
    }
}
