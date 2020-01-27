using System.IO;
using Microsoft.Extensions.Configuration;

namespace AutoFramework.Config
{
    public class ConfigXmlReader : FileReader
    {
        protected override IConfigurationRoot SetupFileReader() =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddXmlFile("appSettings.xml").Build();
    }
}