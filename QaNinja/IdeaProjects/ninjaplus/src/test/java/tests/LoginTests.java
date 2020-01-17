package tests;

import common.BaseTest;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;

import static com.codeborne.selenide.Condition.text;

public class LoginTests extends BaseTest {

    @DataProvider(name = "login-alerts")
    public Object[][] loginProvider() {
        return new Object[][]{
                {"rodstrombeta@gmail.com", "abc123", "Usuário e/ou senha inválidos"},
                {"fulano_de_tal@gmail.com", "pwd123", "Usuário e/ou senha inválidos"},
                {"", "pwd123", "Opps. Cadê o email?"},
                {"rodstrombeta@gmail.com", "", "Opps. Cadê a senha?"},
        };
    }

    @Test
    public void shouldSeeLoggedUser() {
        login
                .open()
                .with("rodstrombeta@gmail.com", "pwd123");

        sideBar.loggedUser().shouldHave(text("Rodrigo"));
    }

    @Test(dataProvider = "login-alerts")
    public void shouldSeeLoginAlerts(String email, String pass, String expectAlert) {
        login
                .open()
                .with(email, pass)
                .alert().shouldHave(text(expectAlert));
    }

    @AfterMethod
    public void cleanUp() {
        login.clearSession();
    }
}
