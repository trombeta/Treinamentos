describe 'Mouse hovers', :hover do

    before(:each) do
        visit "https://training-wheels-protocol.herokuapp.com/hovers"
    end

    it 'quando passo o mouse sobre o blade' do
        card = find('img[alt*=Blade]') # * Contém
        card.hover

        expect(page).to have_content 'Nome: Blade'
    end

    it 'quando passo o mouse sobre o pantera negra' do
        card = find('img[alt^=Pantera]') # ^ Começa com
        card.hover

        expect(page).to have_content 'Nome: Pantera Negra'
    end

    it 'quando passo o mouse sobre o homem aranha' do
        card = find('img[alt$="Aranha"]') # $ Termina com
        card.hover

        expect(page).to have_content 'Nome: Homem Aranha'
    end

    after(:each) do
        sleep 1
    end

end