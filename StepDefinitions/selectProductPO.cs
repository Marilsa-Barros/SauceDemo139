using OpenQA.Selenium;
using Pages;
using TechTalk.SpecFlow;

namespace MyNamespace
{
    [Binding]
    public class SelectProductPO
    {
        // Atributos / Objetos
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver;

        // Classe das páginas de mapeamento
        private LoginPage loginPage;
        private CommonPage commonPage;
        private InventoryPage inventoryPage;
        private CartPage cartPage;

        // Construtor 
        public SelectProductPO(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = (IWebDriver) _scenarioContext["driver"];
        }

        [Given(@"que acesso a página inicial do site PO")]
        public void DadoQueAcessoAPaginaInicialDoSitePO()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [When(@"preencho o ""(.*)"" PO")]
        public void QuandoPreenchoOPO(string usuario)
        {
            loginPage = new LoginPage(driver); // instanciamos a classe de login
            loginPage.PreencherUsuario(usuario);
        }


        [When(@"a senha ""(.*)"" e clico no botao Login PO")]
        public void QuandoASenhaEClicoNoBotaoLoginPO(string senha)
        {
            loginPage.PreencherSenha(senha);
            loginPage.ClicarNoBotaoLogin();
        }


        [Then(@"exibe ""(.*)"" no titulo da secao PO")]
        public void EntaoExibeNoTituloDaSecaoPO(string tituloSecao)
        {
            inventoryPage = new InventoryPage(driver);
            Assert.That(inventoryPage.LerTituloDaSecao(), Is.EqualTo(tituloSecao));
        }

        [When(@"adiciono o produto ""(.*)"" ao carrinho PO")]
        public void QuandoAdicionoOProdutoAoCarrinhoPO(string produto)
        {
            inventoryPage.AdicionarAoCarrinho(produto);
        }


        [When(@"clico no carrinho de compras PO")]
        public void QuandoClicoNoCarrinhoDeComprasPO()
        {
            inventoryPage.IrParaOCarrinho();
        }


        [Then(@"exibe a pagina do carrinho com a quantidade ""(.*)"" PO")]
        public void EntaoExibeAPaginaDoCarrinhoComAQuantidadePO(string quantidade)
        {
            cartPage = new CartPage(driver);
            Assert.That(cartPage.LerQuantidade(), Is.EqualTo(quantidade));
        }


        [Then(@"nome do produto ""(.*)"" PO")]
        public void EntaoNomeDoProdutoPO(string produto)
        {           
            Assert.That(cartPage.LerNomeProduto(), Is.EqualTo(produto));
        }   

        [Then(@"o preco com ""(.*)"" PO")]
        public void EntaoOPrecoComPO(string preco)
        {
            Assert.That(cartPage.LerPreco(), Is.EqualTo(preco));
        }

    }
 }
