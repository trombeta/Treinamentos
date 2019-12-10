import static org.testng.Assert.assertEquals;
import org.testng.annotations.Test;

import static com.codeborne.selenide.Selenide.open;
import static com.codeborne.selenide.Selenide.title;
import static com.codeborne.selenide.WebDriverRunner.isChrome;

public class HelloSelenideTest {

    @Test
    public void OnAir(){
        isChrome();
        open("http://ninjaplus-web:5000/login");
        assertEquals(title(), "Ninja+");
    }
}
