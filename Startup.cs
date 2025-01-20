using BALayer;
using BALayer.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace RIMC_WEBAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["Jwt:Site"],
                    ValidIssuer = Configuration["Jwt:Site"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SigningKey"]))
                };
            });
          

            services.AddSingleton<IMediBusiness, MediBusinessLayer>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "RIMC_WEBAPI", Version = "v1" }); });
            //services.AddCors(c =>
            //{
            //    c.AddPolicy("AllowOrigin", options => options.WithOrigins("https://localhost:44339"));
            //    //c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            //});

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:44339", "https://localhost:44389", "https://www.relainstitute.com", "https://testing.in.salucro.net",
                            "https://test.payu.in", "https://acssimuat.payubiz.in", "https://localhost:44302", "http://172.17.92.241/", "http://localhost:3000",
                            "http://localhost:3001", "http://localhost:3002", "http://localhost:3000", "http://192.168.15.18:5075", "http://192.168.15.18:5075/", "http://192.168.15.18:5049",
                            "http://relainstitute.in:5039", "http://192.168.15.14:5039", "http://192.168.6.26:5039", "http://125.20.61.155:5049", "http://125.20.61.155:5075",
                            "http://125.20.61.155:5048", "http://125.20.61.155:5074", "http://192.168.15.18:5074", "http://192.168.15.18:5048", "http://192.168.15.18:5092",
                            "http://192.168.15.18:5093", "http://125.20.61.155:5093/", "http://192.168.15.18:5010", "http://192.168.15.18:5046", "http://192.168.15.40:5001",
                            "http://180.235.120.76:5001", "https://phc.relainstitute.com", "http://180.235.120.76:5002", "http://180.235.120.76:5003", "http://180.235.120.76:5004",
                            "http://180.235.120.76:5005", "https://phc.relainstitute.com:5002", "http://192.168.15.40:8081", "http://localhost:5173", "http://192.168.36.19",
                            "http://192.168.15.18:7020", "http://125.20.61.155:5050", "http://192.168.15.18:5050", "http://192.168.15.18:5096", "http://192.168.15.40:5003",
                            "http://192.168.15.40:5005", "http://192.168.15.18:5098", "http://192.168.15.18:5099", "http://192.168.15.40:5002", "http://180.235.120.76:5002/",
                            "http://localhost:5173/", "http://192.168.15.18:6040", "http://localhost:5173", "http://125.20.61.155:6040", "https://events.relainstitute.com:8082",
                            "http://localhost:5174/", "http://192.168.15.18:4061", "http://192.168.15.18:5040", "http://192.168.15.44:81/", "http://192.168.15.44:81", 
                            "http://192.168.15.18:5097","http://192.168.15.18:4064/", "http://192.168.15.18:4064", "https://events.relainstitute.com:8082/", "http://192.168.15.18:6010",
                            "http://192.168.15.18:6021", "http://192.168.15.18:8089", "http://192.168.15.18:8098","http://192.168.15.18:8091", "http://192.168.15.18:8092",
                            "http://192.168.15.18:8093", "http://192.168.15.18:8094", "http://192.168.15.18:8095","http://192.168.15.18:8096", "http://192.168.15.18:8097", 
                            "http://192.168.15.18:8081","http://camp.relainstitute.com:8085", "http://192.168.15.18:8082","https://camp.relainstitute.com:8086",
                            "http://192.168.15.18:9021","http://localhost:5174", "http://localhost:5173/billingdisplay", "http://192.168.15.18:8063", 
                            "http://192.168.15.18:8064", "http://192.168.15.40:8093", "https://pre-auth.relainstitute.com:8094",
                            "https://pre-auth.relainstitute.com:8094/", "http://192.168.15.18:8065")
                        .AllowAnyHeader()
                        .AllowAnyHeader()
                        .AllowAnyMethod();

                    });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "RIMC_WEBAPI v1"); });
            }
            else
            {
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseStatusCodePages();
            //app.UseCors(options => options.AllowAnyOrigin());
            //app.UseCors(options => options.WithOrigins("https://localhost:44339/"));
            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
            app.UseHttpsRedirection();
        }
    }
}
