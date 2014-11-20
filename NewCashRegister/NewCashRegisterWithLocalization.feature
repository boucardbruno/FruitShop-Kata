Feature: FruitShop with localization supported and new discounts

As a manager in a store called "FruitShop", 
I want to increase profits with a new cash register

Background: 
	
	Given the store sells these products:
	| Product name  | Price in cents |
	| Pommes	    | 100			 |
	| Bananes       | 150            |
	| Cerises       | 75             |
	And the localization of "Pommes" in "Apples"
	And the localization of "Pommes" in "Mele"

Scenario: Localization support
	Few products are translated in english and italian 
	Modification: for 2 batches of cerises purchased 30 cents discount is applied.    

	Given a discount on 2 "Bananes" for the price of 1 
	And a rebate of 20 cents when we buy 2 "Cerises"
	When the customer buys 2 "Cerises"
	And the customer buys 1 "Apples" 
	And the customer buys 2 "Bananes" 
	Then the total price should be 380 cents

Scenario: New discounts based on the localization 
	3 batches of "Apples" worth 2 €
	2 batches of "Mele" worth 1 €

	Given a discount on 2 "Bananes" for the price of 1 
	And a rebate of 200 cents for 3 "Apples" 
	And a rebate of 100 cents for 2 "Mele" 
	And a rebate of 20 cents when we buy 2 "Cerises" 
	When the customer buys these products:
	| Product name	| Quantity	| 
	| Mele			| 2         | 
	| Apples		| 3         | 
	| Pommes		| 1         |  
	| Cerises		| 2         |
	| Bananes		| 1         |	
	Then the total price should be 680 cents
