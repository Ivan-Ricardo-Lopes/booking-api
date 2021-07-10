using AutoMapper;
using IRL.Booking.API.AutoMapper;
using IRL.Booking.API.Middlewares;
using IRL.Booking.Application.Commands.CancelBooking;
using IRL.Booking.Application.Commands.CreateBooking;
using IRL.Booking.Application.Commands.UpdateBooking;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace IRL.Booking.API
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
            #region automapper

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<APIMapperProfile>();
            });

            services.AddSingleton(mapperConfig.CreateMapper());

            #endregion automapper

            #region mediatr

            services.AddMediatR(AppDomain.CurrentDomain.Load("IRL.Booking.API"));
            services.AddMediatR(AppDomain.CurrentDomain.Load("IRL.Booking.Application"));

            #endregion mediatr

            #region validators

            services.AddScoped<CreateBookingValidator>();
            services.AddScoped<CancelBookingValidator>();
            services.AddScoped<UpdateBookingValidator>();

            #endregion validators

            services.AddHealthChecks();
            services.AddApiVersioning();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IRL.Booking.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IRL.Booking.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<GlobalErrorHandlerMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}