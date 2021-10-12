using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Printo.Data.Data;
using Printo.Intranet.Controllers.Abstract;

namespace Printo.Intranet.Controllers
{
    public class UserTypesController : AbstractAdminPolicyController
    {
        public UserTypesController(PrintoContextDB context) :base(context) { }

        // GET: UserTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserTypes.ToListAsync());
        }
    }
}
