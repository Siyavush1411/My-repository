using Application.Common.Mappings;
using Application.Interfaces;
using Notes.Application;
using Notes.Persistence;
using System.Reflection;

namespace WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            /*      services.AddAutoMapper(config =>
                    {
                        config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                        config.AddProfile(new AssemblyMappingProfile(typeof(IApplicationDbContext).Assembly));
                    });*/
            /* services.AddAutoMapper(config =>
             {
                 config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
             }
             );*/
            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapControllers();
            });
        }
    }
}