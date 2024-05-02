using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Program {
    public class AutomateTask{
        public static void Main(string[] args) {
            
            int i = 0;          // How many images you will download ?
            string xPath = "";  // Set The xPath
            string url = "";
            
            ChromeOptions options = new ChromeOptions();
            options.BinaryLocation = @"/usr/bin/chromium";   // Binary Chromium Location
            options.AddArgument("--headless");               // Withou window

            IWebDriver driver = new ChromeDriver(options);

            for (; i <= 2;i++){
                driver.Navigate().GoToUrl(url);

                IWebElement imageElement = driver.FindElement(By.XPath(xPath));
                WebClient webClient = new WebClient();

                string imageURL = imageElement.GetAttribute("src");

                byte[] image = webClient.DownloadData(imageURL);
                File.WriteAllBytes($"img{i}.jpg", image);

            }
        
            driver.Quit();

        }
    }
}