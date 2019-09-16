public class TesteFuncionario {

	public static void main(String[] args) {
		
		Funcionario rodrigo = new Funcionario();
		rodrigo.setNome("Rodrigo Trombeta");
		rodrigo.setCpf("12345678901");
		rodrigo.setSalario(2500.00);
		
		System.out.println(rodrigo.getNome());
		System.out.println(rodrigo.getBonificacao());
	}

}