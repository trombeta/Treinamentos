package pages;

import com.codeborne.selenide.Selenide;
import com.codeborne.selenide.SelenideElement;

import static com.codeborne.selenide.Selectors.byText;
import static com.codeborne.selenide.Selenide.$;
import static com.codeborne.selenide.Selenide.executeJavaScript;

public class LoginPage {

    public LoginPage open() {
        Selenide.open("/login");
        return this;
    }

    public LoginPage with(String email, String senha) {

        $("input[name=email]").setValue(email);
        $("input[type=password]").setValue(senha);
        $(byText("Entrar")).click();
        return this;
    }

    public SelenideElement alert() {
        return $(".alert span");
    }

    public void clearSession() {
        executeJavaScript("localStorage.clear();");
    }

}