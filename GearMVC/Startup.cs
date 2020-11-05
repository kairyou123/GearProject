using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Mapping;
using AutoMapper;
using Domain.IRepository;
using Insfrastucture.Context;
using Insfrastucture.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GearMVC
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
            services.AddControllersWithViews();
            ConfigureScoped(services);
            services.AddDbContext<GearContext>(optionns =>
                            optionns.UseSqlServer(Configuration.GetConnectionString("DevConnection"), b => b.MigrationsAssembly("GearMVC")));
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        private  void ConfigureScoped(IServiceCollection services)
        {
            services.AddScoped<IGioHangRepository, GioHangRepository>();
            services.AddScoped<IHoaDonRepository, HoaDonRepository>();
            services.AddScoped<IKhachHangRepository, KhachHangRepository>();
            services.AddScoped<ILinhKienRepository, LinhKienRepository>();
            services.AddScoped<ILoaiLinhKienRepository, LoaiLinhKienRepository>();
            services.AddScoped<INhaCungCapRepository, NhaCungCapRepository>();
            services.AddScoped<INhanVienRepository, NhanVienRepository>();
            services.AddScoped<ITonKhoRepository, TonKhoRepository>();
        }
    }
}
