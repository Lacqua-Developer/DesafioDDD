using Microsoft.Extensions.Configuration;

namespace Catalogo.Core
{
    public class Config
    {
        static IConfigurationRoot CurrentConfiguration { get; set; }

        static Config()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");


        }

        public static string DefaultConnectionString => CurrentConfiguration.GetConnectionString("DefaultConnection");


    }
}