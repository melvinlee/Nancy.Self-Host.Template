using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace Nancy.SelfHost.Template
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper

        protected override byte[] FavIcon
        {
            get { return null; }
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            // Enable JavaScript Object Notation
            Jsonp.Enable(pipelines);
        }
    }
}