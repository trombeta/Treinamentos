#language: pt

@green_food
Funcionalidade: Finalizar pedido
    Para que eu possa receber o pedido no meu endereço
    Sendo um usuário que fechou o carrinho com itens
    Posso finalizar o meu pedido

    Cenário: Finalizar pedido com Cartão Refeição
        Dado que eu feche o pedido com os itens:
            | quantidade | nome                | descricao                                | subtotal |
            | 1          | Suco Detox          | Suco de couve, cenoura, salsinha e maça. | R$ 14,90 |
            | 2          | Hamburger de Quinoa | Cheio de fibras e muito saboroso.        | R$ 21,00 |
        E eu informo os dados de entrega:
            | nome        | Rodrigo                |
            | email       | rodstrombeta@gmail.com |
            | rua         | Rua Chile              |
            | numero      | 1453                   |
            | complemento | Apto 604 B             |
        Quando eu finalizo o pedido com "Cartão Refeição"
        Então eu devo ver a seguinte mensagem:
        """
        Seu pedido foi recebido pelo restaurante. Prepare a mesa que a comida está chegando!
        """