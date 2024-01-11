using System;
using System.Text;
using dosLogistic.API.Brokers.DataTimes;
using dosLogistic.API.Brokers.Emails;
using dosLogistic.API.Brokers.Loggings;
using dosLogistic.API.Brokers.Storages;
using dosLogistic.API.Brokers.Tokens;
using dosLogistic.API.Services.Foundatioins.Emails;
using dosLogistic.API.Services.Foundatioins.Messages;
using dosLogistic.API.Services.Foundatioins.Parcels;
using dosLogistic.API.Services.Foundatioins.Products;
using dosLogistic.API.Services.Foundatioins.Receivers;
using dosLogistic.API.Services.Foundatioins.Securities;
using dosLogistic.API.Services.Foundatioins.Senders;
using dosLogistic.API.Services.Foundatioins.Users;
using dosLogistic.API.Services.Orchestrations;
using dosLogistic.API.Services.Processings.CurrentUserDetails;
using dosLogistic.API.Services.Processings.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace dosLogistic.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<StorageBroker>();
            RegisterBrokers(services);
            AddFoundationServices(services);
            AddProcessingServices(services);
            AddOrchestrationServices(services);
            RegisterJwtConfigurations(services, Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    name: "v1",
                    info: new OpenApiInfo { Title = "dosLogistic.API", Version = "v1" });

                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(config => config.SwaggerEndpoint(
                url: "/swagger/v1/swagger.json",
                name: "dosLogistic.API v1"));
            var newApp = app.Build();

            if (app.ApplicationServices.GetService<IHttpContextAccessor>() != null)
                CurrentUserDetaile.contextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                endpoints.MapControllers());
        }

        private static void RegisterBrokers(IServiceCollection services)
        {
            services.AddTransient<IStorageBroker, StorageBroker>();
            services.AddTransient<ILoggingBroker, LoggingBroker>();
            services.AddTransient<IDateTimeBroker, DateTimeBroker>();
            services.AddTransient<ITokenBroker, TokenBroker>();
            services.AddTransient<IEmailBroker, EmailBroker>();
        }

        private static void AddFoundationServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IParcelSerivce, ParcelService>();
            services.AddTransient<IReceiverService, ReceiverService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ISenderService, SenderService>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        }

        private static void AddProcessingServices(IServiceCollection services) =>
            services.AddTransient<IUserProcessingService, UserProcessingService>();

        private static void AddOrchestrationServices(IServiceCollection services) =>
            services.AddTransient<IUserSecurityOrchestrationService, UserSecurityOrchestrationService>();

        private static void RegisterJwtConfigurations(IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    string key = configuration.GetSection("Jwt").GetValue<string>("Key");
                    byte[] convertKeyToBytes = Encoding.UTF8.GetBytes(key);

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(convertKeyToBytes),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = true,
                        ValidateLifetime = true
                    };
                });
        }
    }
}
