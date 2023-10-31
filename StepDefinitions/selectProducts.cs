using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace MyNamespace
{
    [Binding]
    public class StepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver;  // objeto do selenium

        public StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void SetUp()
        {
            // Instanciando o ChromeDriver através do WebDriverManger
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver(); // instanciou o Slelenium como ChromeDriver
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
            driver.Manage().Window.Maximize();
        }
        [AfterScenario]

        public void TearDown()
        {
            driver.Quit(); // encerrou o Selenium
        }

        [Given(@"que acesso a página inicial do site")]
        public void DadoQueAcessoAPaginaInicialDoSite()
        {
            _scenarioContext.Pending();
        }

        [When(@"preencho o usuário com ""(.*)""")]
        public void QuandoPreenchoOUsuarioCom(string p0)
        {
            _scenarioContext.Pending();
        }

        [When(@"a senha ""(.*)"" e clico no botao Login")]
        public void QuandoASenhaEClicoNoBotaoLogin(string p0)
        {
            _scenarioContext.Pending();
        }

        [When(@"adiciono o produto ""(.*)"" ao carrinho")]
        public void QuandoAdicionoOProdutoAoCarrinho(string p0)
        {
            _scenarioContext.Pending();
        }

        [When(@"clico no carrinho de compras")]
        public void QuandoClicoNoCarrinhoDeCompras()
        {
            _scenarioContext.Pending();
        }

        [Then(@"exibe ""(.*)"" no titulo da secao")]
        public void EntaoExibeNoTituloDaSecao(string products0)
        {
            _scenarioContext.Pending();
        }

        [Then(@"exibe a pagina do carrinho com a quantidade ""(.*)""")]
        public void EntaoExibeAPaginaDoCarrinhoComAQuantidade(string p0)
        {
            _scenarioContext.Pending();
        }

        [Then(@"nome do produto ""(.*)""")]
        public void EntaoNomeDoProduto(string p0)
        {
            _scenarioContext.Pending();
        }

        [Then(@"o preco com ""(.*)""")]
        public void EntaoOPrecoCom(string p0)
        {
            _scenarioContext.Pending();
        }
    }
}