using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagTesting.Pages
{
    class TyresPage
    {
        public TyresPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        
        [FindsBy(How = How.Name, Using = "2736")]
        private IWebElement SeasonDropDown;
        public SelectElement selectSeason()
        {
           return new SelectElement(SeasonDropDown);
        }

        [FindsBy(How = How.Name, Using = "2733")]
        private IWebElement WidthDropDown;
        public SelectElement selectWidth()
        {
            return new SelectElement(WidthDropDown);
        }

        [FindsBy(How = How.Name, Using = "2734")]
        private IWebElement HeightDropDown;
        public SelectElement selectHeight()
        {
            return new SelectElement(HeightDropDown);
        }

        [FindsBy(How = How.Name, Using = "2735")]
        private IWebElement DiameterDropDown;
        public SelectElement selectDiameter()
        {
            return new SelectElement(DiameterDropDown);
        }

        
        [FindsBy(How = How.ClassName, Using = "buton_rezultate")]
        public IWebElement ShowTheResultsRealButton { get; set; }
        

    }
}
