using Microsoft.EntityFrameworkCore;
using SchoolAdministration.AutoMapper;
using SchoolAdministration.Data;
using SchoolAdministration.Repositories.Interfaces;
using SchoolAdministration.Repositories.Repos;
using Serilog;


namespace SchoolAdministration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // LOGGING :

            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
                .WriteTo.File("log/villaLogs.txt", rollingInterval: RollingInterval.Day).CreateLogger();
            builder.Host.UseSerilog();


            // ADD SERVICES TO THE CONTAINER :

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
            });

            builder.Services.AddAutoMapper(typeof(MappingConfig));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCors", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<ITeacherRepository,TeacherRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IExamRepository, ExamRepository>();
            builder.Services.AddScoped<IExamResultRepository, ExamResultRepository>();
            builder.Services.AddScoped<IStudyPlanRepository, StudyPlanRepository>();
            builder.Services.AddScoped<IStudyPlanPartRepository, StudyPlanPartRepository>();

            //VERSIONING :

            builder.Services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<AppDbContext>();

            var app = builder.Build();

            var entities = app.Services.CreateScope().ServiceProvider.GetRequiredService<IStudentRepository>();


            // SWAGGER :

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
