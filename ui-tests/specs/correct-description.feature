# Here I do the homework with Scenario Outline & Examples

Feature: Show correct description to the product

    Scenario Outline: Check that the correct description is displayed for the correct product.
        Given that I am on the product page
        When I choose the category "<category>"
        Then I should see the description "<description>"  for the product "<product>"

        Examples:
            | category | description                                            | product              |
            | Alla     | High-end smartphone with advanced features             | Smartphone           |
            | Alla     | Thin and lightweight laptop for work and entertainment | Laptop               |
            | Alla     | Casual cotton t-shirt in various colors                | T-shirt              |
            | Alla     | Classic denim jeans for everyday wear                  | Jeans                |
            | Alla     | A comprehensive guide to Python programming language   | Python Programming   |
            | Alla     | A classic novel by F. Scott Fitzgerald                 | The Great Gatsby     |
            | Alla     | Quality TV                                             | TV                   |
            | Alla     | A delicious and healthy fruit.                         | Apple                |
            | Alla     | A sweet and nutritious fruit.                          | Banana               |
            | Alla     | A citrus fruit with a tangy taste.                     | Orange               |
            | Alla     | A staple food made from flour, water, and yeast.       | Bread                |
            | Alla     | Used for sleeping.                                     | Bed                  |
            | Alla     | For sitting.                                           | Sofa                 |
            | Alla     | With a flat top and one or more legs.                  | Table                |
            | Alla     | With a seat and a back                                 | Chair                |
            | Alla     | A domesticated carnivorous mammal                      | Dog                  |
            | Alla     | A small domesticated carnivorous mammal                | Cat                  |
            | Alla     | A cold-blooded vertebrate aquatic animal               | Fish                 |
            | Alla     | A warm-blooded vertebrate animal                       | Bird                 |
            | Alla     | Blue and red                                           | Shorts               |
            | Alla     | Documentation of dynadata nuget package                | Dyndata Instructions |
            | Food     | A delicious and healthy fruit.                         | Apple                |
            | Food     | A sweet and nutritious fruit.                          | Banana               |
            | Food     | A citrus fruit with a tangy taste.                     | Orange               |
            | Food     | A staple food made from flour, water, and yeast.       | Bread                |
