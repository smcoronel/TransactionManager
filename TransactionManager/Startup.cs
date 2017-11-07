using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TransactionManager.Startup))]
namespace TransactionManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
