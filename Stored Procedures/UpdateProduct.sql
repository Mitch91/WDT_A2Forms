CREATE PROCEDURE [dbo].[UpdateProduct](@pID int, @cID int, @title nvarchar(max), @short nvarchar(max), 
	@long nvarchar(max), @price money)

	AS

	UPDATE Product
	SET CategoryID = @cID, Title = @title, ShortDescription = @short, LongDescription = @long, Price = @price
	WHERE ProductID = @pID