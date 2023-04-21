CREATE TABLE [dbo].[Teatar]
(
	[NastanId] INT NOT NULL PRIMARY KEY, 
    [TIp] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Teatar_Nastan] FOREIGN KEY ([NastanId]) REFERENCES [Nastan]([Id])
)
