namespace JCVDT_SR_ChatHub
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container
            services.AddSignalR();

            // Configure HTTPS
            services.AddHttpsRedirection(options =>
            {
                options.HttpsPort = 5001;
            });

            // TODO: add
            // services.AddCors();
            // services.AddAuthentication();
            // services.AddAuthorization();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseDefaultFiles();

            // SignalR Hub mapping
            app.MapHub<ChatHub>("/chatHub");
        }
    }
}
