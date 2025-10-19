using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolAdministration.AutoMapper;
using SchoolAdministration.Data;
using SchoolAdministration.Repositories.Interfaces;
using SchoolAdministration.Repositories.Repos;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using SchoolAdministration.Models.Domain;


namespace SchoolAdministration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //logger :
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
                .WriteTo.File("log/schoolManagementLogs.txt", rollingInterval: RollingInterval.Day).CreateLogger();
            builder.Host.UseSerilog();


            //add service to the container :
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

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<ITeacherRepository,TeacherRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IExamRepository, ExamRepository>();
            builder.Services.AddScoped<IExamResultRepository, ExamResultRepository>();
            builder.Services.AddScoped<IStudyPlanRepository, StudyPlanRepository>();
            builder.Services.AddScoped<IStudyPlanPartRepository, StudyPlanPartRepository>();
            builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IClassRepository, ClassRepository>();
            builder.Services.AddScoped<IStudentPresenceRepository, StudentPresenceRepository>();
            builder.Services.AddScoped<IParentRepository, ParentRepository>();
            builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            builder.Services.AddScoped<IImageRepository, ImageRepository>();

            var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(x => {
                 x.RequireHttpsMetadata = false;
                 x.SaveToken = true;
                 x.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                     ValidateIssuer = false,
                     ValidateAudience = false
                 };
             });

            //adding identity :
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
            ).AddEntityFrameworkStores<AppDbContext>();

            //versioning :
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


            //swagger :
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
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
