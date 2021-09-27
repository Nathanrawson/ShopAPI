# ShopAPI
A .Net 5.0 API using SQL without Entity Framework

step 1. Use CreateProductAndCategoryTableSchema.sql to create schema

step 2. run both AddProducts and AddCategory stored procedures sql files

step 3. run both seedCategories and seedProducts sql files 

step 4. open solution (ShopApi.sln) and build 

step 5. Make sure to set multiple start projects in solution properties and set both the API and API consumer app to both start

step 6. Start APP

Please find unit tests available to also test API Managers/ retreiving values from SQL tables.

Improvements I would make with more time would include: 

- More unit tests
- Ability to write to API via post and put requests as well
- Add stored procedures for updating DB
- Splt up SQLDatabaseConfigFile and name more appropriately
- Add more error handling and logging
- Add cache to save on request times
- Add UI interface to interact with API 


