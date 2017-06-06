using GameGround.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using Utility;

namespace GameGround.Api
{
    public static class Extensions
    {
        public static long GetUserId(this ApiController controller)
        {
            if (controller.User == null) throw new AccessDeniedException();
            var user = controller.User.Identity as ClaimsIdentity;
            return Convert.ToInt64(user.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value);
        }
    }
}