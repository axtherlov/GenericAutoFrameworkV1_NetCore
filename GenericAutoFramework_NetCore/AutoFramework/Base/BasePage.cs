using System;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AutoFramework.Base
{
    public abstract class BasePage : Base
    {
        protected static WebDriverWait wait;
        protected static Actions actions;

        protected BasePage(DriverContext driverContext) 
            : base(driverContext)
        {
            wait = new WebDriverWait(driverContext.Driver,TimeSpan.FromSeconds(10));
            actions = new Actions(driverContext.Driver);
        }
    }
}
