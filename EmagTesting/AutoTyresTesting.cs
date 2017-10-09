using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using EmagTesting.Pages;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using System.Drawing.Imaging;

namespace EmagTesting
{
    [TestClass]
    public class AutoTyresTesting
    {
        IWebDriver driverChrome = new ChromeDriver();

        [TestInitialize]
        public void TestInitialize()
        {
            driverChrome.Url = "https://www.emag.bg/homepage?ref=emag_CMP-733";
            driverChrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            Console.OutputEncoding = System.Text.Encoding.GetEncoding("Cyrillic");
            Console.InputEncoding = System.Text.Encoding.GetEncoding("Cyrillic");
            driverChrome.Manage().Window.Maximize();
            driverChrome.Manage().Cookies.DeleteAllCookies();

        }


        [TestMethod]
        public void WhereAreAutoTyresSituated()
        {
            MainPage mainPage = new MainPage(driverChrome);
            mainPage.LinkToAllCategories.Click();
            AllCatergoriesPage allcategoriesPage = new AllCatergoriesPage(driverChrome);
            Thread.Sleep(3000);
            allcategoriesPage.ShortcutToInsuranceAndAutoCategory.Click();
            //check for  Autotyres in the "Insurance and Auto" category
            Assert.IsTrue(allcategoriesPage.IsAutoTyresIntoInsuranceAndAutoCategory.Displayed, "There is no subsubcategory \"Auto Tyres\" or its position is not in the category \"Insurance and Auto\"  ");
            //check in which directory is situated; If is not in the subcategory "Tyres and wheels directory" the test should fail
            IList<IWebElement> tyresAndWheels = driverChrome.FindElements(By.XPath("//a[@href='/gumi-dzhanti/sd?tree_ref=1448 ']/following-sibling::ul/li"));
            bool areAutoTyresInTheTyresAndWheelsCategory = false;
            foreach (var subCategory in tyresAndWheels)
            {
                if (subCategory.Text.ToString() == "Автомобилни гуми")
                {
                    areAutoTyresInTheTyresAndWheelsCategory = true;
                }
            }
            Assert.IsTrue(areAutoTyresInTheTyresAndWheelsCategory, "AutoTyres is not in the Tyres and Wheels category");
            //Look for winter tyres 225/65/17 
            
            Thread.Sleep(3000);
            allcategoriesPage.AutoTyres.Click();
            TyresPage tyresPage = new TyresPage(driverChrome);
            SelectElement Season = tyresPage.selectSeason();
            Season.SelectByValue("8707");
            SelectElement Width = tyresPage.selectWidth();
            Width.SelectByValue("-1540388");
            Thread.Sleep(3000);
            SelectElement Height = tyresPage.selectHeight();
            Height.SelectByText("65");
            Thread.Sleep(3000);
            SelectElement Diameter = tyresPage.selectDiameter();
            Diameter.SelectByValue("8695");
            Thread.Sleep(3000);
            tyresPage.ShowTheResultsRealButton.Click();

            //check the result- did all the pictures are shown
            IList<IWebElement> tyreResults = driverChrome.FindElements(By.ClassName("product-holder-grid"));
            foreach (var element in tyreResults)
            {
                IWebElement picture = element.FindElement(By.XPath("//img"));
                Assert.IsTrue(picture.Displayed);
            }
            //screenshot of the result
            driverChrome.TakeScreenshot().SaveAsFile("tyreResultsPicture.jpg", ScreenshotImageFormat.Jpeg);
        }
    }
}
