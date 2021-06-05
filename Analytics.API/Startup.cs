using AngaloAmericanAnalytics.API.Core.Interfaces.Database;
using AngaloAmericanAnalytics.API.Core.Interfaces.Logic;
using AngaloAmericanAnalytics.API.Data;
using AngaloAmericanAnalytics.API.Data.Repository;
using AngaloAmericanAnalytics.API.Logic.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace AngaloAmericanAnalytics.API
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
            services.AddCors(option =>
            {

                option.AddDefaultPolicy(builder =>
                {
                    if (Convert.ToBoolean(Configuration["CORSSetting:IsAllowAllDomain"]))
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    }
                    else
                    {
                        var allowDomain = Configuration["CORSSetting:IsAllowAllDomain"].ToString().Split(',');
                        builder
                        .WithOrigins(allowDomain)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    }
                });
            });

            services.AddSwaggerGen();
            services.AddControllersWithViews();
            services.AddDbContext<AngaloAmericanAnalyticsDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Database")));
            services.AddScoped<IHistoryLogic, HistoryLogic>();
            services.AddScoped<IModelMetriceLogic, ModelMetriceLogic>();
            services.AddScoped<IModelDetailRepository, ModelDetailRepository>();
            services.AddScoped<IAnalyticsLogic, AnalyticsLogic>();
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Analytics API V1");
            });
            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
