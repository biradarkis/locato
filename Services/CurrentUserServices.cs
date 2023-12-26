using Microsoft.AspNetCore.Http;
using Shared.Interfaces;
using System.Security.Claims;
using System.Collections.Generic;


namespace Services
{
    public class CurrentUserServices : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserServices(IHttpContextAccessor httpContextAccessor)
        {
         _httpContextAccessor = httpContextAccessor;
        }

        
        public bool IsLoggedIn => _httpContextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

        private long? _userId { get; set; }
        public long UserId => long.Parse(_httpContextAccessor.HttpContext?.User?.FindFirst("id")?.Value??"-1");

        public long OrganizationId => long.Parse(_httpContextAccessor.HttpContext?.User?.FindFirst("orgid")?.Value ?? "-1");

        public int Role => int.Parse(_httpContextAccessor.HttpContext?.User?.FindFirst("roleid")?.Value ?? "-1");
    }
}
