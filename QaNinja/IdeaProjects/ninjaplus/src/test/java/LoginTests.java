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
}
