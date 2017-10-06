using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Data;
using Npgsql;

namespace MyApp.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            DbConnectionFactoryConfiguration.LoadConnectionStrings(Configuration);
            DbConnectionFactoryConfiguration.RegisterFactory("Npgsql", NpgsqlFactory.Instance);

            // SimpleInjector init ...
            // Register query/command handlers
            // Register decorators for handlers

            app.UseMvc();
        }
    }
}
