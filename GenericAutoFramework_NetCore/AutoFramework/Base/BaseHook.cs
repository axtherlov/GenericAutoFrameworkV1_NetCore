﻿using System;
using AutoFramework.Browser;
using AutoFramework.Config;
using AutoFramework.Helpers;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using TechTalk.SpecFlow;
using ExtentReport = AventStack.ExtentReports.ExtentReports;

namespace AutoFramework.Base
{
    public class BaseHook : Steps
    {
        private static ExtentReport _extentReport;
        private static ExtentTest _featureName;
        private static ExtentKlovReporter _klov;

        private readonly DriverContext driverContext;
        private ExtentTest _currentScenarioName; // should not be static otherwise scenario steps will overstep each other in case of parallel testing

        public BaseHook(DriverContext driverContext) 
        {
            this.driverContext = driverContext;
        }

        public static void SetupFrameworkSettings(FileReader fileReader)
        {
            fileReader.ReadFrameworkSettings();
        }

        protected static void SetExtentReportSettings()
        {
            var htmlReporter = new ExtentHtmlReporter($"{Settings.ReportsPath}\\ExtentReport\\ExtentReport.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            
            _extentReport = new ExtentReport();
            _klov = new ExtentKlovReporter();
            _extentReport.AttachReporter(htmlReporter);
        }

        public void InitializeBrowser()
        {
            Logger.LogIn("TEST START");
            driverContext.Driver = new BrowserFactory().OpenBrowser(Settings.BrowserType);
            driverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Settings.ImplicitWaitTimeout);
            driverContext.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Settings.PageLoadTimeout);
        }

        protected void SetCurrentFeatureName(FeatureContext featureContext)
        {
            var featureTitle = featureContext.FeatureInfo.Title;
            _featureName = _extentReport.CreateTest<Feature>(featureTitle);
            Logger.LogDebug($"Feature: {featureTitle}");
        }

        protected void SetCurrentScenarioName(ScenarioContext scenarioContext)
        {
            var scenarioTitle = scenarioContext.ScenarioInfo.Title;
            _currentScenarioName = _featureName.CreateNode<Scenario>(scenarioTitle);
            Logger.LogDebug($"Scenario: {scenarioTitle}");
        }
        
        protected void SetStepResultToReport(ScenarioContext scenarioContext)
        {
            ScenarioBlock scenarioBlock = scenarioContext.CurrentScenarioBlock;
            switch (scenarioBlock)
            {
                case ScenarioBlock.None:
                    break;
                case ScenarioBlock.Given:
                    CreateNode<Given>(scenarioContext, _currentScenarioName);
                    break;
                case ScenarioBlock.When:
                    CreateNode<When>(scenarioContext, _currentScenarioName);
                    break;
                case ScenarioBlock.Then:
                    CreateNode<Then>(scenarioContext, _currentScenarioName);
                    break;
            }
        }
        
        public void CloseBrowser()
        {
            driverContext.Driver.Close();
            driverContext.Driver.Quit();
            Logger.LogOut("TEST COMPLETED");
        }

        protected static void FlushReport()
        {
            _extentReport.Flush();
        }

        #region Helpers

        private void CreateNode<T>(ScenarioContext scenarioContext, ExtentTest currentScenarioName) where T : IGherkinFormatterModel
        {
            string stepInfo = scenarioContext.StepContext.StepInfo.Text;

            if (scenarioContext.TestError != null)
            {
                string errorMessage = scenarioContext.TestError.Message;
                string stackTrace = scenarioContext.TestError.StackTrace;
                string fileName = $"{Settings.ScreenShotsPath}{DateTime.UtcNow:yyyy-MM-dd hh-mm-ss} { scenarioContext.ScenarioInfo.Title}.png";

               // TakeScreenShot(fileName);
               currentScenarioName.CreateNode<T>(stepInfo)
                   .Fail($"Error: {errorMessage}{Environment.NewLine + Environment.NewLine}StackTrace: {stackTrace}");
               //.AddScreenCaptureFromPath(fileName);
            }
            else if (scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                currentScenarioName.CreateNode<T>(stepInfo)
                    .Skip("Step definition pending");
            }
            else
            {
                currentScenarioName.CreateNode<T>(stepInfo);
            }
        }

        private void TakeScreenShot(string fileName)
        {
            var screenShot = driverContext.Driver.TakeScreenshot();
            screenShot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
            //Logger.Info($" ScreenShot Taken : {filename}");
        }

        #endregion
    }
}
