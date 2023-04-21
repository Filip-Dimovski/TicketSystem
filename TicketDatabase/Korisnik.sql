CREATE TABLE [dbo].[Korisnik]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [Ime] NVARCHAR(50) NOT NULL, 
    [Prezime] NVARCHAR(50) NOT NULL, 
    [Pol] CHAR NOT NULL, 
    [Email] NVARCHAR(150) NOT NULL, 
    [Lozinka] NVARCHAR(MAX) NOT NULL, 
    [DatumRagjanje] DATE NOT NULL, 
    [Drzhava] NVARCHAR(50) NOT NULL, 
    [IdKreditnaKartichka] INT, 
    CONSTRAINT [FK_Korisnik_KreditnaKartichka] FOREIGN KEY ([IdKreditnaKartichka]) REFERENCES [KreditnaKartichka]([Id]) ON DELETE SET NULL ON UPDATE CASCADE 
   
)
