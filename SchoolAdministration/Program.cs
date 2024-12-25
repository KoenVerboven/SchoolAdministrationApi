using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using SchoolAdministration.Data;
using SchoolAdministration.Repositories.Interfaces;
using SchoolAdministration.Repositories.Repos;

namespace SchoolAdministration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer("Data Source=KOENI7;Initial Catalog=School2;Integrated Security=True;TrustServerCertificate=True;")
                );

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCors", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            //add the student repository to the DI (dependency injection)
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ITeacherRepository,TeacherRepository>();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<AppDbContext>();//toegevoegd

            var app = builder.Build();

            var entities = app.Services.CreateScope().ServiceProvider.GetRequiredService<IStudentRepository>();//toegevoegd
            

            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c=>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseCors("MyCors");  

            app.MapControllers();

            app.Run();
        }
    }
}
