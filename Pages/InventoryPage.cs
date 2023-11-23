
using OpenQA.Selenium;

namespace Pages
{
    public class InventoryPage : CommonPage
    {
         // Mapeamento dos Elementos
        // Como queremos mapear o botão "Add to Cart" e o id muda por produto
        // Iremos mapear de forma dinâmicaa pelo bloco de Ações

         // Construtor
        public InventoryPage(IWebDriver driver) : base(driver){}

         // Ações
         public void AdicionarAoCarrinho(String produto)
         {
            String seletorProduto = "add-to-cart-" + produto.ToLower().Replace(" ", "-");
            driver.FindElement(By.Id(seletorProduto)).Click();
         }
         
    }
}