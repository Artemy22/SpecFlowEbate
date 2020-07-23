using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowTest
{
       class Basic
    {       
        private readonly Credentials creds = new Credentials();

        public MainMenuPageObject LoginFlow(IWebDriver driver)
        {
            var loginPage = new LoginTabPageObject(driver);
            var loginTenantnPage = new LoginTenantTabPageObject(driver);
            loginPage.Login(creds.Email, creds.Password);
            loginPage.ClickSaveBtn();

            loginTenantnPage.ChooseFirstTenant();
            return new MainMenuPageObject(driver);
        }
    }
}
