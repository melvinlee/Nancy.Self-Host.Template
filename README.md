## Nancy Self-host Project Template

####Nancy + Self-host + Owin + SignalR

1. Create a new .NET 4.5 console project.
2. Install package using Nuget

		//SignalR Selfhost
	    Install-Package Microsoft.AspNet.SignalR.SelfHost
		
	    // Nancy-Owin packages
	    Install-package Nancy.owin
	    
	    //Nancy Razor view
	    Install-package Nancy.ViewEngines.Razor
       

3. Add Owin Startup class.

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
	        
4. Define your 1st Nancy routes.

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

5. Next customize nancy modules by overriding DefaultNancyBootstrapper

	      public class Bootstrapper : DefaultNancyBootstrapper
	        {      
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
    
6. Run the services 


	     class Program
	        {
	            static void Main(string[] args)
	            {
	                var url = "http://localhost:8888/";
	    
	                // start OWIN host 
	                using (WebApp.Start<Startup>(url))
	                {
	                    Console.WriteLine("Listening at " + url);
	                    Thread.Sleep(Timeout.Infinite);
	                }
	    
	            }
		  }