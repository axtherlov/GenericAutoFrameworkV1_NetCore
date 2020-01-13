using AutoFramework.Base;
using AutoFramework.Extensions;
using OpenQA.Selenium;

namespace AutomationPracticeTests.Pages
{
    public class MyAddresses : MenuPage
    {
        public MyAddresses(ParallelConfig parallelConfig) 
            : base(parallelConfig)
        {
        }

        //[FindsBy(How = How.XPath, Using = "//a[@title='Delete']")]
        private IWebElement _deleteLink => parallelConfig.Driver.FindElement(By.XPath("//a[@title='Delete']"));

        //[FindsBy(How = How.XPath, Using = "//a[@title='Add an address']")]
        private IWebElement _addNewAddressLink => parallelConfig.Driver.FindElement(By.XPath("//a[@title='Add an address']"));
        
        //[FindsBy(How = How.Id, Using = "firstname")]
        private IWebElement _firstNameInput => parallelConfig.Driver.FindElement(By.Id("firstname"));

        //[FindsBy(How = How.Id, Using = "lastname")]
        private IWebElement _lastNameInput => parallelConfig.Driver.FindElement(By.Id("lastname"));

        //[FindsBy(How = How.Id, Using = "address1")]
        private IWebElement _firstAddressInput  => parallelConfig.Driver.FindElement(By.Id("address1"));

        //[FindsBy(How = How.Id, Using = "city")]
        private IWebElement _cityInput => parallelConfig.Driver.FindElement(By.Id("city"));

        //[FindsBy(How = How.Id, Using = "id_state")]
        private IWebElement _stateDropDown => parallelConfig.Driver.FindElement(By.Id("id_state"));

        //[FindsBy(How = How.Id, Using = "postcode")]
        private IWebElement _postalCodeInput => parallelConfig.Driver.FindElement(By.Id("postcode"));

        //[FindsBy(How = How.Id, Using = "phone_mobile")]
        private IWebElement _mobilePhoneInput => parallelConfig.Driver.FindElement(By.Id("phone_mobile"));

        //[FindsBy(How = How.Id, Using = "submitAddress")]
        private IWebElement _sendButton  => parallelConfig.Driver.FindElement(By.Id("submitAddress"));

        public void ClickDeleteLink()
        {
            _deleteLink.Click();
        }

        public void AcceptDeletePopup()
        {
            parallelConfig.Driver.SwitchTo().Alert().Accept();
        }

        public void ClickSubmitAddress()
        {
            _sendButton.Click();
        }

        public void FillNewAddressForm(string firstName, string lastName, string firstAddress, string city,
            string state, string postalCode, string mobilePhone)
        {
            _firstNameInput.SendKeys(firstName);
            _lastNameInput.SendKeys(lastName);
            _firstAddressInput.SendKeys(firstAddress);
            _cityInput.SendKeys(city);
            _stateDropDown.SelectDropDownList(state);
            _postalCodeInput.SendKeys(postalCode);
            _mobilePhoneInput.SendKeys(mobilePhone);
        }
    }
}