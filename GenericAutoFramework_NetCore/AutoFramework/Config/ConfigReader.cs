using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using AutoFramework.Browser;
using AutoFramework.Helpers;
using Microsoft.Extensions.Configuration;

namespace AutoFramework.Config
{
    public abstract class FileReader
    {
        public void SetupFrameworkSettings()   //Template method
        {
            ReadSettingsFromFile( SetupBuilder());
        }

        protected abstract IConfigurationRoot SetupBuilder();

        protected virtual void ReadSettingsFromFile(IConfigurationRoot configRoot)
        {
            var testSettings = configRoot.GetSection("testConfiguration").Get<TestSettings>();

            if (SettingValuesAreValid(testSettings))
            {
                Settings.Aut = testSettings.Aut;
                Settings.TestType = testSettings.TestType;
                Settings.IsLog = testSettings.IsLog;
                Settings.LogPath = testSettings.LogPath;
                Settings.BrowserType = (BrowserType) Enum.Parse(typeof(BrowserType), testSettings.Browser);
                Settings.AutConnectionString = testSettings.AutConnectionString;
                Settings.ImplicitWaitTimeout = testSettings.ImplicitWaitTimeout;
                Settings.PageLoadTimeout = testSettings.PageLoadTimeout;
            }
            else
            {
                throw new Exception("Invalid values in Setting Files");
            }
        }

        private bool SettingValuesAreValid(TestSettings testSettings)
        {
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(testSettings,
                    new ValidationContext(testSettings),
                    validationResults,
                    true))
            {
                LogHelpers.Write("Error: Logging configuration is invalid!");
                foreach (var validationResult in validationResults)
                {
                    Console.WriteLine("- {0}", validationResult.ErrorMessage);
                }
            }

            return validationResults.Count == 0;
        }
    }

    public class ConfigXmlReader : FileReader
    {
        protected override IConfigurationRoot SetupBuilder() =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddXmlFile("appSettings.xml").Build();
    }
   
    public class ConfigJsonReader : FileReader
    {
        protected override IConfigurationRoot SetupBuilder() =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json").Build();
    }

    public class ConfigReader2
    {
        public static void SetupFrameworkSettings(FileReader fileReader)
        {
            fileReader.SetupFrameworkSettings();
        }
    }

    public static class ConfigReader
    {
        public static void SetFrameworkSettingsJson()
        {
            var configBuilder = SetupJsonBuilder();
            ReadSettingsFromConfigFile(configBuilder);
        }

        public static void SetFrameworkSettingXml()
        {
            var configBuilder = SetupXmlBuilder();
            ReadSettingsFromConfigFile(configBuilder);
        }

        private static IConfigurationRoot SetupJsonBuilder() =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json").Build();

        private static IConfigurationRoot SetupXmlBuilder() =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddXmlFile("appSettings.xml").Build();

        private static void ReadSettingsFromConfigFile(IConfigurationRoot configBuilder)
        {
            Settings.Aut = configBuilder.GetSection("testConfiguration").Get<TestSettings>().Aut;
            Settings.TestType = configBuilder.GetSection("testConfiguration").Get<TestSettings>().TestType;
            Settings.IsLog = configBuilder.GetSection("testConfiguration").Get<TestSettings>().IsLog;
            Settings.LogPath = configBuilder.GetSection("testConfiguration").Get<TestSettings>().LogPath;
            Settings.BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), configBuilder.GetSection("testConfiguration").Get<TestSettings>().Browser);
            Settings.AutConnectionString = configBuilder.GetSection("testConfiguration").Get<TestSettings>().AutConnectionString;
        }

        //public static void SetFrameworkSettings2()
        //{
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddXmlFile("appSettings.xml");

        //    IConfigurationRoot configRoot = builder.Build();

        //    //string adminEmail1 = configRoot["SiteSettings:AdminEmail"];
            
        //    Settings.AUT = configRoot.GetSection("testConfiguration").Get<TestSettings>().Aut;;
        //    Settings.TestType = configRoot.GetSection("testConfiguration").Get<TestSettings>().TestType;
        //    var asd1 = configRoot.GetSection("testSettings:testSetting");
        //    var asd2 = configRoot.GetSection("testSetting:staging");
        //    var asd3 = configRoot.GetSection("staging");
        //    var asd1x = configRoot.GetSection("testSettings:staging");

        //    Settings.AUT = configRoot.GetSection("testConfiguration").Get<TestSettings>().Aut;
        //}
    }
}
