using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Commands;
using Application.Commands.FuelCommands;
using Application.Commands.ModelCommands;
using Application.Commands.TransmissionCommands;
using Application.Commands.UserCommands;
using EfCommands.CarCommands;
using EfCommands.EngineCommands;
using EfCommands.EquipmentCommands;
using EfCommands.FuelCommands;
using EfCommands.ModelCommands;
using EfCommands.TransmissionCommands;
using EfCommands.UserCommands;
using EfDataAccess;

namespace Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;

                services.AddDbContext<ProjectContext>();
                //CAR COMMANDS
                services.AddTransient<IAddCarCommand, EfAddCarCommand>();
                services.AddTransient<IEditCarCommand, EfEditCarCommand>();
                services.AddTransient<IDeleteCarCommand, EfDeleteCarCommand>();
                services.AddTransient<IGetCarCommand, EfGetCarCommand>();
                services.AddTransient<IGetCarsCommand, EfGetCarsCommand>();
                //Engine Commands
                services.AddTransient<IAddEngineCommand, EfAddEngineCommand>();
                services.AddTransient<IEditEngineCommand, EfEditEngineCommand>();
                services.AddTransient<IDeleteEngineCommand, EfDeleteEngineCommand>();
                services.AddTransient<IGetEngineCommand, EfGetEngineCommand>();
                services.AddTransient<IGetEngineCommand, EfGetEngineCommand>();
                //EquipmentCommands
                services.AddTransient<IAddEquipmentCommand, EfAddEquipmentCommand>();
                services.AddTransient<IEditEquipmentCommand, EfEditEquipmentCommand>();
                services.AddTransient<IDeleteEquipmentCommand, EfDeleteEquipmentCommand>();
                services.AddTransient<IGetEquipmentCommand, EfGetEquipmentCommand>();
                services.AddTransient<IGetEquipmentCommand, EfGetEquipmentCommand>();
                //FuelCommands
                services.AddTransient<IAddFuelCommand, EfAddFuelCommand>();
                services.AddTransient<IEditFuelCommand, EfEditFuelCommand>();
                services.AddTransient<IDeleteFuelCommand, EfDeleteFuelCommand>();
                services.AddTransient<IGetFuelCommand, EfGetFuelCommand>();
                services.AddTransient<IGetFuelsCommand, EfGetFuelsCommand>();
                //MOdelCommnads
                services.AddTransient<IAddModelCommand, EfAddModelCommand>();
                services.AddTransient<IEditModelCommand, EfEditModelCommand>();
                services.AddTransient<IDeleteModelCommand, EfDeleteModelCommand>();
                services.AddTransient<IGetModelCommand, EfGetModelCommand>();
                services.AddTransient<IGetModelsCommand, EfGetModelsCommand>();
                //User Commands

                services.AddTransient<IAddUserCommand, EfAddUserCommand>();
                services.AddTransient<IEditModelCommand, EfEditModelCommand>();
                services.AddTransient<IDeleteModelCommand, EfDeleteModelCommand>();
                services.AddTransient<IGetModelCommand, EfGetModelCommand>();
                services.AddTransient<IGetModelsCommand, EfGetModelsCommand>();
                //Transmission Commands
                services.AddTransient<IAddTransmissionCommand, EfAddTransmissionCommand>();
                services.AddTransient<IEditTransmissionCommand, EfEditTransmissionCommand>();
                services.AddTransient<IDeleteTransmissionCommand, EfDeleteTransmissionCommand>();
                services.AddTransient<IGetTransmissionCommand, EfGetTransmissionCommand>();
                services.AddTransient<IGetTransmissionsCommand, EfGetTransmissionsCommand>();
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
