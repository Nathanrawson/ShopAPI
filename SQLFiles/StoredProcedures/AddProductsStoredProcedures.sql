CREATE PROCEDURE SelectProductByCategory @CategoryId int
AS
SELECT * FROM dbo.Products WHERE CategoryId = @CategoryId 
GO

CREATE PROCEDURE SelectProductByName @ProductName nvarchar(30)
AS
SELECT * FROM dbo.Products WHERE ProductName = @ProductName 
GO

CREATE PROCEDURE SelectProdctById @SKU int
AS
SELECT * FROM dbo.Products WHERE SKU = @SKU 
GO

CREATE PROCEDURE SelectAllProducts
AS
SELECT * FROM dbo.Products 
GO

