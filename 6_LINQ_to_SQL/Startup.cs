using IteaLinqToSql.Models.Database;
using IteaLinqToSql.Models.Entities;
using IteaLinqToSql.Models.Interfaces;
using IteaLinqToSql.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _6_LINQ_to_SQL
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
            services.AddDbContext<IteaDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SQLConnectionString"))
            );

            services.AddTransient<IService<User>, UserService>();
            services.AddTransient<IService<LoginHistory>, LoginHistoryService>();

            services.AddMvc(options => { options.AllowEmptyInputInBodyModelBinding = true; })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
