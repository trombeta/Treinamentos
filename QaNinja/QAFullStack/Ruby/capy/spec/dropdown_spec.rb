describe 'Caixa de opções', :dropdown do

    it 'item específico simples' do
        visit "/dropdown"
        select('Loki', from: 'dropdown') #funciona quando o elemento dropdown possui um Id
        sleep 2 # temporário
    end

    it 'item específico com o find' do
        visit '/dropdown'
        drop = find('.avenger-list')
        drop.find('option', text: 'Scott Lang').select_option
        sleep 2
    end

    it 'qualquer item com find all' do
        visit "/dropdown"
        drop = find('.avenger-list')
        drop.all('option').sample.select_option
        sleep 2
    end

end