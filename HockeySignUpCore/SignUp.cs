using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Configuration;
using OpenQA.Selenium;
using System.Reflection;

namespace HockeySignUpCore
{
    class SignUp
    {
        public void signup (string URI, string firstName, string lastName, string email)
        {
            // Initialize the Chrome Driver
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            //using (var driver = new ChromeDriver(""))
            {
                // Go to the specific signup page
                driver.Navigate().GoToUrl(URI);

                // Get the page elements
                var userNameField = driver.FindElementByName("name");
                var userPasswordField = driver.FindElementByName("email");
                var loginButton = driver.FindElementByXPath("//button[@type='submit'][text()='Make Reservation']");

                // Type user name and password
                //userNameField.SendKeys(ConfigurationManager.AppSettings["name"]);
                //userPasswordField.SendKeys(ConfigurationManager.AppSettings["email"]);
                userNameField.SendKeys(firstName + " " + lastName);
                userPasswordField.SendKeys(email);

                //check the time and wait until 07:00:00:01
                //Helper h = new Helper();
                //h.GetTime();

                // Click the login button
                loginButton.Click();
                System.Threading.Thread.Sleep(1000);

                // Grab all the text within the body tag and re-try the login
                int x = 1;
                while (driver.FindElementByTagName("body").Text.Contains("Reservations may not be made until 24 hours prior to the start time of the class.") & (x <= 15000))
                {
                    driver.Navigate().Back();
                    System.Threading.Thread.Sleep(100);
                    x++;
                    driver.FindElementByXPath("//button[@type='submit'][text()='Make Reservation']").Click();
                }


                // Extract the text and save it into result.txt
                //var result = driver.FindElementByXPath("//div[@id='case_login']/h3").Text;
                //File.WriteAllText("result.txt", result);

                // Take a screenshot and save it into screen.png 
                driver.GetScreenshot().SaveAsFile(@"ScreenShot.png", OpenQA.Selenium.ScreenshotImageFormat.Png);
                //driver.GetScreenshot().SaveAsFile(@"D:\repo\dotnetCoreHockeySignUp\HockeySignUpCore\bin\Debug\netcoreapp2.1\SPF.png", OpenQA.Selenium.ScreenshotImageFormat.Png);
                driver.Close();
            }
        }

    }
}
