Dado("que eu feche o pedido com os itens:") do |table|
    @product_list = table.hashes
    steps %{
        Quando eu adiciono todos os itens
    }
    @restaurant_page.cart.close
  end
  
  Dado("eu informo os dados de entrega:") do |table|
    # table is a Cucumber::MultilineArgument::DataTable
    pending # Write code here that turns the phrase above into concrete actions
  end
  
  Quando("eu finalizo o pedido com {string}") do |string|
    pending # Write code here that turns the phrase above into concrete actions
  end
  
  Então("eu devo ver a seguinte mensagem:") do |string|
    pending # Write code here that turns the phrase above into concrete actions
  end