using Owin;

namespace Nancy.SelfHost.Template
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure SignalR
            app.MapSignalR();

            // Configure diagnostics
            app.UseErrorPage();
            
            // Configure Nancy
            app.UseNancy();
        }
    }
}