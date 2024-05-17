Feature: Show correct price to the product

    Scenario: Check that the correct price is displayed for the correct product.
        Given that I am on the product page
        When I choose the category "Alla"
        Then I should see the price "1000" for the product "Smartphone"
        And I should see the price "50" for the product "Jeans"
