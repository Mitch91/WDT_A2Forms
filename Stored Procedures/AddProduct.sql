CREATE PROCEDURE [dbo].[AddProduct](@cID int, @title nvarchar(max), @short nvarchar(max), 
	@long nvarchar(max), @price money)
  AS

INSERT INTO Product (CategoryID, Title, ShortDescription, LongDescription, Price)
VALUES
(@cID, @title, @short, @long, @price);