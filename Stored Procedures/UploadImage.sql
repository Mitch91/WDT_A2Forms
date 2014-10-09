CREATE PROCEDURE [dbo].[UploadImage](@pID int, @imgUrl nvarchar(max))
	AS

UPDATE Product
SET ImageUrl = @imgUrl
WHERE ProductID = @pID;