require_relative 'veiculo'

class Moto < Veiculo
    def pilotar
        puts "#{nome} está iniciando o trajeto."
    end
end

fazer = Moto.new('Fazer', 'Yamaha', '250x')
fazer.ligar
fazer.buzinar
fazer.pilotar