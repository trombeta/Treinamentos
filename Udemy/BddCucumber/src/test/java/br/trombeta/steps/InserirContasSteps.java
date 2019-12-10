package br.trombeta.steps;

import java.io.File;
import java.io.IOException;

import org.apache.commons.io.FileUtils;
import org.junit.Assert;
import org.openqa.selenium.By;
import org.openqa.selenium.OutputType;
import org.openqa.selenium.TakesScreenshot;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;

import cucumber.api.PendingException;
import cucumber.api.Scenario;
import cucumber.api.java.After;
import cucumber.api.java.pt.Dado;
import cucumber.api.java.pt.Então;
import cucumber.api.java.pt.Quando;

public class InserirContasSteps {
	
	private WebDriver driver;
	
	@Dado("^que estou acessando a aplicação$")
	public void que_estou_acessando_a_aplicação() throws Throwable {
	    driver = new ChromeDriver();
	    driver.get("https://srbarriga.herokuapp.com");
	}

	@Quando("^informo o usuário \"([^\"]*)\"$")
	public void informo_o_usuário(String arg1) throws Throwable {
	    driver.findElement(By.id("email")).sendKeys(arg1);
	}

	@Quando("^a senha \"([^\"]*)\"$")
	public void a_senha(String arg1) throws Throwable {
		driver.findElement(By.name("senha")).sendKeys(arg1);
	}

	@Quando("^seleciono entrar$")
	public void seleciono_entrar() throws Throwable {
	    driver.findElement(By.tagName("button")).click();
	}

	@Então("^visualizo a página inicial$")
	public void visualizo_a_página_inicial() throws Throwable {
	    String mensagem = driver.findElement(By.xpath("//div[@class='alert alert-success']")).getText();
	    Assert.assertEquals("Bem vindo, Rodrigo Trombeta!", mensagem);
	}

	@Quando("^seleciono Contas$")
	public void seleciono_Contas() throws Throwable {
	    driver.findElement(By.linkText("Contas")).click();
	}

	@Quando("^seleciono Adicionar$")
	public void seleciono_Adicionar() throws Throwable {
		driver.findElement(By.linkText("Adicionar")).click();
	}

	@Quando("^informo a conta \"([^\"]*)\"$")
	public void informo_a_conta(String arg1) throws Throwable {
	    driver.findElement(By.name("nome")).sendKeys(arg1);
	}

	@Quando("^seleciono Salvar$")
	public void seleciono_Salvar() throws Throwable {
	    driver.findElement(By.tagName("button")).click();
	}
	
	@Então("^recebo a mensagem \"([^\"]*)\"$")
	public void receboAMensagem(String arg1) throws Throwable {
		String mensagem = driver.findElement(By.xpath("//div[starts-with(@class, 'alert alert-')]")).getText();
		Assert.assertEquals(arg1, mensagem);
	}
	
	@Dado("^que desejo adicionar uma conta$")
	public void queDesejoAdicionarUmaConta() throws Throwable {
		driver = new ChromeDriver();
	    driver.get("https://srbarriga.herokuapp.com");
		
	    driver.findElement(By.id("email")).sendKeys("rodstrombeta@gmail.com");
		driver.findElement(By.name("senha")).sendKeys("01234567890");
		driver.findElement(By.tagName("button")).click();
		
	    driver.findElement(By.linkText("Contas")).click();
		driver.findElement(By.linkText("Adicionar")).click();
	}

	@Quando("^adiciono a conta \"([^\"]*)\"$")
	public void adicionoAConta(String arg1) throws Throwable {
		driver.findElement(By.name("nome")).sendKeys(arg1);
		driver.findElement(By.tagName("button")).click();
	}
	
	@Quando("^adiciono uma conta válida$")
	public void adicionoUmaContaVálida() throws Throwable {
		driver.findElement(By.name("nome")).sendKeys("Conta de Teste 3");
		driver.findElement(By.tagName("button")).click();
	}

	@Então("^a conta é inserida com sucesso$")
	public void aContaÉInseridaComSucesso() throws Throwable {
		String mensagem = driver.findElement(By.xpath("//div[starts-with(@class, 'alert alert-')]")).getText();
		Assert.assertEquals("Conta adicionada com sucesso!", mensagem);
	}
	
	@After(order = 1, value = {"@funcionais"})
	public void screenShot(Scenario cenario) {
		File file = ((TakesScreenshot)driver).getScreenshotAs(OutputType.FILE);
		try {
			FileUtils.copyFile(file, new File("target/screenshots/"+ cenario.getId() +".jpg"));
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	@After(order = 0, value = {"@funcionais"})
	public void fecharBrowser() {
		driver.quit();
	}
}
