using OpenQA.Selenium;

namespace MyStore.Builder
{
    public partial class CartBuilder
    {
        public IWebElement CreateAccountButton => cartPage.CreateAccountButton;

        public IWebElement RegisterButton => cartPage.RegisterButton;

        public IWebElement Mr => cartPage.Mr;

        public IWebElement Mrs => cartPage.Mrs;

        public CartBuilder EmailCreate(string email)
        {
            cartPage.EmailCreate.SendKeys(email);

            return this;
        }

        public CartBuilder CreateAccountButtonClick()
        {
            cartPage.CreateAccountButton.Click();

            return this;
        }

        public CartBuilder FirstName(string firstName)
        {
            cartPage.FirstName.SendKeys(firstName);

            return this;
        }

        public CartBuilder LastName(string lastName)
        {
            cartPage.LastName.SendKeys(lastName);

            return this;
        }

        public CartBuilder Email(string email)
        {
            cartPage.Email.SendKeys(email);

            return this;
        }

        public CartBuilder Password(string password)
        {
            cartPage.Password.SendKeys(password);

            return this;
        }

        public CartBuilder DayOfBirth(int dayOfBirth)
        {
            cartPage.DayOfBirth.SendKeys(dayOfBirth.ToString());

            return this;
        }

        public CartBuilder MonthOfBirth(string monthOfBirth)
        {
            cartPage.MonthOfBirth.SendKeys(monthOfBirth);

            return this;
        }

        public CartBuilder YearOfBirth(int yearOfBirth)
        {
            cartPage.YearOfBirth.SendKeys(yearOfBirth.ToString());

            return this;
        }

        public CartBuilder SignUpForOurNewsletter()
        {
            cartPage.SignUpForOurNewsletter.Click();

            return this;
        }

        public CartBuilder ReceiveSpecialOffersFromOursPartners()
        {
            cartPage.ReceiveSpecialOffersFromOursPartners.Click();

            return this;
        }

        public CartBuilder FirstNameAddress(string firstNameAddress)
        {
            cartPage.FirstNameAddress.SendKeys(firstNameAddress);

            return this;
        }

        public CartBuilder LastNamesAddress(string lastNameAddress)
        {
            cartPage.LastNamesAddress.SendKeys(lastNameAddress);

            return this;
        }

        public CartBuilder Company(string company)
        {
            cartPage.Company.SendKeys(company);

            return this;
        }

        public CartBuilder FirstLineAddress(string firstLineAddress)
        {
            cartPage.FirstLineAddress.SendKeys(firstLineAddress);

            return this;
        }

        public CartBuilder SecondLineAddress(string secondLineAddress)
        {
            cartPage.SecondLineAddress.SendKeys(secondLineAddress);

            return this;
        }

        public CartBuilder City(string city)
        {
            cartPage.City.SendKeys(city);

            return this;
        }

        public CartBuilder State(string state)
        {
            cartPage.State.SendKeys(state);

            return this;
        }

        public CartBuilder ZipPostalCode(string zipPostalCode)
        {
            cartPage.ZipPostalCode.SendKeys(zipPostalCode);

            return this;
        }

        public CartBuilder Country(string Country)
        {
            cartPage.Country.SendKeys(Country);

            return this;
        }

        public CartBuilder AdditionalInformation(string additionalInformation)
        {
            cartPage.AdditionalInformation.SendKeys(additionalInformation);
            return this;
        }

        public CartBuilder HomePhone(string homePhone)
        {
            cartPage.HomePhone.SendKeys(homePhone);

            return this;
        }

        public CartBuilder MobilePhone(string mobilePhone)
        {
            cartPage.MobilePhone.SendKeys(mobilePhone);

            return this;
        }

        public CartBuilder AddressAlias(string addressAlias)
        {
            cartPage.AddressAlias.SendKeys(addressAlias);

            return this;
        }

        public CartBuilder RegisterButtonClick()
        {
            cartPage.RegisterButton.Click();

            return this;
        }
    }
}