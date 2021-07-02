using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Modulo_Matricula.Startup))]
namespace Modulo_Matricula
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
