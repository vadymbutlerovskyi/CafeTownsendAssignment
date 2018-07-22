Feature: CreateUserSteps
	As a user
	I want to be able to create a new employee

@regression
@CreateUser
Scenario Outline: Create a new employee
	Given I open browser and go to CafeTownsend home page
	Then I wait for '1' second(s)
		And I enter '<username>' into the 'username' field
		And I enter '<password>' into the 'password' field
	When I click on the 'Login' button
	Then I click on the 'Create' button
		And I click on the 'Cancel' button
		And I click on the 'Create' button
	When I fill in new user data with the following:
	| field      | value   |
	| First name | Robo    |
	| Last name  | Cop     |
	#The custom date format is YYYY-MM-DD or Today as a string
	| Start date | Today   |
	| Email      | m@m.com |
	Then I click on the 'Add' button
		And I see the new user listed
		And I close browser

Examples: 
| username | password  |
| Luke     | Skywalker |



@regression
@CreateUser
Scenario Outline: Create a new employee with invalid data
	Given I open browser and go to CafeTownsend home page
	Then I wait for '1' second(s)
		And I enter '<username>' into the 'username' field
		And I enter '<password>' into the 'password' field
	When I click on the 'Login' button
	Then I click on the 'Create' button
	When I fill in new user data with the following:
	| field      | value      |
	| First name | Robo       |
	| Last name  | Cop        |
	#The custom date format is YYYY-MM-DD or Today as a string
	| Start date | 2000-13-32 |
	| Email      | m@m.com    |
	Then I click on the 'Add' button
		And I accept the alert message '<alert>'
	When I fill in employee  the 

Examples: 
| username | password  | alert                                                                     |
| Luke     | Skywalker | Error trying to create a new employee: {"start_date":["can't be blank"]}) |
