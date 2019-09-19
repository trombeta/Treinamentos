public class TestaCondicional2 {
	public static void main(String[] args) {
		System.out.println("TESTANDO CONDICIONAIS 2");
		System.out.println("");

		int idade = 20;
		int quantidadePessoas = 3;
		boolean acompanhado = quantidadePessoas >= 2;

		System.out.println("Valor de acompanhado = " + acompanhado);
		if (idade >= 18 && acompanhado) {
			System.out.println("seja bem vindo");
		}
		else {
			System.out.println("infelizmente você não pode entrar");
		}
		
		idade = 65;
		boolean ehIdoso = idade >= 65;
		System.out.println("");
		System.out.println("Pessoa idosa: " + ehIdoso);
	}
}