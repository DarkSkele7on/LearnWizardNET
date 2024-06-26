using BusinessLayer;
using DataLayer;
using LearnWizard.Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;

namespace MVC
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
            services.AddRazorPages();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddScoped<LearnWizardAppDbContext, LearnWizardAppDbContext>();
            services.AddScoped<UserContext, UserContext>();
            services.AddScoped<CourseContext, CourseContext>();
            services.AddScoped<IEmailSender, EmailSenderManager>();
            services.AddScoped<IdentityContext, IdentityContext>();
            services.AddSingleton<OpenApi>(new OpenApi(Environment.GetEnvironmentVariable("OPEN_AI_KEY")));
            
            services.AddDbContext<LearnWizardAppDbContext>(op =>
            {
                op.UseSqlServer("Server=localhost,1433;Database=LearnWizard;User=sa;Password=Zamunda06;Encrypt=True;TrustServerCertificate=True;");
            });

            services.AddIdentity<User, IdentityRole>(iop =>
            {
                iop.Password.RequiredLength = 5;
                iop.Password.RequireNonAlphanumeric = false;
                iop.Password.RequiredUniqueChars = 0;
                iop.Password.RequireUppercase = false;
                iop.Password.RequireLowercase = false;
                iop.Password.RequireDigit = false;

                iop.User.RequireUniqueEmail = false;

                iop.SignIn.RequireConfirmedEmail = false;
            })
                .AddEntityFrameworkStores<LearnWizardAppDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.SlidingExpiration = true;
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
