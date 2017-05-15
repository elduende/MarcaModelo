using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MarcaModelo.Web.Startup))]
namespace MarcaModelo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
