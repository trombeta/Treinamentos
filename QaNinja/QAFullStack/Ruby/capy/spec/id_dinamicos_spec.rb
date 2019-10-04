describe 'IDs Dinâmicos', :idsdinamicos do
    before(:each) do
        visit '/access'
    end

    it 'cadastro' do

        find('input[id$=UsernameInput]').set 'rodrigo' # $ Termina com
        find('input[id^=PasswordInput]').set '123456'  # ^ Inicia com
        find('a[id*=GetStartedButton]').click       # * Contém
        
        expect(page).to have_content 'Dados enviados. Aguarde aprovação do seu cadastro!'
        sleep 2
    end
end