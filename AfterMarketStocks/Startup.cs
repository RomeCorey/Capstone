using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AfterMarketStocks.Startup))]
namespace AfterMarketStocks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
