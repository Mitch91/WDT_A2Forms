CREATE PROCEDURE [dbo].[GetProductsForCategory](@cID int)
  AS
SELECT * FROM Product
WHERE CategoryID = @cID
