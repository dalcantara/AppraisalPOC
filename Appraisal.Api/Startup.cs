using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Appraisal.Api.Repositories;
using Appraisal.Api.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Appraisal.Api
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
            services.AddSwaggerGen();
            services.AddControllers();
            ConfigureMongo(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            ConfigureSwagger(app);
        }

        private void ConfigureMongo(IServiceCollection services)
        {
            services.Configure<ProductDatabaseSettings>(Configuration.GetSection(nameof(ProductDatabaseSettings)));
            services.AddSingleton<IProductDatabaseSettings>(sp => 
                sp.GetRequiredService<IOptions<ProductDatabaseSettings>>().Value);
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IAppraisalFormRepository, AppraisalFormRepository>();
            services.AddSingleton<IAppraisalRepository, AppraisalRepository>();
        }

        private static void ConfigureSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(
                swagger =>
                {
                    swagger.RoutePrefix = "";
                    swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Hello World");
                });
        }
    }
}