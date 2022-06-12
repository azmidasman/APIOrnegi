using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StajAPI.Context;
using StajAPI.Repositories.Abstract;
using StajAPI.Repositories.Concrete;

namespace StajAPI
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StajAPI", Version = "v1" });
            });
            services.AddDbContext<StajApiDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
            //services.AddScoped:her bir scope'da tralepte bulunuldugunda yeni nesne oluþmasý
            //services.AddTransient:Controller bazýnda nesne oluþturmasý
            //services.AddSingleton: projede bir nesneyi bir kere ayaða kaldýrýð sürekli o nesneyi kullanýyor.

            services.AddTransient<DbContext,StajApiDbContext>();
            services.AddTransient<ICategoryRepository,CategoryRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StajAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
