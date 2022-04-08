Feature: Add To Cart
	As a user
	I want to add products to cart AutomationPractice application
	So I will be able to buy products

@AddToCart
Scenario: Add product to cart from a catalog page
	Given I sign in as User1
	When I search for product using search query
	And I add product to cart from search page
	Then Product is added to the cart

@AddToCart
Scenario: Add product to cart from product page
	Given I sign in as User2
	When I open category page using navigation
	And I open product page using view more button
	And I add product to cart from product page
	Then Product is added to the cart
