using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Linq;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using GameGround.ViewModel;
using GameGround.Core;
using Utility;


namespace GameGround.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private readonly IPlayerService _service;
        public AccountController(IPlayerService service)
        {
            this._service = service;
        }

        [AllowAnonymous, HttpGet]
        public Metadata Test()
        {
            return new Metadata("test");
        }
        [Route("register")]
        [AllowAnonymous,HttpPost]
        public Metadata Register(VmRegistry model)
        {
            try
            {
                this._service.AddPlayer(model);
            }
            catch(LocalizedException e)
            {
                return new Metadata(string.Empty)
                {
                    Success = false,
                    Message = e.Message
                };
            }
            catch
            {
                throw;
            }
            return new Metadata("注册成功");
        }

        [AllowAnonymous, HttpPost]
        public Metadata Login(VmLogin model)
        {
            try
            {
                var user = this._service.Login(model);

                var identity = new ClaimsIdentity(OAuthDefaults.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
                

                var currentUtc = DateTime.UtcNow;

                AuthenticationTicket ticket = new AuthenticationTicket(identity, new AuthenticationProperties
                {
                    IssuedUtc = currentUtc,
                    ExpiresUtc = currentUtc.AddDays(1)
                });

                var token = Startup.OAuthOptions.AccessTokenFormat.Protect(ticket);
                return new Metadata(token);
            }
            catch (LocalizedException ex)
            {
                return new Metadata(string.Empty)
                {
                    Success = false,
                    Message = ex.Message
                };
            }
            catch (Exception)
            {
                throw;
            }

        }

        //[HttpGet, Route("logged")]
        //public Metadata<VmLoggedInfo> Logged()
        //{
        //    var id = this.GetUserId();

        //    var role = this._service.Get(id);

        //    var regionService = UnityConfig.GetService<IRegionService>();
        //    regionService.FillItem(role);

        //    return new Metadata<VmeLoggedInfo>(role);
        //}

        //[HttpPost, Route("change-password")]
        //public Metadata ChangePassword(VmeChangePassword model)
        //{
        //    var userId = this.GetUserId();
        //    this._service.ChangePassword(userId, model);
        //    return new Metadata();
        //}
    }
}
