# Here I do the homework with Scenario and after testing the "Alla"-category
# I switch to "Pets"-category in line 30

Feature: Show correct price to the product

    Scenario: Check that the correct price is displayed for the correct product.
        Given that I am on the product page
        When I choose the category "Alla"
        Then I should see the price "1000" for the product "Smartphone"
        And I should see the price "1500" for the product "Laptop"
        And I should see the price "20" for the product "T-shirt"
        And I should see the price "50" for the product "Jeans"
        And I should see the price "30" for the product "Python Programming"
        And I should see the price "15" for the product "The Great Gatsby"
        And I should see the price "15000" for the product "TV"
        And I should see the price "5" for the product "Apple"
        And I should see the price "10" for the product "Banana"
        And I should see the price "6" for the product "Orange"
        And I should see the price "20" for the product "Bread"
        And I should see the price "20000" for the product "Bed"
        And I should see the price "5000" for the product "Sofa"
        And I should see the price "2500" for the product "Table"
        And I should see the price "500" for the product "Chair"
        And I should see the price "7000" for the product "Dog"
        And I should see the price "300" for the product "Cat"
        And I should see the price "150" for the product "Fish"
        And I should see the price "4700" for the product "Bird"
        And I should see the price "50" for the product "Shorts"
        And I should see the price "48500" for the product "Dyndata Instructions"
        When I choose the category "Pets"
        Then I should see the price "7000" for the product "Dog"
        And I should see the price "300" for the product "Cat"
        And I should see the price "150" for the product "Fish"
        And I should see the price "4700" for the product "Bird"