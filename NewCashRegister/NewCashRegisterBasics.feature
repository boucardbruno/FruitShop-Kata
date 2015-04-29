Feature: FruitShop Basics

As a manager in a store called "FruitShop", 
I want to increase profits with a new cash register

Background: pricing list with all product
	![Text Alt](Pomme.jpg)
	Given the store sells these products:
	| Product name  | Price in cents |
	| Pommes	    | 100			 |
	| Bananes       | 150            |
	| Cerises       | 75             |
				
Scenario: basic usecase, no discount and no rebate 
    <b>Iteration 1: We just buy some products.</b>
	 
	When the customer buys 1 "Pommes"
	And the customer buys 2 "Cerises"
	Then the total price should be 250 cents

Scenario: Take into account few reductions 
	<b>Iteration 2: For 2 batches of cerises purchased 20 cents discount is applied.</b>
	
	Given a rebate of 20 cents when we buy 2 "Cerises"
	When the customer buys 2 "Cerises" 
    And the customer buys 1 "Pommes"
	Then the total price should be 230 cents

Scenario: New reductions
	<b>Iteration 3': Reduction on Cerises increased to 30 cents. 
	A batch of bananas purchased, the second is offered.</b>
	
	Given a discount on 2 "Bananes" for the price of 1 
	And a rebate of 30 cents when we buy 2 "Cerises"
	When the customer buys 2 "Cerises"
	And the customer buys 2 "Bananes" 
	Then the total price should be 270 cents

