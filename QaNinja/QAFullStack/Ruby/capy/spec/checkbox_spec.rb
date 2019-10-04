describe 'Caixas de seleção', :checkbox do

    before(:each) do
        visit '/checkboxes'
    end

    it 'marcando uma opção' do
        check('thor') # funciona com atributo Id
    end

    it 'desmarcando uma opção' do
        uncheck('antman') # funciona com atributo Name
    end

    it 'marcando com find set true' do
        find('input[value=cap]').set(true)
    end

    it 'desmarcando com find set false' do
        find('input[value=guardians]').set(false)
    end

    after(:each) do
        sleep 2
    end

end