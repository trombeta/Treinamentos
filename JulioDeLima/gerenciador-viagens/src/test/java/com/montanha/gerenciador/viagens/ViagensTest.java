package com.montanha.gerenciador.viagens;

import io.restassured.http.ContentType;
import org.junit.Test;
import static io.restassured.RestAssured.*;
import static io.restassured.matcher.RestAssuredMatchers.*;
import static org.hamcrest.Matchers.*;

public class ViagensTest {
    @Test
    public void testDadoUmAdministradorQuandoCadastroViagensEntaoObtenhoStatusCode201(){
        // Configurar o caminho comum de acesso a minha API Rest
        baseURI = "http://localhost";
        port = 8089;
        basePath = "/api";

        // Login na API Rest
        String token = given()
                .body("{\n" +
                        "  \"email\": \"admin@email.com\",\n" +
                        "  \"senha\": \"654321\"\n" +
                        "}")
                .contentType(ContentType.JSON)
            .when()
                .post("/v1/auth")
            .then()
                .extract().path("data.token");

        // Cadastrar a viagem
        given()
                .header("Authorization", token)
                .body("{\n" +
                        "  \"acompanhante\": \"Rodrigo\",\n" +
                        "  \"dataPartida\": \"2021-02-24\",\n" +
                        "  \"dataRetorno\": \"2021-03-24\",\n" +
                        "  \"localDeDestino\": \"Fortaleza\",\n" +
                        "  \"regiao\": \"Norte\"\n" +
                        "}")
                .contentType(ContentType.JSON)
        .when()
                .post("/v1/viagens")
        .then()
                .assertThat()
                    .statusCode(201);
    }
}
