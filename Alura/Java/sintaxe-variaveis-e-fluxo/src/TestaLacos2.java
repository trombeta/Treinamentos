public class TestaLacos2 {
	public static void main(String[] args) {
		for (int linha = 0; linha <= 10; linha++) {
			for (int coluna = 0; coluna <= linha; coluna++) {
				System.out.print("*");
			}
			System.out.println("");
		}
		
		for(int linha = 0; linha < 5; linha++) {
            for (int coluna = 0; coluna < 5; coluna++) {
                if ( coluna > linha ) {
                    break;
                }
                System.out.print( coluna + 1 );
            }
            System.out.println();
        }
		
		for (int numero = 0; numero <= 100; numero++) {
			if (numero % 3 == 0) {
				System.out.println(numero);
			}
		}
		System.out.println("");
		
		for (int numero = 3; numero <= 100; numero += 3) {
			System.out.println(numero);
		}
		System.out.println("");
	}
}