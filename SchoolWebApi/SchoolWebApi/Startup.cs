using SchoolWebApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolWebApi.Interface;
using SchoolWebApi.Concrate;
using SchoolWebApi.Models;

namespace SchoolWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<ISchoolRepository<Student>, StudentRepository>();
            services.AddTransient<ISchoolRepository<Teacher>, TeacherRepository>();
            services.AddTransient<ISchoolRepository<ClassName>,ClassRepository>();
            services.AddTransient<ISchoolRepository<Subject>, SubjectRepository>();



            services.AddSwaggerDocument(config=> {
                config.PostProcess = (doc =>
                {
                    doc.Info.Title = "School Api";
                    doc.Info.Contact = new NSwag.OpenApiContact()
                    {
                        Name = "Sabitov Sabit"
                    };
                });
            });

            services.AddDbContext<SchoolDb>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Db"));
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
