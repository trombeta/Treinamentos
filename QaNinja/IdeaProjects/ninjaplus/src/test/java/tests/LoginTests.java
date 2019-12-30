package tests;

import com.codeborne.selenide.Configuration;
import org.testng.annotations.*;
import pages.LoginPage;
import pages.SideBar;

import static com.codeborne.selenide.Condition.text;

public class LoginTests {

    protected static LoginPage login;
    protected  static SideBar sideBar;

    @DataProvider(name = "login-alerts")
    public Object[][] loginProvider() {
        return new Object[][]{
                {"rodstrombeta@gmail.com", "abc123", "Usuário e/ou senha inválidos"},
                {"fulano_de_tal@gmail.com", "pwd123", "Usuário e/ou senha inválidos"},
                {"", "pwd123", "Opps. Cadê o email?"},
                {"rodstrombeta@gmail.com", "", "Opps. Cadê a senha?"},
        };
    }

    @BeforeMethod
    public void start() {
        Configuration.browser = "chrome";
        Configuration.baseUrl = "http://ninjaplus-web:5000";

        login = new LoginPage();
        sideBar = new SideBar();
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
