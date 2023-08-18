using Microsoft.Extensions.Configuration;

namespace SeguimientoDNT.Api
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
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowCorsPolicy", buider =>
                {
                    buider.AllowAnyOrigin();
                    buider.AllowAnyMethod();
                    buider.AllowAnyHeader();
                });
            });
        }
    }
}
