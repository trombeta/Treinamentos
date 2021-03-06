public class TestaMetodo {
	public static void main(String[] args) {
		System.out.println("DEPOSITA");
		Conta contaDoPaulo = new Conta();
		contaDoPaulo.titular = "Paulo Silveira";
		contaDoPaulo.saldo = 100;
		contaDoPaulo.deposita(50);
		System.out.println("Titular da Conta: " + contaDoPaulo.titular);
		System.out.println("Saldo atual: " + contaDoPaulo.saldo);
		System.out.println("");
		
		System.out.println("SACA");
		boolean conseguiuSacar = contaDoPaulo.saca(20);
		System.out.println("Conseguiu sacar: " + conseguiuSacar);
		System.out.println("Saldo atual: " + contaDoPaulo.saldo);
		System.out.println("");
		
		System.out.println("TRANSFERE");
		Conta contaDaMarcela = new Conta();
		contaDaMarcela.titular = "Marcela Silveira";
		System.out.println("Titular da Conta: " + contaDaMarcela.titular);
		contaDaMarcela.deposita(1000);
		boolean sucessoTransferencia = contaDaMarcela.transfere(300, contaDoPaulo);
		
		if(sucessoTransferencia) {
			System.out.println("Transferência eftuada com sucesso!");
		} else {
			System.out.println("Saldo insuficiente!");
		}
		System.out.println("Saldo atual da conta da Marcela: " + contaDaMarcela.saldo);
		System.out.println("Saldo atual da conta do Paulo: " + contaDoPaulo.saldo);
		System.out.println("");
	}
}