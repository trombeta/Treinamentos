Funcionalidade: Login

Cenário: Login
	Dado o email
	| Email                |
	| n_corghi@hotmail.com |
	| n_corghi@hotmail.com |
	E a senha
	| Senha  |
	| 123456 |
	| 123    |
	Quando eu pressionar o botão Login In
	Então o resultado será
	| Resultado |
	| Sucesso   |
	| Falha     |