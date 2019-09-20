# veiculo.rb

class Carro < Veiculo
    def dirigir
        puts "#{nome} está iniciando o trajeto."
    end
end

civic = Carro.new('Civic', 'Honda', 'SI')
civic.ligar
civic.buzinar
civic.dirigir

puts ''

lancer = Carro.new('Lancer', 'Mitsubishi', 'EVO')
lancer.ligar
lancer.buzinar
lancer.dirigir