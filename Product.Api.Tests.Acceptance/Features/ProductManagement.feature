
Feature: Retrive All Products
	As a user of the product service
	I want to retrieve a list of all products
	So that I can view the available products

Scenario: Successfully retrieve all products
	Given the product service is available
	When I request to get all products
	Then the response should contain a list of products
	And the response status code should be 200

Scenario: No Product Avaiable 
	 Given  the product service is available 
	 When I request to get all products
	 Then  the response should contain Empty list
	 And the response status code should be 200

Scenario: service is down 
	Given  the product service is unavailable 
	When I request to get all products
	Then  the response status code should be 503
	And the response Message should be "Service is not Avaiable"