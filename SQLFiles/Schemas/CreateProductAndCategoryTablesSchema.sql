CREATE SCHEMA MMTShop;
GO


CREATE TABLE Products (SKU int, ProductName Varchar(100),ProductDescription Varchar(1000), Price DECIMAL(19, 4),CategoryId int, CreatedDate datetime, Active Bit);


CREATE TABLE Categories (Id int, CategoryName Varchar(100));