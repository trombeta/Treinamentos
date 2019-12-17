import org.testng.annotations.Test;

import static com.codeborne.selenide.Condition.text;
import static com.codeborne.selenide.Selectors.byText;
import static com.codeborne.selenide.Selenide.$;
import static com.codeborne.selenide.Selenide.open;
import static com.codeborne.selenide.WebDriverRunner.isChrome;

public class LoginTests {

    @Test
    public void shouldSeeLoggedUser(){
        isChrome();
        open("http://ninjaplus-web:5000/login");

        //$("#emailId").setValue("rodstrombeta@gmail.com");
        $("input[name=email]").setValue("rodstrombeta@gmail.com");
        $("#passId").setValue("pwd123");
        //$("#login").click();
        $(byText("Entrar")).click();

        $(".user .info span").shouldHave(text("Rodrigo"));
    }

    @Test
    public void IncorrectPassword(){
        isChrome();
        open("http://ninjaplus-web:5000/login");

        $("#emailId").setValue("rodstrombeta@gmail.com");
        $("#passId").setValue("abc123");
        $("#login").click();

        $(".alert span").shouldHave(text("Usuário e/ou senha inválidos"));
    }

    @Test
    public void UserNotFound(){
        isChrome();
        open("http://ninjaplus-web:5000/login");

        $("#emailId").setValue("fulano_de_tal@gmail.com");
        $("#passId").setValue("pwd123");
        $("#login").click();

        $(".alert span").shouldHave(text("Usuário e/ou senha inválidos"));
    }

    @Test
    public void EmailRequired(){
        isChrome();
        open("http://ninjaplus-web:5000/login");

        $("#emailId").setValue("");
        $("#passId").setValue("pwd123");
        $("#login").click();

        $(".alert span").shouldHave(text("Opps. Cadê o email?"));
    }

    @Test
    public void PasswordRequired(){
        isChrome();
        open("http://ninjaplus-web:5000/login");

        $("#emailId").setValue("rodstrombeta@gmail.com");
        $("#passId").setValue("");
        $("#login").click();

        $(".alert span").shouldHave(text("Opps. Cadê a senha?"));
    }
}
