namespace JCVDT_SR_ChatHub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Pass builder to Startup configuration
            var startup = new Startup(builder.Configuration);
            startup.ConfigureServices(builder.Services);

            var app = builder.Build();

            // Pass app to Startup configuration
            startup.Configure(app, app.Environment);

            app.Run();
        }
    }
}
