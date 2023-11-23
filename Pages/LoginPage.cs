// Bibliotecas

using OpenQA.Selenium;
// Namespace
namespace Pages
{
// Classe
    public class LoginPage : CommonPage
    {        
    // Atributos
        // Mapeamento dos Elementos
        private IWebElement txtUsuario => driver.FindElement(By.Id("user-name"));
        private IWebElement txtSenha => driver.FindElement(By.Id("password"));
        private IWebElement btnLogin => driver.FindElement(By.Id("login-button"));

    // Metódos e Funções
        // Construtor
        public LoginPage(IWebDriver driver) : base(driver){}
        
        // Ações a serem usadas na automação
        public void PreencherUsuario(String usuario)
        {
            txtUsuario.SendKeys(usuario);                
        }

        public void PreencherSenha(String senha)
        {
            txtSenha.SendKeys(senha);            
        }

        public void ClicarNoBotaoLogin()
        {
            btnLogin.Click();
        }

        public void DarEnter()
        {
            txtSenha.SendKeys(Keys.Enter);
        }

    }

}