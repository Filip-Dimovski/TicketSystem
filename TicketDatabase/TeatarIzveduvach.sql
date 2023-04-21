CREATE TABLE [dbo].[TeatarIzveduvach]
(
	[TeatarId] INT NOT NULL, 
    [Izveduvach] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_TeatarIzveduvach_Koncert] FOREIGN KEY (TeatarId) REFERENCES [Teatar]([NastanId]), 
    CONSTRAINT [PK_TeatarIzveduvach] PRIMARY KEY (TeatarId,Izveduvach),


)
