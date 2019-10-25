Before do
    page.current_window.resize_to(1440, 900)

    @restaurant_list_page = RestaurantListPage.new
    @restaurant_page = RestaurantPage.new
end

Before('@bread_bakery') do
    visit "/restaurants/bread-bakery/menu"
end