using System.Collections.Generic;
using Xunit;
using OpenQA.Selenium.Firefox;

namespace WebGemsDev.Tests
{

    public class WebGemsDevTests
    {

        string url = "https://gemsdev.ru/geometa/";

        [Fact]
        public void Checking_for_presence_of_a_sections()
        {
            // Arrange
            FirefoxDriver driver = new FirefoxDriver();

            // Act
            driver.Navigate().GoToUrl(url);
            var sections = new List<string>(4);
            var elements = driver.FindElementsByCssSelector("section h1, section h2");

            foreach (var elem in elements)
            {
                driver.ExecuteScript($"scrollTo(0, {elem.Location.Y})");
                sections.Add(elem.Text);
            }

            // Assert
            Assert.Contains("GeoMeta", sections);
            Assert.Contains("√осударственна€ система обеспечени€ градостроительной де€тельности", sections);
            Assert.Contains("√ородска€ аналитика", sections);
            Assert.Contains("ƒругие наши продукты", sections);

            driver.Quit();
        }

        [Fact]
        public void Presence_of_a_link_to_site()
        {
            // Arrange
            FirefoxDriver driver = new FirefoxDriver();

            // Act
            driver.Navigate().GoToUrl(url);
            var link = driver.FindElementByXPath("/html/body/section[2]/div[2]/div[1]/div[2]/a")
                .GetAttribute("href");

            // Assert
            Assert.Contains(link, "https://xn--c1aaceme9acfqh.xn--p1ai/");

            driver.Quit();
        }
    }
}
