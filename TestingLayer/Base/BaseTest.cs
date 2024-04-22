using System.Runtime.CompilerServices;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestingLayer.Pages;

namespace LearnWizardNET.TestingLayer;

[TestFixture]
public class BaseTest
{
    protected static WebDriver driver;

    protected static HomePage homePage;
    
    
    [SetUp]
    public void TestSetup()
    {
        driver = new ChromeDriver();
        InitPages();
    }
    
    [TearDown]
    public void Teardown()
    {
        driver.Quit();
    }
    
    public static WebDriver GetDriver()
    {
        return driver;
    }

    private void InitPages()
    {
        homePage = new HomePage();
    }
    
}