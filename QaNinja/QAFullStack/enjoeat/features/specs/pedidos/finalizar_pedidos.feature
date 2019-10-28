#language: pt

Funcionalidade: Finalizar pedido
    Para que eu possa receber o pedido no meu endereço
    Sendo um usuário que fechou o carrinho com itens
    Posso finalizar o meu pedido

    Cenário: Finalizar pedido com Cartão Refeição
        Dado que eu fechei o meu carrinho
        E preencho o campo nome com "Rodrigo"
        E preencho o campo e-mail com "rodstrombeta@gmail.com"
        E preencho o campo confirmação de e-mail com "rodstrombeta@gmail.com"
        E preencho a rua com "Rua Chile"
        E preencho o número da rua com "1000"
        E preecho o campo complemento com "Apto 604B"
        E clico na forma de pagamento "Cartão Refeição"
        Quando eu clico em "Finalizar Pedido"
        Então devo ver uma mensagem de sucesso