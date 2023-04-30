using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using System.Threading;
using System.Windows;


namespace WPFPlayground
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ExecuteMethod();
        }

        private void ExecuteMethod()
        {
            string json = File.ReadAllText(@"D:\Extra Learning\WebAutomationConfigurationFiles\NetGear24Toggle.json");

            var jsonObject = JsonConvert.DeserializeObject(json);

            //var jsonArray = (JArray)jsonObject;



            if (jsonObject is JObject jobject && jobject["Commands"] is JArray jsonArray)
            {
                IWebDriver driver = new ChromeDriver();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                try
                {
                    //string url = (string)jsonObject.Commands[0].Target;
                    foreach (var command in jsonArray)
                    {
                        string cmd = command["Command"].ToString();
                        string target = command["Target"].ToString();
                        string keyValue = command["Value"].ToString();
                        string targetXpath = "";

                        //string xpath = "";

                        //if (command["Targets"] is JArray targets && targets.Count > 0)
                        //{
                        //    xpath = targets[]
                        //}
                        if (target.Contains("xpath="))
                        {
                            targetXpath = target.Replace("xpath=", "");
                        }

                        switch (cmd)
                        {
                            case "open":
                                driver.Navigate().GoToUrl(target);
                                Thread.Sleep(2000);
                                break;

                            case "click":
                                //string xpathTarget = target.Replace("xpath=", "");
                                //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(targetXpath)));
                                //Thread.Sleep(2000);
                                driver.FindElement(By.XPath(targetXpath)).Click();

                                Thread.Sleep(2000);
                                break;

                            case "type":
                                //string xpathTarget = target.Replace("xpath=", "");
                                //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(targetXpath)));
                                driver.FindElement(By.XPath(targetXpath)).SendKeys(keyValue);
                                Thread.Sleep(2000);
                                break;

                            case "clickAndWait":
                                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(targetXpath)));
                                driver.FindElement(By.XPath(targetXpath)).Click();
                                Thread.Sleep(2000);
                                break;

                            default:
                                Console.WriteLine("Invalid case detected");
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                Console.WriteLine("False array");
            }            
        }
    }

    
}
