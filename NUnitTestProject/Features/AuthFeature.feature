Feature: Authorization
	Login to personal cabinet
	As a user
	With login and password
	And check main page is open successfully

@scopedBinding
Scenario: Login to service
	Given I have entered login into the field
	And I have entered password into the field
	When I press enter
	Then the result should be main paged opened
