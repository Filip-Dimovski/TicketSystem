CREATE TABLE [dbo].[NastanOdrzhuvanje]
(
	[NastanId] INT NOT NULL,
	[VremeOdrzhuvanje] DATETIME NOT NULL,
	[Lokacija] NVARCHAR(500) NOT NULL, 
	 [SlobodniMesta] INT NOT NULL, 
    [Cena] FLOAT NULL, 
    CONSTRAINT [FK_NastanOdrzhuvanje_Nastan] FOREIGN KEY (NastanId) REFERENCES Nastan(Id), 
    CONSTRAINT [PK_NastanOdrzhuvanje] PRIMARY KEY (NastanId,VremeOdrzhuvanje,Lokacija),

	
)
