using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using MetricsAgent.DAL;

namespace MetricsAgent
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
            ConfigureSqlLiteConnection(services);
            services.AddScoped<ICpuMetricsRepository, CpuMetricsRepository>();
            services.AddScoped<IRamMetricsRepository, RamMetricsRepository>();
            services.AddScoped<IHddMetricsRepository, HddMetricsRepository>();
            services.AddScoped<INetworkMetricsRepository, NetworkMetricsRepository>();
            services.AddScoped<IDotNetMetricsRepository, DotNetMetricsRepository>();
        }

        private void ConfigureSqlLiteConnection(IServiceCollection services)
        {
            const string connectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            PrepareSchema(connection);
        }

        private void PrepareSchema(SQLiteConnection connection)
        {
            using (var command = new SQLiteCommand(connection))
            {
                //cpu
                command.CommandText = "DROP TABLE IF EXISTS cpumetrics";
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE cpumetrics(id INTEGER PRIMARY KEY,
                    value INT, time INT)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO cpumetrics (value, time) VALUES (50, 1623827400)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO cpumetrics (value, time) VALUES (55, 1623827700)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO cpumetrics (value, time) VALUES (60, 1623828000)";
                command.ExecuteNonQuery();
                //ram
                command.CommandText = "DROP TABLE IF EXISTS rammetrics";
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE rammetrics(id INTEGER PRIMARY KEY,
                    value INT, time INT)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO rammetrics (value, time) VALUES (50, 1623827400)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO rammetrics (value, time) VALUES (55, 1623827700)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO rammetrics (value, time) VALUES (60, 1623828000)";
                command.ExecuteNonQuery();
                //hdd
                command.CommandText = "DROP TABLE IF EXISTS hddmetrics";
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE hddmetrics(id INTEGER PRIMARY KEY,
                    value INT, time INT)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO hddmetrics (value, time) VALUES (50, 1623827400)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO hddmetrics (value, time) VALUES (55, 1623827700)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO hddmetrics (value, time) VALUES (60, 1623828000)";
                command.ExecuteNonQuery();
                //network
                command.CommandText = "DROP TABLE IF EXISTS networkmetrics";
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE networkmetrics(id INTEGER PRIMARY KEY,
                    value INT, time INT)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO networkmetrics (value, time) VALUES (50, 1623827400)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO networkmetrics (value, time) VALUES (55, 1623827700)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO networkmetrics (value, time) VALUES (60, 1623828000)";
                command.ExecuteNonQuery();
                //dotnet
                command.CommandText = "DROP TABLE IF EXISTS dotnetmetrics";
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE dotnetmetrics(id INTEGER PRIMARY KEY,
                    value INT, time INT)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO dotnetmetrics (value, time) VALUES (50, 1623827400)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO dotnetmetrics (value, time) VALUES (55, 1623827700)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO dotnetmetrics (value, time) VALUES (60, 1623828000)";
                command.ExecuteNonQuery();
            }
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            });
        }
    }
}
