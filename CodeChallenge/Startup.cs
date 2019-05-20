using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeChallenge.Startup))]
namespace CodeChallenge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
