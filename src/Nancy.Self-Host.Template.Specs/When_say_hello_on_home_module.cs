using Machine.Specifications;
using Nancy.SelfHost.Template;
using Nancy.Testing;

namespace Nancy.Self_Host.Template.Specs
{
    public class When_say_hello_on_home_module
    {
        private static Browser _browser;
        private static BrowserResponse _browserResponse;

        Establish context = () =>
        {
            var bootstrapper = new ConfigurableBootstrapper(with => with.Module<HomeModule>());
            _browser = new Browser(bootstrapper);
        };

        Because of = () =>
        {
            _browserResponse = _browser.Get("/sayhello", with => with.HttpRequest());
        };

        It should_return_http_ok = () => _browserResponse.StatusCode.ShouldEqual(HttpStatusCode.OK);            
        
        It should_return_hello_from_owin = () => _browserResponse.Body.AsString().ShouldEqual("Hello from Owin!");
    }
}
