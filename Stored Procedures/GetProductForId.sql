CREATE PROCEDURE [dbo].[GetProductForId](@pID int)
	AS
SELECT * FROM Product
WHERE ProductID = @pID;