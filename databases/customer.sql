CREATE TABLE [dbo].[CUSTOMER]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [customername] VARCHAR(50) NOT NULL, 
    [isdeleted] BIT NOT NULL, 
    [deleteddate] DATE NULL
)
