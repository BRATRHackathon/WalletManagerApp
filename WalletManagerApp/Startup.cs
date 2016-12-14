using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WalletManagerApp.Startup))]
namespace WalletManagerApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
