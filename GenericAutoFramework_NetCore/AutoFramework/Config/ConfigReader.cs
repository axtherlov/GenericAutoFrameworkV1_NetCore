using System;
using System.IO;
using AutoFramework.Base;
using Microsoft.Extensions.Configuration;

namespace AutoFramework.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json");

            IConfigurationRoot configRoot = builder.Build();

            Settings.AUT = configRoot.GetSection("testSettings").Get<TestSettings>().Aut;
            Settings.TestType = configRoot.GetSection("testSettings").Get<TestSettings>().TestType;
            Settings.IsLog = configRoot.GetSection("testSettings").Get<TestSettings>().IsLog;
            Settings.LogPath = configRoot.GetSection("testSettings").Get<TestSettings>().LogPath;
            Settings.BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), configRoot.GetSection("testSettings").Get<TestSettings>().Browser);
            Settings.AutConnectionString = configRoot.GetSection("testSettings").Get<TestSettings>().AutConnectionString;
        }
    }
}
