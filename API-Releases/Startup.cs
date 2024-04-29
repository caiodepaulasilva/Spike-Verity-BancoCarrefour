using API_Releases.Middlewares;
using API_Releases.Validators;
using Application.Services;
using Domain;
using Domain.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace API_Releases
{
    public class Startup(IConfiguration configuration)
    {
        public IConfiguration Configuration { get; } = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {
                c.SchemaFilter<ExampleSchema>();
            });
            services.AddFluentValidationAutoValidation();
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddScoped<IAccountingService, AccountingService>();
            services.AddScoped<IValidator<Release>, ReleaseValidator>();

            services.AddDbContext<StoreContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseMiddleware<ExceptionHandler>();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "v1");
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseHttpsRedirection();
        }
    }
}
