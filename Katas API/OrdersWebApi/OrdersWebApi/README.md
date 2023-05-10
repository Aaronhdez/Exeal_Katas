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
>- **ID**: ORD123456
>- **Customer**: John Doe
>- **Address**: A Simple Street, 123
>- **Products: [**
>  - { Name: Computer Monitor, Price: 100€ },
>  - { Name: Keyboard, Price: 30€ }
>-  **]**

### Orders Edit
- Having a stored order in the system
- When the user edits it by its id
- That orders is displayed with the modified data:
>- **ID**: ORD123456
>- **Customer**: John **Smith**
>- **Address**: **Another** Simple Street, 123
>- **Products: [**
>  - { Name: Computer Monitor, Price: 100€ },
>  - { Name: Keyboard, Price: 30€ }
>-  **]**

### Adding Products To Order
- Having a stored order in the system
- When the user adds a list of new products to it by its id
- That orders is displayed with the modified data:
>- **ID:** ORD123456
>- **Customer:** John Doe
>- **Address:** A Simple Street, 123
>- **Products: [**
>  - { Name: Computer Monitor, Price: 100€ },
>  - **{ Name: Computer Monitor, Price: 100€ },**
>  - { Name: Keyboard, Price: 30€ },
>  - **{ Name: Keyboard, Price: 30€ }**
>-  **]**

### Getting A Bill of An Order
- Having a stored order in the system
- When the user request a Bill from it
- That bill is displayed with the order data:
>- **BillId:** BLL000001
>- **OrderId:** ORD123456
>- **Company:** Computer Stuff Inc.
>- **Company_address:** A company Address
>- **Customer:** John Doe
>- **Customer_address:** A Simple Street, 123
>- **Items: [**
>  - { "2 x 'Computer Monitor'", 200 },
>  - { "2 x 'Keyboard'", 60 },
>  - { "1 x 'Mouse'", 15 }
>-  **]**
>- **Total:** 335

