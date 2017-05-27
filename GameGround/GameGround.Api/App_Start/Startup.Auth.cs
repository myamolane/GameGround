using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;

namespace GameGround.Api
{
    public partial class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthOptions { get; private set; }

        static Startup()
        {
            OAuthOptions = new OAuthBearerAuthenticationOptions();
        }
        public void ConfigureAuth(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            UnityConfig.RegisterComponents();

            app.UseOAuthBearerAuthentication(OAuthOptions);
        }
    }
}
