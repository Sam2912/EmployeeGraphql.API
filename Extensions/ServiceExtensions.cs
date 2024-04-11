using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Security.Claims;
using EmployeeGraphql.API.Constants;
using EmployeeGraphql.API.DbContext;
using EmployeeGraphql.API.Mapping;
using EmployeeGraphql.API.Query;

namespace EmployeeGraphql.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Configure identity options as needed
                options.SignIn.RequireConfirmedAccount = false;
            });
        }

        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]))
                };
            });
        }

        public static void ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(EmployeeConstant.ADMIN_POLICY, policy => policy.RequireClaim(ClaimTypes.Role, EmployeeConstant.ROLE_ADMIN));
                // Add more policies as needed
            });
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:5173") // Replace with your allowed origin
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile)); // Add AutoMapper
        }

        public static void ConfigureFluentValidation(this IServiceCollection services)
        {
           // services.AddValidatorsFromAssemblyContaining<EmployeeInputValidator>(ServiceLifetime.Singleton);
        }

        public static void ConfigureGraphQL(this IServiceCollection services)
        {
            services.AddGraphQLServer()
            .AddQueryType<EmployeeQueryType>()
            .AddAuthorization();
        }

        public static void ConfigureBackgroundService(this IServiceCollection services)
        {
            // Add the background service
            //builder.Services.AddHostedService<UserManagementBackgroundService>();

        }
    }
}