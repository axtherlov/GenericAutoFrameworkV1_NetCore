using System.Collections.Generic;
using System.Linq;
using AutoFramework.Base;
using AutoFramework.Extensions;
using OpenQA.Selenium;

namespace AutomationPracticeTests.Pages
{
    public class MyAddresses : MenuPage
    {
        private IWebElement _deleteLink => driverContext.Driver.FindElement(By.XPath("//a[@title='Delete']"));
        private IWebElement _addNewAddressLink => driverContext.Driver.FindElement(By.XPath("//a[@title='Add an address']"));
        private IWebElement _firstNameInput => driverContext.Driver.FindElement(By.Id("firstname"));
        private IWebElement _lastNameInput => driverContext.Driver.FindElement(By.Id("lastname"));
        private IWebElement _firstAddressInput  => driverContext.Driver.FindElement(By.Id("address1"));
        private IWebElement _cityInput => driverContext.Driver.FindElement(By.Id("city"));
        private IWebElement _stateDropDown => driverContext.Driver.FindElement(By.Id("id_state"));
        private IWebElement _postalCodeInput => driverContext.Driver.FindElement(By.Id("postcode"));
        private IWebElement _mobilePhoneInput => driverContext.Driver.FindElement(By.Id("phone_mobile"));
        private IWebElement _aliasInput => driverContext.Driver.FindElement(By.Id("alias"));
        private IWebElement _addAddressLink => driverContext.Driver.FindElement(By.XPath("//a[@title='Add an address']"));
        private IWebElement _sendButton  => driverContext.Driver.FindElement(By.Id("submitAddress"));
        private List<IWebElement> _addressHeaders  => driverContext.Driver.FindElements(By.XPath("//h3[@class='page-subheading']")).ToList();

        public MyAddresses(DriverContext driverContext) 
            : base(driverContext)
        {
        }

        public void ClickAddNewAddressLink()
        {
            _addAddressLink.Click();
        }

        public void ClickDeleteLink()
        {
            _deleteLink.Click();
        }

        public void AcceptDeletePopup()
        {
            driverContext.Driver.SwitchTo().Alert().Accept();
        }

        public void ClickSaveAddress()
        {
            _sendButton.Click();
        }

        public void FillNewAddressForm(string firstName, string lastName, string firstAddress, string city,
            string state, string postalCode, string mobilePhone, string alias)
        {
            _firstNameInput.Clear();
            _firstNameInput.SendKeys(firstName);
            _lastNameInput.Clear();
            _lastNameInput.SendKeys(lastName);
            _firstAddressInput.SendKeys(firstAddress);
            _cityInput.SendKeys(city);
            _stateDropDown.SelectDropDownList(state);
            _postalCodeInput.SendKeys(postalCode);
            _mobilePhoneInput.SendKeys(mobilePhone);
            _aliasInput.Clear();
            _aliasInput.SendKeys(alias);
        }

        public string GetAddressHeader(string addressName)
        {
            var found = _addressHeaders.FirstOrDefault(x => x.Text == addressName);
            return found?.Text ?? "";
        }
    }
}