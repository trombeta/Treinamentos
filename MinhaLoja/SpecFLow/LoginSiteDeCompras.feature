#language: pt-br

Funcionalidade: Login Site de compras

Cenário: Login Válido
	Dado um email rodstrombeta@gmail.com
	E uma senha 123456
	Quando clico em logar
	Então login é realizado com sucesso

	Cenário: Login Inválido
	Dado um email rodstrombeta@gmail.com
	E uma senha 1234567
	Quando clico em logar
	Então login é realizado com falha

Exemplos: 
| email                  | senha   | resultado |
| rodstrombeta@gmail.com | 123456  | sucesso   |
| rodstrombeta@gmail.com | 1234567 | falha     |