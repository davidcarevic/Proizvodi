using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using EFCommands;
using EFDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
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
            services.AddDbContext<ProizvodiContext>();
            services.AddTransient<ICreateKategorijaCommand, EFCreateKategorijaCommand>();
            services.AddTransient<ICreateDobavljacCommand, EFCreateDobavljacCommand>();
            services.AddTransient<ICreateProizvodjacCommand, EFCreateProizvodjacCommand>();
            services.AddTransient<ICreateProizvodCommand, EFCreateProizvodCommand>();
            services.AddTransient<IEditKategorijaCommand, EFEditKategorijaCommand>();
            services.AddTransient<IEditDobavljacCommand, EFEditDobavljacCommand>();
            services.AddTransient<IEditProizvodjacCommand, EFEditProizvodjacCommand>();
            services.AddTransient<IEditProizvodCommand, EFEditProizvodCommand>();
            services.AddTransient<IDeleteKategorijaCommand, EFDeleteKategorija>();
            services.AddTransient<IDeleteDobavljacCommand, EFDeleteDobavljacCommand>();
            services.AddTransient<IDeleteProizvodjacCommand, EFDeleteProizvodjacCommand>();
            services.AddTransient<IDeleteProizvodCommand, EFDeleteProizvodCommand>();
            services.AddTransient<IGetProizvodsCommand, EFGetProizovdsCommand>();
            services.AddTransient<IGetKategorijasCommand, EFGetKategorijasCommand>();
            services.AddTransient<IGetDobavljacsCommand, EFGetDobavljacsCommand>();
            services.AddTransient<IGetProizvodjacsCommand, EFGetProizvodjacsCommand>();
            services.AddTransient<IGetProizvodCommand, EFGetProizvodCommand>();
            services.AddTransient<IGetDobavljacCommand, EFGetDobavljacCommand>();
            services.AddTransient<IGetKategorijaCommand, EFGetKategorijaCommand>();
            services.AddTransient<IGetProizvodjacCommand, EFGetProizvodjacCommand>();
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
