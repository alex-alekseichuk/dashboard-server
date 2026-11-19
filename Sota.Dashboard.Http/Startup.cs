using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sota.Dashboard.Services;
using Sota.Dashboard.DataAccess;

namespace Sota.Dashboard.Http
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
          Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
          
			    services.AddTransient<IObjectRepository, ObjectRepository>();
			    services.AddTransient<IFilterRepository, FilterRepository>();
			    services.AddTransient<IEntityRepository, EntityRepository>();
          
			    services.AddTransient<IObjectService, ObjectService>();
			    services.AddTransient<IFilterService, FilterService>();
			    services.AddTransient<IEntityService, EntityService>();

          services.AddMemoryCache();

          services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

          services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            //app.UseHttpsRedirection();

            app.UseCors(builder => builder
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials());

            app.Use((context, next) => {
                context.Response.Headers["Access-Control-Allow-Origin"] = "*";
                return next.Invoke();
            });

            app.UseMvc();
        }
    }
}
