CREATE TABLE [dbo].[KinoAkter] (
    [KinoId] INT           NOT NULL,
    [Akter]  NVARCHAR (50) NOT NULL,
    CONSTRAINT [Akter_PK] PRIMARY KEY CLUSTERED ([KinoId] ASC, [Akter] ASC),
    FOREIGN KEY ([KinoId]) REFERENCES [dbo].[Kino] ([NastanId])
);

