CREATE PROCEDURE [dbo].[SP_get_messages]
	@Amount INT
AS
BEGIN
	SELECT TOP (@Amount) [Id], [UserName], [Text], [ts]
	FROM [dbo].[Messages]
	ORDER BY [ts] DESC
END
