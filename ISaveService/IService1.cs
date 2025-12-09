using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ISaveService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        int RegisterUser(String name, String surname, String email, String password, String Phone, char User_type);

        [OperationContract]
        UserDTO Login(string email, string password);


        [OperationContract]
        int UpdateUser(String name, String surname, String email, String password, String Phone, char User_type);

        [OperationContract]
        int DeleteUser(int id);

        [OperationContract]
        User GetUser(int id);

        [OperationContract]
        List<User> GetUsers();




        //*******START PRODUCT MANAGEMENT********

        [OperationContract]
        int AddProduct(String name, String description, int price, Char in_stock, decimal energy_saved_watts, decimal carbon_reductionKG, String image, String link);

        [OperationContract]
        Product GetProduct(int id);

        [OperationContract]
        List<Product> GetProducts();

        //*******END PRODUCT MANAGEMENT********

        //CART MANAGEMENT///
        [OperationContract]
        int AddOrder(int userId, int ProductId, int quantity, decimal price);

        [OperationContract]
        int deletOrder(int userId, int ProductId);

        [OperationContract]
        List<CartItemDTO> GetUserCart(int userId);


        //Adimn management//
        [OperationContract]
        int GetTotalCustomers();

        [OperationContract]
        int GetTotalProducts();

        [OperationContract]
        int GetTotalOrders();

        [OperationContract]
        List<CartItemDTO> GetOrderSummary(int orderId);

        [OperationContract]
        int PlaceOrder(int userId, string fullName, string email, string address);

        [OperationContract]
        bool MarkOrderAsPaid(int orderId);

        [OperationContract]
        string GetInvoiceNumber(int orderId);

        //Dashboard
        [OperationContract]
        DashboardStats GetDashboardStats(int userId);
        [OperationContract]
        List<PurchaseDTO> GetRecentPurchases(int userId);
        [OperationContract]
        List<InvoiceDTO> GetRecentInvoices(int userId);
        [OperationContract]
        List<PurchaseDTO> GeAllPurchases(int userId);
        [OperationContract]
        List<InvoiceDTO> GetAllInvoices(int userId);

        [OperationContract]
        SavingsTrendsDTO GetSavingsTrends(int userId);

        [OperationContract]
        int DeleteProduct(int id);

        [OperationContract]
        List<ProductRevenueDTO> GetRevenuePerProduct();

        [OperationContract]
        decimal GetTotalSales();

        [OperationContract]
        List<UserPurchaseDTO> GetAllUserPurchases();

        [OperationContract]
        List<TopProductDTO> GetTopProducts(int topN);
        [OperationContract]
        int UpdateProduct(String name, String description, decimal price, Char in_stock, decimal energy_saved_watts, decimal carbon_reductionKG, String image, int id);

        [OperationContract]
        List<SalesTrendDTO> GetSalesTrend();
    }
    [DataContract]
    public class UserDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public char UserType { get; set; }
    }
    [DataContract]
    public class CartItemDTO
    {
        [DataMember] public int ProductId { get; set; }
        [DataMember] public string ProductName { get; set; }
        [DataMember] public string Image { get; set; }
        [DataMember] public int Quantity { get; set; }
        [DataMember] public decimal Price { get; set; }
        [DataMember] public decimal ItemTotal { get; set; }
    }
    [DataContract]
    public class CartItem
    {
        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public int Quantity { get; set; }
    }
    [DataContract]
    public class DashboardStats
    {
        [DataMember]
        public decimal EnergySavedW { get; set; }
        [DataMember]
        public decimal MoneySavedMonthly { get; set; }
        [DataMember]
        public decimal Co2ReducedKg { get; set; }
        [DataMember]
        public decimal YearlyProjection { get; set; }
    }

    [DataContract]
    public class PurchaseDTO
    {
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public DateTime PurchaseDate { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public decimal MonthlySavings { get; set; }
    }

    [DataContract]
    public class InvoiceDTO
    {
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public DateTime IssuedDate { get; set; }
        [DataMember]
        public decimal TotalAmount { get; set; }
        [DataMember]
        public string Status { get; set; }
    }

    [DataContract]
    public class SavingsTrendsDTO
    {
        [DataMember]
        public List<string> Labels { get; set; }
        [DataMember]
        public List<decimal> Money { get; set; }
        [DataMember]
        public List<decimal> Energy { get; set; }
        [DataMember]
        public List<decimal> Co2 { get; set; }
    }
    [DataContract]
    public class SalesTrendDTO
    {
        [DataMember]
        public string Day { get; set; } 
        [DataMember]
        public decimal Total { get; set; } // Total sales
    }

    [DataContract]
    public class TopProductDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Quantity { get; set; } // Sold quantit

    }
    [DataContract]
    public class UserPurchaseDTO
    {
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public int TotalPurchases { get; set; }
    }

    [DataContract]
    public class ProductRevenueDTO
    {
        [DataMember]
        public string ProductName { get; set; } // Name of the product
        [DataMember]
        public decimal Revenue { get; set; }    // Total revenue generated by that product
    }

}
