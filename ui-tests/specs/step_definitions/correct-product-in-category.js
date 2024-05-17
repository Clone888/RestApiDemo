import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

Given('that I am on the products page', () => {
  cy.visit('/products');
});

When('I choose the Category {string}', (category) => {
  cy.get('#categories').select(category);
});

Then('I should see the Product {string}', (productName) => {
  cy.get('.product .name').contains(productName);
});
