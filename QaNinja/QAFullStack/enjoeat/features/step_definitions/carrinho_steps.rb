Dado("que o produto desejado é {string}") do |produto|
  @produto_nome = produto
end

Dado("o valor do produto é {string}") do |valor|
  @produto_valor = valor
end

Quando("eu adiciono {int} unidade\\(s)") do |quantidade|
  quantidade.times do
    @restaurant_page.add_to_cart(@produto_nome)
  end
end

Então("deve ser adicionado {int} unidade\\(s) deste item") do |quantidade|
  expect(@restaurant_page.cart.box).to have_text "(#{quantidade}x) #{@produto_nome}"
end

Então("o valor total deve ser de {string}") do |valor_total|
  expect(@restaurant_page.cart.total.text).to have_text valor_total
end

#Lista de produtos
Dado("que os produtos desejados são:") do |table|
  @product_list = table.hashes
end

Quando("eu adiciono todos os itens") do
  @product_list.each do |p|
      p["quantidade"].to_i.times do
        @restaurant_page.add_to_cart(p["nome"])
      end
  end
end

Então("vejo todos os itens no carrinho") do
  @product_list.each do |p|
    expect(@restaurant_page.cart.box).to have_text "(#{p["quantidade"]}x) #{p["nome"]}"
  end
end

# Removendo itens do carrinho
Dado("que eu tenho os seguintes itens no carrinho:") do |table|
  @product_list = table.hashes
  steps %{
    Quando eu adiciono todos os itens
  }
end

Quando("eu removo somente o {int}") do |item|
  @restaurant_page.cart.remove_item(item)
end

Quando("eu removo todos os itens") do
  @product_list.each_with_index do |valor, idx|
    @restaurant_page.cart.remove_item(idx)
  end
end

Quando("eu limpo o meu carrinho") do
  @restaurant_page.cart.clean
end

Então("vejo a seguinte mensagem no carrinho {string}") do |mensagem|
  expect(@restaurant_page.cart.box).to have_text mensagem
end

Dado("que adicionei os seguintes itens no carrinho:") do |table|
  @product_list = table.hashes
  steps %{
    Quando eu adiciono todos os itens
  }
end

Quando("eu fecho o meu carrinho") do
  @restaurant_page.cart.close
end

Então("o valor total de itens deve ser igual a {string}") do |total_itens|
  expect(
    @order_page.cost_shipping[0]
  ).to have_text total_itens
end

Então("o valor do frete deve ser igual a {string}") do |shipping|
  expect(
    @order_page.cost_shipping[1]
  ).to have_text shipping
end

Então("o valor total da compra deve ser igual a {string}") do |total_cart|
  expect(
    @order_page.cost_shipping[2]
  ).to have_text total_cart
end