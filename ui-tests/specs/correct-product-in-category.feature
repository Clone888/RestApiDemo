Feature: Show correct products when I choose "Books" in the menu

    Scenario: Check that the "Books"-category shows correct products.
        Given that I am on the product page
        When I choose the category "Books"
        Then I should see the product "Python Programming"
        And I should see the product "The Great Gatsby"
        And I should see the product "Dyndata Instructions"