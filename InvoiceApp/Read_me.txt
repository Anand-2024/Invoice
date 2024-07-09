App name - InvoiceApp

Instructions to run and test the application are as follow
1. Used Newtonsoft.json Nuget package for serialization/Deserialization so make sure all the dependencies are in place and app runs fine
2. it's a console application needs to be tested in interactive mode
3. launch the app you will get options for vairous operations - type any number 1-5 accordingly ex. 1 for manage products
4. agian type any number from given options ex. 4 to list products
5. enter to go to main menu
6. to generate invoice (refer dummy data/json files for input)
	- type 4 (and enter) to create invoice
	- Enter Customer Name (ex. C1/C2  enter)
	- Add Product to Cart - type product name you wish to add to cart (ex. P1/P2  enter)
	- type 'done' after adding products to cart and enter
	- Select Payment Option by typing number 1/2 and enter
	there you go invoice will be displayed

follow the same procedure to add/update/delete/list products/category/customers accordingly.

note : Discounts calculation is ignored, error handling is not at all the places,