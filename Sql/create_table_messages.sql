CREATE TABLE [dbo].[Messages]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserName] NVARCHAR (256) NOT NULL, 
    [Text] NVARCHAR(300) NOT NULL, 
    [ts] DATETIME NOT NULL,
	FOREIGN KEY ([UserName]) REFERENCES [dbo].[AspNetUsers] ([UserName]) ON DELETE CASCADE
)
