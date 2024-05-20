using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FarmerApp.API.Utils.Swagger
{
    public class SwaggerRouteExtenderDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var env = Environment.GetEnvironmentVariable("ENVIRONMENT", EnvironmentVariableTarget.Process);
            if (env == "DEV")
            {
                var paths = new OpenApiPaths();

                foreach (var path in swaggerDoc.Paths)
                {
                    paths.Add("/dev" + path.Key, path.Value);
                }

                swaggerDoc.Paths = paths;
            }
        }
    }
}
