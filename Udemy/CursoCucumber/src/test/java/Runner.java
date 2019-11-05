import org.junit.runner.RunWith;

import cucumber.api.CucumberOptions;
import cucumber.api.SnippetType;
import cucumber.api.junit.Cucumber;

@RunWith(Cucumber.class)
@CucumberOptions(
		plugin = "pretty",
		monochrome = true,
		//snippets: Mantém o padrão Java na nomenclatura das classes. Ex.: queCrieiOArquivoCorretamente
		snippets = SnippetType.CAMELCASE,
		//dryRun: Quando 'true', faz toda a validação do mapeamento dos cenários antes de executar.
		//Geralmente é utilizado quando temos testes muito demorados.
		//Após a validação, se tudo estiver OK, é necessário alterar para 'false' novamente para executar os testes.
		dryRun = false,
		// Quando 'true', quebra o teste quando acrescentado um novo passo na feature.
		// Quando 'false', o teste fica marcado como skiped
		strict = false
		)
public class Runner {

}