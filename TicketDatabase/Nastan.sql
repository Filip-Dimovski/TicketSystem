﻿CREATE TABLE [dbo].[Nastan]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [Ime] NVARCHAR(250) NOT NULL, 
    [Slika] NVARCHAR(700) NOT NULL, 
    [Opis] TEXT NOT NULL,
	[RegularnaCena] FLOAT NOT NULL, 
)
