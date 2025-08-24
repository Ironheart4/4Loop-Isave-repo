using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ISaveBackend
{
    // NOTE: Service1 implements IService1
    public class Service1 : IService1
    {
        // LINQ-to-SQL DataContext (from SystemUser.dbml)
        private readonly SystemUserDataContext db = new SystemUserDataContext();

        // -------------------------------
        // Basic sample methods (kept for interface compatibility)
        // -------------------------------
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
                throw new ArgumentNullException("composite");

            if (composite.BoolValue)
                composite.StringValue += "Suffix";

            return composite;
        }

        // -------------------------------
        // Seed DeviceTypes (LINQ-to-SQL)
        // -------------------------------
        public string SeedDeviceTypes()
        {
            try
            {
                if (db.DeviceTypes.Any())
                    return "Device types already seeded.";

                var deviceTypes = new DeviceType[]
                {
                    new DeviceType { Name="LED Light Bulb", Category="Lighting", TypicalPowerW = 10, TypicalUsageHours = 5 },
                    new DeviceType { Name="Incandescent Bulb 60W (old)", Category="Lighting", TypicalPowerW = 60, TypicalUsageHours = 5 },
                    new DeviceType { Name="Desktop Computer", Category="Electronics", TypicalPowerW = 350, TypicalUsageHours = 4 },
                    new DeviceType { Name="Laptop Computer", Category="Electronics", TypicalPowerW = 50, TypicalUsageHours = 8 },
                    new DeviceType { Name="Wi-Fi Router/Modem", Category="Networking", TypicalPowerW = 20, TypicalUsageHours = 24 },
                    new DeviceType { Name="Refrigerator/Freezer (standard)", Category="Appliance", TypicalPowerW = 450, TypicalUsageHours = 24 },
                    new DeviceType { Name="LED Television", Category="Entertainment", TypicalPowerW = 110, TypicalUsageHours = 5 },
                    new DeviceType { Name="Electric Water Heater (Geyser)", Category="Heating", TypicalPowerW = 4200, TypicalUsageHours = 2 },
                    new DeviceType { Name="Washing Machine (average cycle)", Category="Appliance", TypicalPowerW = 1000, TypicalUsageHours = 1 },
                    new DeviceType { Name="Electric Kettle", Category="Small Appliance", TypicalPowerW = 2500, TypicalUsageHours = 0 },
                    new DeviceType { Name="Ceiling Fan", Category="Appliance", TypicalPowerW = 75, TypicalUsageHours = 6 },
                    new DeviceType { Name="Window AC (1.5 kW)", Category="Cooling", TypicalPowerW = 1500, TypicalUsageHours = 8 },
                    new DeviceType { Name="Old Fridge (non-inverter)", Category="Appliance", TypicalPowerW = 350, TypicalUsageHours = 24 },
                    new DeviceType { Name="Smart LED Bulb (efficient)", Category="Lighting", TypicalPowerW = 9, TypicalUsageHours = 5 },
                    new DeviceType { Name="Router + Home Network", Category="Networking", TypicalPowerW = 25, TypicalUsageHours = 24 }
                };

                foreach (var dt in deviceTypes)
                    db.DeviceTypes.InsertOnSubmit(dt);

                db.SubmitChanges();
                return "Device types seeded successfully.";
            }
            catch (Exception ex)
            {
                return $"Error seeding DeviceTypes: {ex.Message}";
            }
        }

        // -------------------------------
        // Seed Products (LINQ-to-SQL)
        // -------------------------------
        public string SeedProducts()
        {
            try
            {
                if (db.Products.Any())
                    return "Products already seeded.";

                var products = new Product[]
                {
                    new Product { Name="EcoFlow RIVER 2 Pro Portable Power Station", Category="Backup Power", ReplacementFor=null, PowerWattage=800m, Capacity=768m, Price=6746.00M, Link="https://us.ecoflow.com/products/river-2-pro-portable-power-station", ImageURL="https://us.ecoflow.com/cdn/shop/products/ecoflow-us-ecoflow-river-2-pro-portable-power-station-30042784006217_2000x.png?v=1742453520" },
                    new Product { Name="EcoFlow RIVER 3 Plus Portable Power Station", Category="Backup Power", ReplacementFor=null, PowerWattage=600m, Capacity=512m, Price=5312.00M, Link="https://us.ecoflow.com/products/river-3-plus-portable-power-station?variant=41636514136137", ImageURL="https://us.ecoflow.com/cdn/shop/files/ecoflow-us-ecoflow-river-3-plus-portable-power-station-standalone-36158995398729_1500x.png?v=1743047979" },
                    new Product { Name="EcoFlow RIVER 2 Max Portable Power Station", Category="Backup Power", ReplacementFor=null, PowerWattage=500m, Capacity=512m, Price=6200.00M, Link="https://us.ecoflow.com/products/delta-2-max-portable-power-station?variant=54615943512137", ImageURL="https://us.ecoflow.com/cdn/shop/files/ecoflow-us-ecoflow-delta-2-max-portable-power-station-d2m-delta-2-max-portable-power-station-1182569251_1500x.png?v=1754036926" },
                    new Product { Name="Jackery Explorer 500 Portable Power Station", Category="Backup Power", ReplacementFor=null, PowerWattage=500m, Capacity=518m, Price=5843.00M, Link="https://www.jackery.com/products/explorer-500w-portable-power-station", ImageURL="https://www.jackery.com/cdn/shop/products/explorer-500-series-3098563_650x.jpg?v=1754016786" },
                    new Product { Name="EcoFlow DELTA Pro Portable Power Station", Category="Backup Power", ReplacementFor=null, PowerWattage=3600m, Capacity=3600m, Price=32018.00M, Link="https://us.ecoflow.com/products/delta-pro-portable-power-station", ImageURL="https://us.ecoflow.com/cdn/shop/files/ecoflow-us-ecoflow-delta-pro-portable-power-station-dp-delta-pro-portable-power-station-1179495743_720x.png?v=1752913865" },
                    new Product { Name="EcoFlow DELTA 2 Portable Power Station", Category="Backup Power", ReplacementFor=null, PowerWattage=2200m, Capacity=1024m, Price=9149.00M, Link="https://us.ecoflow.com/products/delta-2-portable-power-station", ImageURL="https://us.ecoflow.com/cdn/shop/files/ecoflow-us-ecoflow-delta-2-portable-power-station-standalone-32169505587273_720x.png?v=1750213866" },
                    new Product { Name="EcoFlow DELTA 3 Portable Power Station", Category="Backup Power", ReplacementFor=null, PowerWattage=1800m, Capacity=2048m, Price=18670.00M, Link="https://us.ecoflow.com/products/delta-3-portable-power-station", ImageURL="https://us.ecoflow.com/cdn/shop/files/ecoflow-us-ecoflow-delta-3-portable-power-station-standalone-members-only-2-x-delta-3-1172596246_1500x.jpg?v=1750214520" },
                    new Product { Name="EcoFlow Smart Generator 3000", Category="Backup Power", ReplacementFor=null, PowerWattage=3000m, Capacity=null, Price=13334.00M, Link="https://us.ecoflow.com/collections/smart-generators/products/smart-generator-3000-dual-fuel", ImageURL="https://us.ecoflow.com/cdn/shop/files/ecoflow-us-ecoflow-smart-generator-3000-dual-fuel-accessory-34820074537033_720x.png?v=1731625451" },
                    new Product { Name="Kasa Smart Wi-Fi LED Bulb", Category="Lighting", ReplacementFor=null, PowerWattage=9m, Capacity=null, Price=152.00M, Link="https://www.amazon.com/Kasa-Smart-Changing-Dimmable-Compatible/dp/B08TB8Z5HF", ImageURL="https://m.media-amazon.com/images/I/61Y-TtwpVIL._AC_SL1500_.jpg" },
                    new Product { Name="eLEDing EE828WTL-AI Solar Powered Smart LED Area Light", Category="Lighting (Outdoor)", ReplacementFor=null, PowerWattage=9m, Capacity=null, Price=1495.00M, Link="https://eleding.com/ee828wtl-ai", ImageURL="https://eleding.com/pub/media/catalog/product/cache/244acabec83a275776b9d6e8f150198a/e/e/ee828wtl-ai-new_copy_1.jpg" },
                    new Product { Name="Dyson Solarcycle Morph Floor Lamp", Category="Lighting", ReplacementFor=null, PowerWattage=11.2m, Capacity=null, Price=15149.00M, Link="https://www.dyson.com/lighting/floor-lamps/solarcycle-morph-cf06/white-silver", ImageURL="https://dyson-h.assetsadobe2.com/is/image/content/dam/dyson/images/products/primary/292217-01.png?$responsive$&cropPathE=desktop&fit=stretch,1&wid=960" },
                    new Product { Name="EcoFlow 400W Portable Solar Panel", Category="Solar", ReplacementFor=null, PowerWattage=400m, Capacity=null, Price=10662.00M, Link="https://us.ecoflow.com/products/400w-portable-solar-panel", ImageURL="https://us.ecoflow.com/cdn/shop/files/ecoflow-us-ecoflow-400w-portable-solar-panel-1167002537_2000x.png?v=1747312249" },
                    new Product { Name="Renogy 200W ShadowFlux Anti-Shading N-Type Solar Panel", Category="Solar", ReplacementFor=null, PowerWattage=200m, Capacity=null, Price=4357.73M, Link="https://www.renogy.com/products/renogy-200w-shadowflux-anti-shading-n-type-solar-panel", ImageURL="https://www.renogy.com/cdn/shop/files/200W_6649ba40-807b-47b7-9b89-9a5faeac39b2.jpg?v=1754982644&width=1125" },
                    new Product { Name="LG Inverter Linear Compressor Side-by-Side Fridge", Category="Appliance (HVAC)", ReplacementFor=null, PowerWattage=150m, Capacity=null, Price=17900.00M, Link="https://www.pricecheck.co.za/offers/156393597/LG%2BGC-B247SLUV%2B626L%2BPlatinum%2BSilver%2BSide%2Bby%2BSide%2BRefrigerator", ImageURL="https://images2.pricecheck.co.za/images/objects/hash/product/863/d81/1a5/image_big_156393597.png?1554171936" },
                    new Product { Name="Segway Ninebot MAX G2 Electric Scooter", Category="Transportation", ReplacementFor=null, PowerWattage=900m, Capacity=551m, Price=29890.00M, Link="https://goelectric.co.za/products/segway-ninebot-max-g2-electric-scooter", ImageURL="https://goelectric.co.za/cdn/shop/files/1_abf4204e-952a-467a-9f97-cac1636aed77.png?v=1746779088&width=600" },
                    new Product { Name="EcoFlow WAVE 3 Portable Air Conditioner", Category="Cooling", ReplacementFor=null, PowerWattage=1800m, Capacity=null, Price=14204.00M, Link="https://us.ecoflow.com/products/ecoflow-wave-3-portable-air-conditioner-with-heater", ImageURL="https://us.ecoflow.com/cdn/shop/files/ecoflow-us-ecoflow-wave-3-portable-air-conditioner-members-only-1156083298_720x.png?v=1748935604" },
                    new Product { Name="TP-Link Kasa HS110 Smart Plug (Energy Monitoring)", Category="Smart Device", ReplacementFor=null, PowerWattage=1800m, Capacity=null, Price=178.00M, Link="https://www.amazon.com/TP-Link-HS110-Monitoring-Hub-Required/dp/B07B8W2KHZ", ImageURL="https://m.media-amazon.com/images/I/61mNHFdgj3L._SL1500_.jpg" },
                    new Product { Name="TP-Link Tapo P100 Smart Plug Mini", Category="Smart Device", ReplacementFor=null, PowerWattage=1200m, Capacity=null, Price=214.00M, Link="https://www.amazon.com/TP-Link-Tapo-Required-Appliances-P100/dp/B07ZQYVXH8", ImageURL="https://m.media-amazon.com/images/I/41l5Sds77SL._AC_SL1000_.jpg" },
                    new Product { Name="BioLite CampStove 2+", Category="Outdoor / Off-grid", ReplacementFor=null, PowerWattage=3m, Capacity=11.84m, Price=2668.00M, Link="https://www.bioliteenergy.com/products/campstove-2-plus", ImageURL="https://www.bioliteenergy.com/cdn/shop/files/campstove-2csc0200-382115.png?v=1711827654&width=1200" },
                    new Product { Name="Xiaomi Smart Air Purifier 4 EU", Category="Appliance", ReplacementFor=null, PowerWattage=38m, Capacity=null, Price=4999.00M, Link="https://xiaomistores.co.za/product/xiaomi-smart-air-purifier-4-eu/", ImageURL="https://xiaomistores.co.za/wp-content/uploads/2023/05/BHR5096GL_wr_02.jpg" }
                };

                db.Products.InsertAllOnSubmit(products);
                db.SubmitChanges();

                return "Products seeded successfully!";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        // -------------------------------
        // Simple data retrieval
        // -------------------------------
        public List<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public Product GetProduct(int productId)
        {
            return db.Products.FirstOrDefault(p => p.ProductID == productId);
        }

        // -------------------------------
        // Savings endpoint (implements IService1)
        // -------------------------------
        public SavingsResult GetProductSavings(int productId, int baselineDeviceTypeId, double tariff_RperKWh)
        {
            var calc = new ProductCalculator();

            // find product
            var product = db.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product == null)
            {
                return new SavingsResult
                {
                    ProductID = productId,
                    ProductName = "Product not found",
                    BaselineDeviceTypeID = baselineDeviceTypeId,
                    BaselineName = "N/A"
                };
            }

            // find baseline (may be null)
            var baseline = db.DeviceTypes.FirstOrDefault(d => d.DeviceTypeID == baselineDeviceTypeId);

            // compute energies (Wh/day)
            double productEnergyWh = calc.CalculateDailyEnergy(product, baseline);

            double baselineEnergyWh = 0;
            if (baseline != null && baseline.TypicalPowerW.HasValue && baseline.TypicalUsageHours.HasValue)
            {
                baselineEnergyWh = (double)(baseline.TypicalPowerW.Value * baseline.TypicalUsageHours.Value);
            }

            // convert to kWh/day
            double productEnergyKWh = productEnergyWh / 1000.0;
            double baselineEnergyKWh = baselineEnergyWh / 1000.0;

            // costs per day
            double productCostPerDay = productEnergyKWh * tariff_RperKWh;
            double baselineCostPerDay = baselineEnergyKWh * tariff_RperKWh;

            // energy & cost saved
            double energySavedKWhPerDay = baselineEnergyKWh - productEnergyKWh;
            if (energySavedKWhPerDay < 0) energySavedKWhPerDay = 0;

            double costSavedRPerDay = energySavedKWhPerDay * tariff_RperKWh;

            // CO2 & trees
            double CO2PerKWh = 0.94; // kg CO2 per kWh
            double CO2SavedKgPerDay = energySavedKWhPerDay * CO2PerKWh;
            double annualCO2SavedKg = CO2SavedKgPerDay * 365.0;
            double treesEquivalentPerYear = annualCO2SavedKg / 21.0;

            // build result
            var result = new SavingsResult
            {
                ProductID = product.ProductID,
                ProductName = product.Name,
                BaselineDeviceTypeID = baselineDeviceTypeId,
                BaselineName = baseline?.Name ?? "Baseline not found",

                EnergySavedKWhPerDay = Math.Round(energySavedKWhPerDay, 6),
                CostSavedRPerDay = Math.Round(costSavedRPerDay, 2),
                CO2SavedKgPerDay = Math.Round(CO2SavedKgPerDay, 4),
                TreesEquivalentPerYear = Math.Round(treesEquivalentPerYear, 3),

                ProductEnergyKWhPerDay = Math.Round(productEnergyKWh, 6),
                BaselineEnergyKWhPerDay = Math.Round(baselineEnergyKWh, 6),
                ProductCostRPerDay = Math.Round(productCostPerDay, 2),
                BaselineCostRPerDay = Math.Round(baselineCostPerDay, 2)
            };

            return result;
        }

        // -------------------------------
        // ProductCalculator (inner class)
        // -------------------------------
        public class ProductCalculator
        {
            // Daily energy used by the product in Wh
            public double CalculateDailyEnergy(Product p, DeviceType baseline)
            {
                // If product has capacity (stored as Wh or kWh depending on your design), use it directly.
                // We assume Capacity column stores Wh for batteries/power-stations; if it's kWh adjust accordingly.
                if (p.Capacity != null)
                {
                    // if Capacity was intended as Wh: return decimal -> double
                    return (double)p.Capacity.Value;
                }

                // Fallback to baseline device estimate (TypicalPowerW * TypicalUsageHours) -> Wh/day
                if (baseline != null && baseline.TypicalPowerW.HasValue && baseline.TypicalUsageHours.HasValue)
                {
                    return (double)(baseline.TypicalPowerW.Value * baseline.TypicalUsageHours.Value);
                }

                return 0;
            }

            // Daily cost of running the product in Rands
            public double CalculateDailyCost(Product p, DeviceType baseline, double tariff_RperKWh)
            {
                double energyWh = CalculateDailyEnergy(p, baseline);
                double energyKWh = energyWh / 1000.0;
                return energyKWh * tariff_RperKWh;
            }

            // Energy saved vs baseline in Wh/day
            public double CalculateEnergySaved(Product p, DeviceType baseline)
            {
                if (baseline == null)
                    return 0;

                double baselineEnergyWh = 0;
                if (baseline.TypicalPowerW.HasValue && baseline.TypicalUsageHours.HasValue)
                    baselineEnergyWh = (double)(baseline.TypicalPowerW.Value * baseline.TypicalUsageHours.Value);

                double productEnergyWh = CalculateDailyEnergy(p, baseline);
                return baselineEnergyWh - productEnergyWh;
            }

            // Cost saved vs baseline in R/day
            public double CalculateCostSaved(Product p, DeviceType baseline, double tariff_RperKWh)
            {
                double energySavedWh = CalculateEnergySaved(p, baseline);
                double energySavedKWh = energySavedWh / 1000.0;
                return energySavedKWh * tariff_RperKWh;
            }

            // CO2 saved (kg/day) based on energy saved (Wh) and grid emission factor (kg CO2 per kWh)
            public double CalculateCO2Saved(Product p, DeviceType baseline, double CO2PerKWh = 0.94)
            {
                double energySavedWh = CalculateEnergySaved(p, baseline); // Wh/day
                double energySavedKWh = energySavedWh / 1000.0;
                return energySavedKWh * CO2PerKWh; // kg CO2/day
            }

            // Optional: Convert CO2 saved to "trees planted equivalent"
            // Assumes 1 tree absorbs ~21 kg CO2/year
            public double CalculateTreesEquivalent(Product p, DeviceType baseline, double CO2PerKWh = 0.94)
            {
                double dailyCO2Saved = CalculateCO2Saved(p, baseline, CO2PerKWh);
                double annualCO2Saved = dailyCO2Saved * 365; // kg/year
                return annualCO2Saved / 21.0; // trees/year
            }
        }
    }
}
