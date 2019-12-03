package br.trombeta.runners;
import org.junit.runner.RunWith;

import cucumber.api.CucumberOptions;
import cucumber.api.SnippetType;
import cucumber.api.junit.Cucumber;

@RunWith(Cucumber.class)
@CucumberOptions(
		features = "src/test/resources/features/alugar_filme.feature",
		glue = "br.trombeta.steps",
		tags = "~@ignore",
		plugin = "pretty",
		monochrome = true,
		snippets = SnippetType.CAMELCASE, //Definie a forma de gerar o nome das classes, no caso, sem underline e com a primera letra sempre maiúsculo
		dryRun = false, // Caso true, apenas valida se o mapeamento está correto
		strict = false //Caso true, gera erro no cenário caso algum dos passos esteja indefinido
		)
public class Runner {

}
