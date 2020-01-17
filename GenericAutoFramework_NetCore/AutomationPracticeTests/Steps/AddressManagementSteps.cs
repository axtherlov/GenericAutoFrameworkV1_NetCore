using System;
using AutoFramework.Base;
using AutomationPracticeTests.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AutomationPracticeTests.Steps
{
    [Binding, Scope(Feature = "Address Management")]
    public sealed class AddressManagementSteps : MenuSteps
    {
        private string _randomAddressName;
        public AddressManagementSteps(DriverContext driverContext) 
            : base(driverContext)
        {
        }

        [Given(@"I navigated to Address creation form")]
        public void GivenINavigatedToAddressCreationForm()
        {
            driverContext.CurrentPage = NavigateToAddressCreationForm();
        }

        [When(@"I Fill the create address form")]
        public void WhenIFillTheCreateAddressForm(Table table)
        {
            dynamic data = table.CreateDynamicInstance(); //only valid when table has single row or 2 columns with multiple rows
                                                          //use foreach loop for multiple rows
            _randomAddressName = $"{data.Address}{DateTime.Now.Ticks}".ToUpper();

            driverContext.CurrentPage.As<MyAddresses>().FillNewAddressForm(data.FirstName,
                data.LastName, data.Address, data.City, data.State, data.PostalCode.ToString(), data.MobilePhone.ToString(), _randomAddressName);
        }

        [Then(@"The address should be created")]
        public void ThenTheAddressShouldBeCreated()
        {
            driverContext.CurrentPage.As<MyAddresses>().ClickSaveAddress();
            var address = driverContext.CurrentPage.As<MyAddresses>().GetAddressHeader(_randomAddressName);
            Assert.AreEqual(_randomAddressName, address);
        }
    }
}
