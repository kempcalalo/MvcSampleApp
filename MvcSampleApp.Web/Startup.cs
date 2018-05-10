using System.Linq;
using System.Reflection;
using AutoMapper;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcSampleApp.Web.Startup))]
namespace MvcSampleApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
