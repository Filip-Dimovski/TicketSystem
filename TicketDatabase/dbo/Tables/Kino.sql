CREATE TABLE [dbo].[Kino] (
    [NastanId] INT           NOT NULL,
    [Tip]      NVARCHAR (50) NULL,
    CONSTRAINT [PK] PRIMARY KEY CLUSTERED ([NastanId] ASC),
    FOREIGN KEY ([NastanId]) REFERENCES [dbo].[Nastan] ([Id])
);

