Dado("que eu feche o pedido com os itens:") do |table|
    @product_list = table.hashes
    steps %{
        Quando eu adiciono todos os itens
    }
    @restaurant_page.cart.close
  end
  
  Dado("eu informo os dados de entrega:") do |table|
    user = table.rows_hash
    @order_page.fill_user_data(user)
  end
  
  Quando("eu finalizo o pedido com {string}") do |payment|
    @order_page.checkout(payment)
  end
  
  Então("eu devo ver a seguinte mensagem:") do |expect_message|
    expect(@order_page.summary).to have_text expect_message
  end