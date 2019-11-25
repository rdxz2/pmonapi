using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using pmonapi.Domains.Models;
using pmonapi.Domains.Repositories;
using pmonapi.Domains.Services;
using pmonapi.Repositories;
using pmonapi.Services;
// 

namespace pmonapi {
  public class Startup {
    public Startup (IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices (IServiceCollection services) {
      services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_2);

      // cors policy
      services.AddCors (o => o.AddPolicy ("PmonCorsPolicy", builder => {
        builder.AllowAnyOrigin ()
          .AllowAnyMethod ()
          .AllowAnyHeader ()
          .Build ();
      }));

      // autentikasi menggunakan jwt
      services.AddAuthentication (JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer (options => {
          options.TokenValidationParameters = new TokenValidationParameters {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
          ValidIssuer = Configuration["Jwt:Issuer"],
          ValidAudience = Configuration["Jwt:Issuer"],
          IssuerSigningKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes (Configuration["Jwt:Key"]))
          };
        });

      // registrasi konteks database
      services.AddDbContext<ContextPmondb> (option => option.UseMySql (Configuration.GetConnectionString ("Pmondb")));

      // dependency injection untuk repository
      services.AddScoped<IRepositoryMasterUser, RepositoryMasterUser> ();
      services.AddScoped<IRepositoryMasterUserDetail, RepositoryMasterUserDetail> ();
      services.AddScoped<IUnitOfWork, UnitOfWork> ();

      // dependency injection untuk service
      services.AddScoped<IServiceAuthentication, ServiceAuthentication> ();
      services.AddScoped<IServiceMasterUser, ServiceMasterUser> ();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure (IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {
      if (env.IsDevelopment ()) {
        app.UseDeveloperExceptionPage ();
      } else {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts ();
      }

      // cors
      app.UseCors ("PmonCorsPolicy");

      // autentikasi
      app.UseAuthentication ();

      app.UseHttpsRedirection ();
      app.UseMvc ();
    }
  }
}