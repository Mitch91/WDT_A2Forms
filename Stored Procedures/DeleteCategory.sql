CREATE PROCEDURE [dbo].[DeleteCategory](@cID int)
  AS

DELETE FROM Product 
WHERE CategoryID = @cID;

DELETE FROM Category
WHERE CategoryID = @cID