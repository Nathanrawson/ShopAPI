CREATE PROCEDURE SelectAllCategories
AS
SELECT * FROM dbo.Categories 
GO

CREATE PROCEDURE SelectCategoryById @CategoryId int
AS
SELECT * FROM dbo.Categories WHERE Id = @CategoryId
GO