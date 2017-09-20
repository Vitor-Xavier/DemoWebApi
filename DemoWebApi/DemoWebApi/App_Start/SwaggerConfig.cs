using System.Web.Http;
using WebActivatorEx;
using DemoWebApi;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]
namespace DemoWebApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "API de exemplo Entity Framework, Swagger e OAuth.");
                        c.IncludeXmlComments(GetXmlCommentsPath());
                        c.OAuth2("/Token");
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DisableValidator();
                    });
        }

        protected static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\Swagger.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
