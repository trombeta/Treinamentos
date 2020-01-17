package tests;

import common.BaseTest;
import models.MovieModel;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

import java.util.Arrays;
import java.util.List;

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
        MovieModel movieData = new MovieModel(
                "Jumanji - Próxima fase",
                "Pré-venda",
                2020,
                "16/01/2020",
                Arrays.asList("The Rock", "Jack Black", "Kevin Hart", "Karen Gillan", "Denny DeVito"),
                "Tentado a revisitar o mundo de Jumanji, Spencer decide "
                        + "consertar o bug no jogo do game que permite que sejam transportados ao local",
                "jumanji2.jpg"
        );

        movie.add().create(movieData);
    }
}
