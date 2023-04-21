CREATE TABLE [dbo].[KoncertPejac]
(
	[KoncertId] INT NOT NULL, 
    [Pejach] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_KoncertPejac] PRIMARY KEY (KoncertId,Pejach), 
    CONSTRAINT [FK_KoncertPejac_Koncert] FOREIGN KEY (KoncertId) REFERENCES Koncert(NastanId) 
)
