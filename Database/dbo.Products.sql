CREATE TABLE [dbo].[Products] (
    ProductID INT IDENTITY(1,1) ,
    Name NVARCHAR(200) NOT NULL,
    Category NVARCHAR(50) NULL,                 -- Lighting, Appliance, HVAC, Water Heating, Solar, Smart
    formula_type NVARCHAR(50) NOT NULL,         -- Enum: led, resistive, motor, thermostat, heat_pump, pv_offset, smart_plug
    rated_power_W INT NULL,                     -- Rated power, optional if measured_kwh is available
    standby_power_W INT NULL,                   -- For standby energy consumption (optional)
    avg_load_fraction FLOAT NULL,               -- Duty cycle or load factor (0–1), for motor/compressor devices
    COP FLOAT NULL,                            -- Coefficient of performance for heat pumps
    thermal_kwh_required FLOAT NULL,           -- For heat pump calculation (optional)
    measured_kwh FLOAT NULL,                   -- For smart plugs or measured devices
    pv_offset_kwh FLOAT NULL,                  -- For PV offset devices
    price_R DECIMAL(10,2) NULL,                -- Price in Rands
    retailer_url NVARCHAR(500) NULL,           -- Link to buy
    baselineDeviceTypeID INT NULL,             -- FK → DeviceTypes(DeviceTypeID)
    notes NVARCHAR(MAX) NULL,                  -- Extra info, optional
    confidence NVARCHAR(10) NULL			   -- Low / Medium / High
	PRIMARY KEY(ProductID)
);

