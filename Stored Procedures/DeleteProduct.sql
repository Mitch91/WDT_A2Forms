CREATE PROCEDURE [dbo].[DeleteProduct](@pID int)
  AS

DELETE FROM Product 
WHERE ProductID = @pID;