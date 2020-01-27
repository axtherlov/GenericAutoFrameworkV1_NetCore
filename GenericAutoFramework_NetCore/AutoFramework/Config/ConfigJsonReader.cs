using System.IO;
using Microsoft.Extensions.Configuration;

namespace AutoFramework.Config
{
    public class ConfigJsonReader : FileReader
    {
        protected override IConfigurationRoot SetupFileReader() =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json").Build();
    }
}