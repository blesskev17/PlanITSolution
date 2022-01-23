Feature: JupiterToys

A short summary of the feature



Scenario: TC1_Verify_Contact_Submission
	Given I launch JupitorToyUrl
	And I click on contact
	And I enter <forename> <surname> <email> <telephone> and <message>
	When I click on submit button
	Then verify the success message displayed
	
Examples: 
| forename | surname | email                     | telephone  | message         |
| john     | honai   | john.honai@example.com    | 0451765890 | adding contacts |
| kevin    | cherian | kevin.cherian@example.com | 0451765887 | adding contacts |
| Blessy   | Mathew  | blessy.mathew@example.com | 0451765892 | adding contacts |
| Bobby    | Mathew  | bobby.mathew@example.com  | 0451765897 | adding contacts |
| kishan   | rajan   | kishan.Rajan@example.com  | 0451765893 | adding contacts |


Scenario: TC2_Verify_Items_in_Cart
	Given I launch JupitorToyUrl
	And I click on Shop
	And I click buy button on 'Funny Cow' 
	And I click buy button on 'Funny Cow'
	And I click buy button on 'Fluffy Bunny'
	When I click on cart
	Then I verify the items Funny Cow and Fluffy Bunny in cart
	

Scenario: TC3_Verify_Subtotal_for_each_product
	Given I launch JupitorToyUrl
	And I click on Shop
	And I click buy button on 'Stuffed Frog' for 2 times
	And I click buy button on 'Fluffy Bunny' for 5 times
	And I click buy button on 'Valentine Bear' for 3 times
	When I click on cart	
	Then I verify the Subtotal for each of the product
	