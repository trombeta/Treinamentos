using OpenQA.Selenium;

namespace MyStore.PageObjects
{
    public partial class CartPage
    {
        public IWebElement EmailCreate => driver.FindElement(By.Name("email_create"));

        public IWebElement CreateAccountButton => driver.FindElement(By.Id("SubmitCreate"));

        public IWebElement Mr => driver.FindElement(By.Id("id_gender1"));

        public IWebElement Mrs => driver.FindElement(By.Id("id_gender2"));

        public IWebElement FirstName => driver.FindElement(By.Name("customer_firstname"));

        public IWebElement LastName => driver.FindElement(By.Name("customer_lastname"));

        public IWebElement Email => driver.FindElement(By.Name("email"));

        public IWebElement Password => driver.FindElement(By.Name("passwd"));

        public IWebElement DayOfBirth => driver.FindElement(By.Name("days"));

        public IWebElement MonthOfBirth => driver.FindElement(By.Name("months"));

        public IWebElement YearOfBirth => driver.FindElement(By.Name("years"));

        public IWebElement SignUpForOurNewsletter => driver.FindElement(By.Name("newsletter"));

        public IWebElement ReceiveSpecialOffersFromOursPartners => driver.FindElement(By.Name("optin"));

        public IWebElement FirstNameAddress => driver.FindElement(By.Name("firstname"));

        public IWebElement LastNamesAddress => driver.FindElement(By.Name("lastname"));

        public IWebElement Company => driver.FindElement(By.Name("company"));

        public IWebElement FirstLineAddress => driver.FindElement(By.Name("address1"));

        public IWebElement SecondLineAddress => driver.FindElement(By.Name("address2"));

        public IWebElement City => driver.FindElement(By.Name("city"));

        public IWebElement State => driver.FindElement(By.Name("id_state"));

        public IWebElement ZipPostalCode => driver.FindElement(By.Name("postcode"));

        public IWebElement Country => driver.FindElement(By.Name("id_country"));

        public IWebElement AdditionalInformation => driver.FindElement(By.Name("other"));

        public IWebElement HomePhone => driver.FindElement(By.Name("phone"));

        public IWebElement MobilePhone => driver.FindElement(By.Name("phone_mobile"));

        public IWebElement AddressAlias => driver.FindElement(By.Name("alias"));

        public IWebElement RegisterButton => driver.FindElement(By.Id("submitAccount"));
    }
}