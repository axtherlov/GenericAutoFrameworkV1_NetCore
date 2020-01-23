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
                Settings.LogsPath = testSettings.LogsPath;
                Settings.ScreenShotsPath = testSettings.ScreenShotsPath;
                Settings.ReportsPath = testSettings.ReportsPath;
                Settings.BrowserType = (BrowserType) Enum.Parse(typeof(BrowserType), testSettings.Browser);
                Settings.AutConnectionString = testSettings.AutConnectionString;
                Settings.ImplicitWaitTimeout = testSettings.ImplicitWaitTimeout;
                Settings.PageLoadTimeout = testSettings.PageLoadTimeout;

                Logger.LogIn("Configuration file read successfully");
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
                foreach (var validationResult in validationResults)
                {
                    Logger.LogError(validationResult.ErrorMessage);
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

    public class ConfigReader
    {
        public static void SetupFrameworkSettings(FileReader fileReader)
        {
            fileReader.SetupFrameworkSettings();
        }
    }
  
}
