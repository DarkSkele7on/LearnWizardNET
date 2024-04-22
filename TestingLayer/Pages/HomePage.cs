using OpenQA.Selenium;
using LearnWizardNET.TestingLayer;
namespace TestingLayer.Pages;

public class HomePage
{
    private string RegButtonLocator = "#register";

    public void ClickOnRegBtn()
    {
        BaseTest.GetDriver().FindElement(By.Id(RegButtonLocator)).Click();
    }
}