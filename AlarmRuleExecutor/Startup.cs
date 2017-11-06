using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlarmRuleExecutor.Application.Configuration;
using AlarmRuleExecutor.Application.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AlarmRuleExecutor
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
            services.AddMvc();
            services.AddAuthorization();
            //ElasticSearch
            var elasticSearchConnectionSettings = new ElasticSearchConnectionSettings();
            Configuration.GetSection("ElasticSearch").Bind(elasticSearchConnectionSettings);
            services.AddSingleton<IOptions<ElasticSearchConnectionSettings>>(new OptionsWrapper<ElasticSearchConnectionSettings>(elasticSearchConnectionSettings));
            //https://www.elastic.co/guide/en/elasticsearch/client/net-api/master/lifetimes.html
            services.AddSingleton<IElasticSearchManager, ElasticSearchManager>();




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
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
