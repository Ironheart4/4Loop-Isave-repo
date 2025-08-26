CREATE TABLE [dbo].[DeviceType] (
    [DeviceTypeID]      INT             IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (100)  NOT NULL,
    [Category]          NVARCHAR (50)   NULL,
    [TypicalPowerW]     INT             NULL,
    [TypicalUsageHours] DECIMAL (10, 2) NULL,
    PRIMARY KEY CLUSTERED ([DeviceTypeID] ASC)
);

