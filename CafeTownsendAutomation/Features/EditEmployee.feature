Feature: EditEmployee
	As a user
	I want to be able to edit an employee

@regression
@EditEmployee
Scenario Outline: Edit an existing employee
	Given I open browser and go to CafeTownsend home page
	Then I enter '<username>' into the 'username' field
		And I enter '<password>' into the 'password' field
	When I click on the Login button
	Then I click on the Create button
	When I fill in new employee data with the following:
	| field      | value   |
	| First name | Robo    |
	| Last name  | Cop     |
	#The custom date format is YYYY-MM-DD or Today as a string
	| Start date | Today   |
	| Email      | m@m.com |
	Then I click on the Add button
		And I see and select the new employee listed
		And I click on the Edit button
	When I fill in new employee data with the following:
	| field      | value      |
	| First name | Termi      |
	| Last name  | Nator      |
	#The custom date format is YYYY-MM-DD or Today as a string
	| Start date | 2000-12-31 |
	| Email      | a@a.aa     |
	Then I click on the Update button
		And I see and select the new employee listed
		And I click on the Edit button
		And I see all the employee data updated after edit
		And I close browser

Examples: 
| username | password  |
| Luke     | Skywalker |
