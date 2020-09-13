using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prueba.API.Middleware;
using Prueba.Data;
using Prueba.Services.RabbitMQ;
using Prueba.Services.RabbitMQ.Support;
using Prueba.Services.CronJobs.Support;
using System;
using CrossCutting.Constants;
using Prueba.CronJobs;

namespace WebApi
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
            //Registramos el DbContext
            services.AddDbContext<PruebaDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.Configure<AmqpInfo>(Configuration.GetSection("amqp"));
            services.AddSingleton<AmqpService>();

            IoC.AddDependency(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCronJob<ExpiredItemsCronJobService>(c =>
            {
                c.CronExpression = CronJobs.CON_EXPRESSION_REMOVE_ITEM;
                c.TimeZoneInfo = TimeZoneInfo.Local;
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
