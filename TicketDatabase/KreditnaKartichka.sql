﻿CREATE TABLE [dbo].[KreditnaKartichka]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [Broj] NVARCHAR(12) NOT NULL, 
    [Pari] FLOAT NOT NULL DEFAULT (2000), 
    CONSTRAINT [Pari] CHECK (Pari >=0)

)
