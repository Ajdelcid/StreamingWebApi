using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StreamingWebApi.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace StreamingWebApi
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
            services.AddTransient<IWS_USUARIORepository, WS_USUARIORepository>();
            services.AddTransient<IWS_CLASIFICACIONRepository, WS_CLASIFICACIONRepository>();
            services.AddTransient<IWS_FACTURARepository, WS_FACTURARepository>();
            /* services.AddTransient<IWS_GENERORepository, WS_GENERORepository>();
            services.AddTransient<IWS_MULTIMEDIARepository, WS_MULTIMEDIARepository>();
            services.AddTransient<IWS_MULTIMEDIA_GENERORepository, WS_GENERORepository>();
            services.AddTransient<IWS_MULTIMEDIA_SUSCRIPCIONRepository, WS_MULTIMEDIA_SUSCRIPCIONRepository>();
            services.AddTransient<IWS_PAGORepository, WS_PAGORepository>();
            services.AddTransient<IWS_SUSCRIPCIONRepository, WS_SUSCRIPCIONRepository>();
            services.AddTransient<IWS_TARJETARepository, WS_TARJETARepository>();
            services.AddTransient<IWS_TIPO_MULTIMEDIARepository, WS_TIPO_MULTIMEDIARepository>();
            services.AddTransient<IWS_TIPO_SUSCRIPCIONRepository, WS_TIPO_SUSCRIPCIONRepository>();
            services.AddTransient<IWS_VISITARepository, WS_VISITARepository>();*/
            services.AddSingleton<IConfiguration>(Configuration);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
