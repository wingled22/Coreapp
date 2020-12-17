using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    public class AppSessionManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;
        public AppSessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
        }
    }
}
