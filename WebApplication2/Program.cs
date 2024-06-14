using Application.Commands.Lessons;
using Application.Commands.Students.Create;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application;
using Notes.Persistence;
using Persistance;
using System.Reflection;

namespace WebApplication2
{
    public class Program
    {

        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<IApplicationDbContext, ApplicationDbContext>();
            builder.Services.AddMediatR(typeof(CreateStudentCommand));
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddApplication();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
            



            builder.Configuration.AddJsonFile("appsettings.json");

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();
            app.Run();

        }

    }
}
