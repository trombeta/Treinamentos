***Settings***
Resource    ../resources/base.robot

# Executa a KW antes de cada testcase
Test Setup      Open Session
# Executa a KW depois de cada testcase
Test Teardown   Close Session

***Variables***
#Variável simples:  ${NOME}     Rodrigo Trombeta
#Variável de Lista: @{CARROS}   Civic   Lancer  Peugeot
#Variável dicionário: &{CARRO}  nome=Lancer     modelo=Evolution    ano=2020
${TOOLBAR_TITTLE}      id=io.qaninja.android.twp:id/toolbarTitle

***Test Cases***
Deve acessar a tela Dialogs
    Open Nav

    Click Text                      DIALOGS
    Wait Until Element Is Visible   ${TOOLBAR_TITTLE}
    Element Text Should Be          ${TOOLBAR_TITTLE}   DIALOGS

Deve acessar a tela de formulários
    Open Nav

    Click Text                      FORMS
    Wait Until Element Is Visible   ${TOOLBAR_TITTLE}
    Element Text Should Be          ${TOOLBAR_TITTLE}   FORMS

Deve acessar a tela de vingadores
    Open Nav

    Click Text                      AVENGERS
    Wait Until Element Is Visible   ${TOOLBAR_TITTLE}
    Element Text Should Be          ${TOOLBAR_TITTLE}   AVENGERS

