Feature: FruitShop with localization and great discounts

As a manager in a store called "FruitShop", 
I want to increase profits with a new cash register

Background: 
	![Text Alt](Pomme.jpg)
	Given the store sells these products:
	| Product name  | Price in cents |
	| Pommes	    | 100			 |
	| Bananes       | 150            |
	| Cerises       | 75             |
	And the localization of "Pommes" in "Apples"
	And the localization of "Pommes" in "Mele"

Scenario: Create great discounts
    <b>Iteration 6: 4 Pommes purchased, 1 € reduction for the total amaunt of bill. 
	5 fruits purchased, 2 € discount.
	2 bananas for the price of 1.</b>
	
	Given these rebates in cents:
	| Product name | Quantity | Rebate in cents |
	| Fruits       | 5        | 200             |
	| * Pommes     | 4        | 100             |
	| Cerises      | 2        | 20              |
	And a discount on 2 "Bananes" for the price of 1
	And a rebate of 200 cents for 3 "Apples" 
	And a rebate of 100 cents for 2 "Mele" 
	When the customer buys these products:
	| Product name	| Quantity	|
	| Mele			| 4			|
	| Apples		| 4			|
	| Bananes		| 1			|
	| Pommes		| 1			|
	Then the total price should be 150 cents