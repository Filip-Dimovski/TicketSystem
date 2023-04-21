CREATE TABLE [dbo].[Zooloshka]
(
	[NastanId] INT NOT NULL PRIMARY KEY, 
    CONSTRAINT [FK_Zooloshka_Nastan] FOREIGN KEY (NastanId) REFERENCES Nastan(Id)
)
