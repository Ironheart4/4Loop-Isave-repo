CREATE TABLE [dbo].[Product] (
    [ProductID]      INT             IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (150)  NOT NULL,
    [Category]       NVARCHAR (50)   NULL,
    [ReplacementFor] INT             NULL,
    [PowerWattage]   DECIMAL (10, 2) NULL,
    [Capacity]       DECIMAL (10, 2) NULL,
    [Price]          DECIMAL (10, 2) NULL,
    [Link]           NVARCHAR (MAX)  NULL,
    [ImageURL]       NVARCHAR (MAX)  NULL,
    PRIMARY KEY CLUSTERED ([ProductID] ASC),
    FOREIGN KEY ([ReplacementFor]) REFERENCES [dbo].[DeviceType] ([DeviceTypeID])
);

