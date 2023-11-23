using OpenQA.Selenium;

namespace Pages
{
    public class CartPage : CommonPage
    {
        // Mapeamento de elementos
        private IWebElement lblQuatidade => driver.FindElement(By.CssSelector("div.cart_quantity"));
        private IWebElement lblNomeProduto => driver.FindElement(By.CssSelector("div.inventory_item_name"));
        private IWebElement lblPreco => driver.FindElement(By.CssSelector("div.inventory_item_price"));

        // Construtor
        public CartPage(IWebDriver driver) : base(driver){}
        
        // Ações
        public String LerQuantidade()
        {
            return lblQuatidade.Text;
        }
        
        public String LerNomeProduto()
        {
            return lblNomeProduto.Text;
        }

        public String LerPreco()
        {
            return lblPreco.Text;
        }

    }
}