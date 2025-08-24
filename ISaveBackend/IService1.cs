using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ISaveBackend
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // Seeding / CRUD helpers
        [OperationContract]
        string SeedProducts();

        [OperationContract]
        string SeedDeviceTypes();

        [OperationContract]
        List<Product> GetProducts();

        [OperationContract]
        Product GetProduct(int productId);

        // Single-call savings endpoint (returns energy & cost saved + CO2)
        [OperationContract]
        SavingsResult GetProductSavings(int productId, int baselineDeviceTypeId, double tariff_RperKWh);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.(delete later)
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    // Data Transfer Object returned by GetProductSavings
    [DataContract]
    public class SavingsResult
    {
        [DataMember] public int ProductID { get; set; }
        [DataMember] public string ProductName { get; set; }
        [DataMember] public int BaselineDeviceTypeID { get; set; }
        [DataMember] public string BaselineName { get; set; }

        // energy saved per day (kWh)
        [DataMember] public double EnergySavedKWhPerDay { get; set; }

        // money saved per day (R)
        [DataMember] public double CostSavedRPerDay { get; set; }

        // CO2 saved per day (kg)
        [DataMember] public double CO2SavedKgPerDay { get; set; }

        // Trees equivalent per year (trees/year)
        [DataMember] public double TreesEquivalentPerYear { get; set; }

        // Also include the raw product/baseline energy/cost if useful
        [DataMember] public double ProductEnergyKWhPerDay { get; set; }
        [DataMember] public double BaselineEnergyKWhPerDay { get; set; }
        [DataMember] public double ProductCostRPerDay { get; set; }
        [DataMember] public double BaselineCostRPerDay { get; set; }
    }
}
