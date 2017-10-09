using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagTesting.Pages
{
    class AllCatergoriesPage
    {

        public AllCatergoriesPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "id_760")]
        public IWebElement ShortcutToInsuranceAndAutoCategory { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='departments-page']//div[@id='department-expanded' and descendant::h5[contains(., 'Автомобилни гуми')]]")]
        public IWebElement IsAutoTyresIntoInsuranceAndAutoCategory { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='department - expanded']/ul/li[1]/a")]
        public IWebElement DoesAutoTyresBelongsToTyresAndWheels { get; set; }

        [FindsBy(How = How.XPath, Using = "//h5[contains(text(), 'Автомобилни гуми')]")]
        public IWebElement AutoTyres { get; set; }

       
    }
}
