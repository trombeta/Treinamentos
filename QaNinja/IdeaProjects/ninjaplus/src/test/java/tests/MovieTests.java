package tests;

import common.BaseTest;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

import static com.codeborne.selenide.Condition.text;

public class MovieTests extends BaseTest {

    @BeforeMethod
    public void setup() {
        login
                .open()
                .with("rodstrombeta@gmail.com", "pwd123");

        sideBar.loggedUser().shouldHave(text("Rodrigo"));
    }

    @Test
    public void shouldRegisterANewMovie() {
        String title = "Jumanji - Próxima fase";

        movie.add().create(title);
    }
}
