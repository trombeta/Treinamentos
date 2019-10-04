describe 'Meu primeiro script', :hello do
  before(:each) do
    page.current_window.resize_to(1280, 800)
  end
  
  it 'visitar a página' do
    visit '/'
    
    expect(page.title).to eql 'Training Wheels Protocol'
  end
end
