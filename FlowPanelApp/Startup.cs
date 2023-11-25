using FlowPanelApp.Context;
using FlowPanelApp.Services.Announcement;
using FlowPanelApp.Services.AnnouncementService;
using FlowPanelApp.Services.AppService;
using FlowPanelApp.Services.CalendarService;
using FlowPanelApp.Services.ClassService;
using FlowPanelApp.Services.CourseService;
using FlowPanelApp.Services.GradeService;
using FlowPanelApp.Services.SchoolService;
using FlowPanelApp.Services.StudentService;
using FlowPanelApp.Services.TeacherService;
using FlowPanelApp.Services.UserService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FlowPanelApp
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
            services.AddDbContext<FlowContext>(options =>
            options.UseSqlServer(Configuration["ConnectionStrings:FlowPanelConnection"]));
            services.AddMvc();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
            {
                option.LoginPath = "/Login/Index";
                option.Cookie.Name = "DotNetCookie";
            });
            services.AddRazorPages();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAppService, AppService>();
            services.AddScoped<ISchoolService, SchoolService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IAnnouncementService, AnnonuncementService>();
            services.AddScoped<ICalendarService, CalendarService>();
            
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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();

            app.UseRequestLocalization();
         
            System.Globalization.CultureInfo customCulture = new CultureInfo("pl-PL");
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            CultureInfo.DefaultThreadCurrentCulture = customCulture;
            CultureInfo.DefaultThreadCurrentUICulture = customCulture;





            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Login}/{id?}");
            });

        }
    }
}
