﻿using AspNetCoreModelBinding.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreModelBinding
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                //options.ModelBinderProviders.Insert(0, new NumberBinderProvider()); 

            });
        }

      
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();        
            app.UseMvcWithDefaultRoute();
        }
    }
}
