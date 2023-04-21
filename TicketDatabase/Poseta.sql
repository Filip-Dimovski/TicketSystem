CREATE TABLE [dbo].[Poseta]
(
    [KorisnikId] INT NOT NULL, 
    [NastanId] INT NOT NULL, 
	
    [DatumRezervacija] DATETIME NOT NULL, 
    [VremeOdrzhuvanje] DATETIME NOT NULL, 
    [Lokacija] NVARCHAR(500) NOT NULL, 
    CONSTRAINT [AK_Poseta_KN] PRIMARY KEY (KorisnikId,NastanId,DatumRezervacija), 
    CONSTRAINT [FK_Poseta_NastanOdrzhuvanje] FOREIGN KEY (NastanId,VremeOdrzhuvanje,Lokacija) REFERENCES NastanOdrzhuvanje(NastanId,VremeOdrzhuvanje,Lokacija)
)
