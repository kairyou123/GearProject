using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Mapping;
using AutoMapper;
using Domain.Entity;
using Domain.IRepository;
using Insfrastucture.Context;
using Insfrastucture.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
            services.AddMvc();
            ConfigureScoped(services);
            services.AddDbContext<GearContext>(optionns =>
                            optionns.UseSqlServer(Configuration.GetConnectionString("DevConnection"), b => b.MigrationsAssembly("GearMVC")));
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                           .AddEntityFrameworkStores<GearContext>()
                           .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Thiết lập về Password
                options.Password.RequireDigit = false; // Không bắt phải có số
                options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
                options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
                options.Password.RequireUppercase = false; // Không bắt buộc chữ in
                options.Password.RequiredLength = 5; // Số ký tự tối thiểu của password

                // Cấu hình về User.
                options.User.RequireUniqueEmail = true;  // Email là duy nhất

                // Cấu hình đăng nhập.
                options.SignIn.RequireConfirmedEmail = false;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
                options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại

            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "LoginGearMVC";
                options.AccessDeniedPath = "/access-denied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/dang-nhap";
            });

            services.AddRazorPages()
                            .AddMvcOptions(options =>
                            {
                                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                                    _ => "Trường này không được để trống");
                            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, GearContext context, UserManager<ApplicationUser> userManager)
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

            app.UseStatusCodePagesWithReExecute("/error", "?statusCode={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}");
            });
        }
        private void ConfigureScoped(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IHoaDonRepository, HoaDonRepository>();
            services.AddScoped<ILinhKienRepository, LinhKienRepository>();
            services.AddScoped<ILoaiLinhKienRepository, LoaiLinhKienRepository>();
            services.AddScoped<INhaCungCapRepository, NhaCungCapRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IGiaRepository, GiaRepository>();
            services.AddScoped<IGioHangRepository, GioHangRepository>();

        }
    }
}
