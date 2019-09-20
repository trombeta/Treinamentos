class Conta
    # Atributos Ruby
    attr_accessor :saldo, :nome

    # Construtor Ruby
    def initialize(nome)
        self.saldo = 0.0
        self.nome = nome
    end

    # Métodos Ruby
    def deposita(valor)
        self.saldo += valor
        puts "Depositando a quantia de #{valor} reais na conta do #{self.nome}."
    end
end

 c = Conta.new('Rodrigo')
 
 c.deposita(100.00)
 puts "Seu novo saldo é de: #{c.saldo} reais."

 c.deposita(10.00)
 puts "Seu novo saldo é de: #{c.saldo} reais."