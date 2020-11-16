using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoardGame.Startup))]
namespace BoardGame
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
