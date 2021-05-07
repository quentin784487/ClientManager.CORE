using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DAL.DbContext;
using BLL.Contracts;
using BLL;
using Repository.Contracts;
using Repository;

namespace ClientManager
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
            services.AddSingleton<IDataWrapper, DataWrapper>();
            services.AddSingleton<IClients, Clients>();
            services.AddSingleton<IClientsRepository, ClientsRepository>();
            services.AddSingleton<IAddressInformation, AddressInformation>();
            services.AddSingleton<IClients, Clients>();
            services.AddSingleton<IContactInformation, ContactInformation>();
            services.AddSingleton<IAddressInformationRepository, AddressInformationRepository>();
            services.AddSingleton<IContactInformationRepository, ContactInformationRepository>();
            services.AddCors();
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

            app.UseCors(
                options => options.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()
            );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });            
        }
    }
}
