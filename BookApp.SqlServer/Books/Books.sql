CREATE TABLE [dbo].[Books]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1, 1), 
    [Title] NVARCHAR(255) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL,
)
