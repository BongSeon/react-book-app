﻿CREATE TABLE [dbo].[01_Books]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(255) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL,
    [Created] DateTime Default(GetDate()) Null,
)
