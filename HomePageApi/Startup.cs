using GulnesApi.Data;
using GulnesApi.Data.Jokes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GulnesApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Method adds services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            const string connectionString = "Server=(local)\\SQL;Database=Gulnes;Trusted_Connection=True;";
            
            services.AddDbContext<GulnesContext>(options => 
                options.UseSqlServer(connectionString));

            services.AddCors(o => o.AddPolicy("GulnesClientPolicy", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                }));

            services.AddScoped<IJokeRepository, JokeRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("GulnesClientPolicy");

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
