# Orders Repository API
This is just a simple kata to practice Outside In and web Api Patterns such as CQRS

## Requirements
Our API should be able to:
* Display an order as requested.
* Create an order with basic data.
* Update basic data of and order, specified by its ID.
* Add a product to an existent order product list as requested by user.
* Create a bill for and specified order.

## Features (Gherkin Language)
### Orders display
- Having a stored order in the system
- When the user requests it by its id
- That orders is displayed with the following data:
>- **ID: ORD123456**
>- **Customer: John Doe**
>- **Address: A Simple Street, 123**
>- **Products:**
>  - **Product:**
>    - **Name: Computer Monitor**
>    - **Price: 100€**
>  - **Product:**
>    - **Name: Keyboard** 
>    - **Price: 30€**
