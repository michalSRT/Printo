using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Printo.Data.Data;
using Microsoft.AspNetCore.Routing;

namespace Printo.Intranet.Policy
{
    public class UserPolicy : Controller
    {
        private readonly PrintoContext context;
        private readonly int userId;
        private readonly int userTypeId;

        public UserPolicy(PrintoContext _context, HttpContext _session, RouteData _routeData)
        {
            context = _context;
            userId = Convert.ToInt32(_session.Session.GetString("UserID"));
            userTypeId = Convert.ToInt32(_session.Session.GetString("UserTypeID"));
        }

        public async Task<bool> hasNoAccess()
        {
            var currentUser = await context.Users.FindAsync(userId);

            if (currentUser is null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> isAdmin()
        {
            var currentUser = await context.Users.FindAsync(userId);

            if (currentUser.UserTypeID == 1)
            {
                return true;
            }

            return false;
        }

    }
}
