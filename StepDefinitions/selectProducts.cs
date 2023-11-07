using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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
            // Instanciando o ChromeDriver através do WebDriverManager
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver(); // instanciou o Selenium como Chrome
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
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [When(@"preencho o usuário com ""(.*)""")]
        [When(@"preencho o ""(.*)""")]
        public void QuandoPreenchoOUsuarioCom(string username)
        {
            driver.FindElement(By.Id("user-name")).SendKeys(username);            
        }

        [When(@"a senha ""(.*)"" e clico no botao Login")]
        public void QuandoASenhaEClicoNoBotaoLogin(string password)
        {
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();

        }

        [When(@"adiciono o produto ""(.*)"" ao carrinho")]
        public void QuandoAdicionoOProdutoAoCarrinho(string product)
        {
           String productSelector = "add-to-cart-" + product.ToLower().Replace(" ", "-" ); 
           Console.WriteLine($"Seletor de Produto = {productSelector}");
           driver.FindElement(By.Id(productSelector)).Click();
        }

        [When(@"clico no carrinho de compras")]
        public void QuandoClicoNoCarrinhoDeCompras()
        {
            driver.FindElement(By.Id("shopping_cart_container")).Click();
        }

        [Then(@"exibe ""(.*)"" no titulo da secao")]
        public void EntaoExibeNoTituloDaSecao(string title)
        {
            // Espera explicita pelo elemento span.title ser carregado na página
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(3000));
            wait.Until(d => driver.FindElement(By.CssSelector("span.title")).Displayed);
            Assert.That(driver.FindElement(By.CssSelector("span.title")).Text, Is.EqualTo(title));
        }

        [Then(@"exibe a pagina do carrinho com a quantidade ""(.*)""")]
        public void EntaoExibeAPaginaDoCarrinhoComAQuantidade(string quantity)
        {
            Assert.That(driver.FindElement(By.CssSelector("div.cart_quantity")).Text, Is.EqualTo(quantity));
        }

        [Then(@"nome do produto ""(.*)""")]
        public void EntaoNomeDoProduto(string product)        
        {
            Assert.That(driver.FindElement(By.CssSelector("div.inventory_item_name")).Text, Is.EqualTo(product));
            
        }

        [Then(@"o preco com ""(.*)""")]
        public void EntaoOPrecoCom(string price)
        {
            Assert.That(driver.FindElement(By.CssSelector("div.inventory_item_price")).Text, Is.EqualTo(price));
                                                          
        }
    }
}