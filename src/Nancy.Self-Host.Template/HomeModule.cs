namespace Nancy.SelfHost.Template
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = parameters =>
            {
                return "Hello world!";
            };

            Get["/sayhello"] = parameters =>
            {
                return "Hello from Owin!";
            };
        }
    }
}