Feature: Login
	As a user
	I want to login to AutomationPractice application
	So I will be able to write even more wonderful tests

@login
Scenario: Open home page
	When I open home page
	Then Main home page elements are displayed

@login
Scenario: Sign in with valid credentials
	Given User1 is created
	And Home page is opened
	When I click sign in link
	And I sign in with valid email adress and password
	Then My Account page is displayed