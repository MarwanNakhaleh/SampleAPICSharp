using Amazon.DynamoDBv2;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SampleAPI.Configurations;
using SampleAPI.Data.Queries;
using SampleAPI.Data.Repositories;

namespace SampleAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAWSService<IAmazonDynamoDB>();
            services.AddSingleton(GetDbConfiguration());
            services.AddScoped<BaseRepository, Repository>();
            services.AddScoped<BaseQuery, Query>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
                });
            });
        }

        private static DbConfiguration GetDbConfiguration()
        {
            DbConfiguration dbConf = new DbConfiguration()
            {
                ServiceURL = Configuration.GetValue<string>(ConfigurationKeys.DynamoDBServiceURLKey),
                TableName = Configuration.GetValue<string>(ConfigurationKeys.DynamoDBTableNameKey)
            };
            return dbConf;
        }
    }
}
