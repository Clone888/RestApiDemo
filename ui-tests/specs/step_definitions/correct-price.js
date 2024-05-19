import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";


Then('I should see the price {string} for the product {string}', (price, productName) => {
  cy.get('.product').contains('div.product', productName).find('.price').contains('Pris: ' + price + ' kr')
});

