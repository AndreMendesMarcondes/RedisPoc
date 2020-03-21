using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Redis.Repository;
using StackExchange.Redis;
using System;
using Wlniao.Caching;

namespace Redis
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<NarutoJutsuRepository, NarutoJutsuRepositoryImp>();

            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = "172.17.0.2:6379,password=123456,abortConnect=false";
                options.InstanceName = "redisLocal";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
