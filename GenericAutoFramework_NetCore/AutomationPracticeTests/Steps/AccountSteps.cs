using System;
using AutoFramework.Base;
using AutomationPracticeTests.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AutomationPracticeTests.Steps
{
    [Binding]
    public sealed class AccountSteps : BaseStep
    {
        private string _randomAddressName;
        public AccountSteps(DriverContext driverContext) 
            : base(driverContext)
        {
        }

        [When(@"I Fill the create address form")]
        public void WhenIFillTheCreateAddressForm(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _randomAddressName = $"{data.Address}{DateTime.Now.Ticks}".ToUpper();
            driverContext.CurrentPage.As<MyAddresses>().FillNewAddressForm(data.FirstName,  
                data.LastName, data.Address, data.City, data.State, data.PostalCode.ToString(), data.MobilePhone.ToString(), _randomAddressName);
        }

        [Then(@"I should see the address header (.*) displayed")]
        public void ThenIShouldSeeTheAddressHeaderDisplayed(string expectedAddress)
        {
            var address = driverContext.CurrentPage.As<MyAddresses>().GetAddressHeader(_randomAddressName);
            Assert.AreEqual(_randomAddressName, address);
        }
    }
}
