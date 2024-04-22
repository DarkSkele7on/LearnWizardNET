using LearnWizardNET.TestingLayer;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TestingLayer.Pages;

namespace TestingLayer.Test;

public class TestClass1 : BaseTest
{
    [Test]
    public void TestMethod1()
    {
        driver.Navigate().GoToUrl("https://selenium.dev");
        Thread.Sleep(5000);
        homePage.ClickOnRegBtn();
    }
}