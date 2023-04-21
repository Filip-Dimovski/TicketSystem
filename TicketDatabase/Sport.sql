CREATE TABLE [dbo].[Sport]
(
	[NastanId] INT NOT NULL PRIMARY KEY, 
    [Tip] NVARCHAR(50) NOT NULL, 
    [DomashenTimId] INT NULL, 
    [GostinskiTimId] INT NULL, 
    CONSTRAINT [FK_Sport_Nastan] FOREIGN KEY (NastanId) REFERENCES [Nastan]([Id]),
    CONSTRAINT [FK_Sport_DomashenTim] FOREIGN KEY (DomashenTimId) REFERENCES [Tim]([Id]),
	 CONSTRAINT [FK_Sport_GostinskiTIm] FOREIGN KEY (GostinskiTimId) REFERENCES [Tim]([Id]),	
)
