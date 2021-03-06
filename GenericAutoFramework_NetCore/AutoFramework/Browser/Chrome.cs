﻿using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AutoFramework.Browser
{
    public class Chrome : IBrowser
    {
        public ChromeDriver Init()
        {
            SetupDriverManager();
            return new ChromeDriver(GetOptions());
        }

        public void SetupDriverManager() => new DriverManager().SetUpDriver(new ChromeConfig());

        private ChromeOptions GetOptions()
        {
            var options = new ChromeOptions();
            options.AddArgument("--incognito");
            return options;
        }
    }
}