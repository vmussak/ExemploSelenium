using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace ExemploSelenium
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("http://themoneyconverter.com/");

            driver.Manage().Window.Maximize();

            IWebElement valueInput = driver.FindElement(By.Id("ta"));
            IWebElement fromInput = driver.FindElement(By.Id("df"));
            IWebElement toInput = driver.FindElement(By.Id("dt"));
            IWebElement resultArea = driver.FindElement(By.Id("ratebox"));

            const string valorDigitado = "1",
                         valorEsperado = "BRL/USD = 3.7056",
                         fromValue = "USD - United States Dollar",
                         toValue = "BRL - Brazilian Real";

            valueInput.SendKeys(valorDigitado);

            var selectTo = new SelectElement(fromInput);
            var selectFrom = new SelectElement(toInput);

            selectTo.SelectByText(fromValue);
            selectFrom.SelectByText(toValue);

            Thread.Sleep(900);


            if (resultArea.GetAttribute("value") == valorEsperado)
                Console.WriteLine("Deu certo");
            else
                Console.WriteLine("Não deu certo");

            driver.Close();

            Console.ReadKey();
        }
    }
}
