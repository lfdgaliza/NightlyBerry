using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using Swashbuckle.AspNetCore.Swagger;

namespace NightlyBerry.LinuxTree.Presentation.API
{
    public static class SwaggerConfiguration
    {
        const string SwaggerTitle = "Nightly Berry - LinuxTree";
        public static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
             {
                 c.SwaggerDoc("v1", new Info { Title = SwaggerTitle, Version = "v1" });

                 //var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                 //var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                 //var commentsFile = Path.Combine(baseDirectory, commentsFileName);

                 //c.IncludeXmlComments(commentsFile);
             });
        }

        public static void UseSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", SwaggerTitle);
            });
        }
    }
}
