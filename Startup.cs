using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebApplicationSocialMediaApp.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
//using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebApplicationSocialMediaApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }
        private readonly IHostEnvironment _env;

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp", policy =>
                {
                    policy.WithOrigins("http://localhost:3000") // Replace with your React app's URL
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
            services.AddControllers();
            services.AddControllersWithViews();

            // Enable Swagger
            //services.AddSwaggerGen(c =>
            //{
            //    // This is to generate the default UI of Swagger Documentation
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SepStreamAPI", Version = "v1" });

            //    // To Enable authorization using Swagger (JWT)
            //    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            //    {
            //        Name = "Authorization",
            //        Type = SecuritySchemeType.ApiKey,
            //        Scheme = "Bearer",
            //        BearerFormat = "JWT",
            //        In = ParameterLocation.Header,
            //        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
            //    });
            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //        {
            //            new OpenApiSecurityScheme
            //            {
            //                Reference = new OpenApiReference
            //                {
            //                    Type = ReferenceType.SecurityScheme,
            //                    Id = "Bearer"
            //                }
            //            },
            //            new string[] {}
            //        }
            //    });

            //    // Register the operation filter to add header parameters
            //    c.OperationFilter<CustomRequestHeaderFilter>();
            //});

            //services.AddAuthentication(option =>
            //{
            //    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(options =>
            //{
            //    options.SaveToken = true;
            //    options.TokenValidationParameters = CognitoUtil.GetCognitoTokenValidationParams();
            //}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            //{
            //    options.LoginPath = "/User/Login";
            //    options.LogoutPath = "/User/Logout";
            //    options.ReturnUrlParameter = "";
            //});
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<SocialMediaContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("SocialMediaAppConnection"),
                sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    10,
                    TimeSpan.FromSeconds(30),
                    null);
                });
            });

        }

        // Configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
               
            }

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            

            // Swagger Configuration in API
            app.UseSwagger();
            app.UseSwaggerUI();

            // global cors policy
            app.UseCors("AllowReactApp");

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                 name: "default",
                 pattern: "{controller}/{action}"
                );

            });

            app.UseHttpsRedirection();



        }
    }
}
