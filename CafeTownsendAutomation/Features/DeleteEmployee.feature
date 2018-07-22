Feature: DeleteEmployee
	As a user
	I want to be able to delete an employee

@regression
@DeleteEmployee
Scenario Outline: Delete an existing employee from the list
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
		And I click on the Delete button
	When I see the alert to confirm delete with message 'Are you sure you want to delete '
		And I 'dismiss' the alert
	Then I see and select the new employee listed
		And I click on the Delete button
	When I see the alert to confirm delete with message 'Are you sure you want to delete '
		And I 'accept' the alert
	Then I don't see the deleted employee listed
		And I close browser

Examples: 
| username | password  |
| Luke     | Skywalker |

#@regression
#@DeleteEmployee
#Scenario Outline: Delete an existing employee from the edit page

