CREATE PROCEDURE [dbo].[SP_add_message]
	@Username nvarchar(256),
	@Text nvarchar(300)
AS
BEGIN
	DECLARE @MaxId int
	SELECT @MaxId = MAX([Id]) + 1 FROM [dbo].[Messages]

	INSERT INTO [dbo].[Messages]
	([Id], [UserName], [Text], [ts]) values (@MaxId, @Username, @Text, GETDATE())
END
