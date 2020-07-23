using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

public static class WebDriverFactory
{
    public static object driver { get; private set; }

    public static IWebDriver CreateWebDriver(WebBrowser name)
    {
        switch (name)
        {
            case WebBrowser.Firefox:
                return new FirefoxDriver();  
            case WebBrowser.Chrome:
                
        
        default:
                
                return new ChromeDriver();
        }
    }
}

public enum WebBrowser
{    
    Firefox,
    Chrome
}