CREATE TABLE [dbo].[CATEGORY]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [categoryname] VARCHAR(50) NOT NULL, 
    [isdeleted] BIT NOT NULL, 
    [deleteddate] DATE NULL
)
