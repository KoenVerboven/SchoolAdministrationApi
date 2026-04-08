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
using SchoolAdministration.Models.Domain.General;


namespace SchoolAdministration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //logger :
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File("log/schoolManagementLog.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            builder.Host.UseSerilog();


            //Add services to the container :
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
            });

            // Current
            builder.Services.AddAutoMapper(cfg => 
            cfg.LicenseKey = "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxODA1NDE0NDAwIiwiaWF0IjoiMTc3MzkyOTgxNiIsImFjY291bnRfaWQiOiIwMTlkMDY3MDkxYmM3YmM0YWM0MGU2M2MwYmRjYzAwZCIsImN1c3RvbWVyX2lkIjoiY3RtXzAxa20zNzlyZjcyZ2Fna3JzZ2prc2d0eXNwIiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.ePB0aHCScYiAEkBaRc6ptNMVd8XH9YxyCsrJqJBdPCDeCe_0Cxxi3Pn-9WjnDmUCOE7Pd3pUQK1OvWuqDD__au2D6rd0-0aAedCHGQm0wn411CRrUkKk8R0wJuqg46OdDJWeOCgaa6htpzo9so8_wLG1lST7ikqv_QYu6PTgFUorqtUKmYZ4xrOK_eFGDGepItGqKMkn2uK76jh8M2VuW3sm_ad2fEQAtKI-qe5rIGEo5jyWxVDC1Uc33xSjGRM_uX8-ny1VEZhnwKotYQ8ORLcuBAAoox31VulMKYyqbLQsaWaqWyjpGnqd_PaD2ggUHrF4qJvQSgqtV772FffFcQ"
            , typeof(MappingConfig));



            builder.Services.AddCors(options =>
            {
                options.AddPolicy("SchoolAdministrationCors", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            // Dependency Injection for Repositories:
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<ITeacherRepository,TeacherRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IQAExamRepository, QAExamRepository>();
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

            app.UseCors("SchoolAdministrationCors");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Images\\StudentImages")),
                RequestPath = "/images/studentimages"
            });

            app.UseMiddleware<Middlewares.ErrorHandeling.ExceptionMiddelware>();
            app.MapControllers();
            app.Run();
        }
    }
}
