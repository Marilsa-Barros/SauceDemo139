// Bibliotecas
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

// Namespace
namespace StepDefinitionsPO
{
    [Binding] // Marcação de que a classe segue o padrão SpecFlow
    public class Hooks
    {
        // Atributos / Objetos
         private ScenarioContext _scenarioContext; // interno a classe
        private IWebDriver driver;

        // Métodos / Funções
        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext; // externo a classe
        }

        [BeforeScenario]
        public void ScenarioSetup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            driver.Manage().Window.Maximize();
            _scenarioContext["driver"] = driver;
            Console.WriteLine("Iniciando: " + _scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void ScenarioTearDow()
        {
            driver = (IWebDriver) _scenarioContext["driver"];
            driver.Quit();
        }

    }
    
}
