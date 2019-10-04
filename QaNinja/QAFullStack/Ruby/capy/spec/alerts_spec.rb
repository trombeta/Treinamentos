describe 'Alertas de JS', :alerts do
    before(:each) do
        visit 'https://training-wheels-protocol.herokuapp.com/javascript_alerts'
    end

    it 'alerta' do 
        click_button 'Alerta'

        msg = page.driver.browser.switch_to.alert.text
        expect(msg).to eql 'Isto é uma mensagem de alerta'
        sleep 2
    end

    it 'sim confirma' do
        click_button 'Confirma'

        msg = page.driver.browser.switch_to.alert.text
        expect(msg).to eql 'E ai confirma?'

        page.driver.browser.switch_to.alert.accept
        expect(page).to have_content 'Mensagem confirmada'
        sleep 2
    end

    it 'não confirma' do
        click_button 'Confirma'

        msg = page.driver.browser.switch_to.alert.text
        expect(msg).to eql 'E ai confirma?'

        page.driver.browser.switch_to.alert.dismiss
        expect(page).to have_content 'Mensagem não confirmada'
        sleep 2
    end

    it 'accept prompt', :accept_prompt do
        accept_prompt(with: 'Rodrigo') do
            click_button 'Prompt'
            sleep 2
        end

        expect(page).to have_content 'Olá, Rodrigo'

        sleep 2
    end

    it 'dismiss prompt', :dismiss_prompt do
        dismiss_prompt(with: 'Rodrigo') do
            click_button 'Prompt'
            sleep 2
        end

        expect(page).to have_content 'Olá, null'
        sleep 2
    end
end