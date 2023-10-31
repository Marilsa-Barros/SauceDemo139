#language: pt
@Loja
Funcionalidade: Selecionar Produto na Loja
    Cenario: Selecao de Produto com Sucesso
        Dado que acesso a página inicial do site
        Quando preencho o usuário com "standard_user"
        E a senha "sauce_secret" e clico no botao Login
        Entao exibe "Products" no titulo da secao 
        Quando adiciono o produto "Sauce Labs Backpack" ao carrinho
        E clico no carrinho de compras 
        Entao exibe a pagina do carrinho com a quantidade "1"
        E nome do produto "Sauce Labs Backpack"
        E o preco com "$29.99"
