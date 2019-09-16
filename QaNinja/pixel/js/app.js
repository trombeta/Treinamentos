var btnCadastrar = document.querySelector("#cadastrar-id");

btnCadastrar.addEventListener("click", function(event) {
    event.preventDefault();

    var form = document.querySelector("#new-game");

    var name = document.querySelector("#gameId");

    var modal = document.querySelector("#modal");

    var message = document.querySelector(".message-show");

    if(name.value == "") {
        message.innerHTML = "Nome do jogo deve ser preechido!"
    } else {
        message.innerHTML = "Os dados do jogo foram enviados com sucesso."
    }
    modal.showModal();

    console.log(form);
})