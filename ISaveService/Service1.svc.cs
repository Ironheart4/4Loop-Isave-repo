using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using static ISaveService.IService1;

namespace ISaveService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        ISaveLINQDataContext db = new ISaveLINQDataContext();

        public int AddProduct(string name, string description, int price, char in_stock, decimal energy_saved_watts, decimal carbon_reductionKG,  string image, string link)
        {
            
                var tempProduct = (from p in db.Products
                                   where p.Name.Equals(name)
                                   && p.Description.Equals(description)
                                   && p.Price.Equals(price)
                                   && p.InStock.Equals(in_stock)
                                   && p.EnergySavedWatts.Equals(energy_saved_watts)
                                   && p.CarbonReductionKg.Equals(carbon_reductionKG)
                                   && p.Image.Equals(image)
                                   && p.Link.Equals(link)
                                   select p).FirstOrDefault();

                if (tempProduct == null)
                {
                    var objProduct = new Product();

                    objProduct.Name = name;
                    objProduct.Description = description;
                    objProduct.Price = price;
                    objProduct.InStock = in_stock;
                    objProduct.CarbonReductionKg = carbon_reductionKG;
                    objProduct.EnergySavedWatts = energy_saved_watts;
                    objProduct.Image = image;
                    objProduct.Link = link;
                    
                    

                    db.Products.InsertOnSubmit(objProduct);
                    try
                    {
                        db.SubmitChanges();
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        ex.GetBaseException();
                        return -1;
                    }
                }
                else
                {
                    return 1;
                }
        }

        public int DeleteUser(int id)
        {
            var UserToDelete = (from u in db.Users
                                where u.Id.Equals(id)
                                select u).FirstOrDefault();

            if(UserToDelete != null)
            {
                db.Users.DeleteOnSubmit(UserToDelete);
                try
                {
                    db.SubmitChanges();
                    return 0; //user deleted succeffully
                }catch(Exception ex)
                {
                    ex.GetBaseException();
                    return -1; //some internal error 
                }
            }else
            {
                return 1; //user not found
            }
        }

        public Product GetProduct(int id)
        {
            var tempProduct = (from u in db.Products
                               where u.Id.Equals(id)
                               select u).FirstOrDefault();

            if (tempProduct != null)
            {
                Product objProduct = new Product();

                objProduct.Name = tempProduct.Name;
                objProduct.Price = tempProduct.Price;
                objProduct.Description = tempProduct.Description;
                objProduct.CarbonReductionKg = tempProduct.CarbonReductionKg;
                objProduct.EnergySavedWatts = tempProduct.EnergySavedWatts;
                objProduct.Image = tempProduct.Image ;
                objProduct.Link = tempProduct.Link;
           

                return objProduct;
            }
            else
            {
                return null;
            }
        }

        public List<Product> GetProducts()
        {
            List<Product> ProductsList = new List<Product>();

            dynamic tempProdsList = (from p in db.Products
                                     where p.InStock.Equals("Y")
                                     select p);

            if (tempProdsList != null)
            {
                foreach (Product product in tempProdsList)
                {
                   Product objProduct = new Product();

                    objProduct.Id = product.Id;
                    objProduct.Name = product.Name;
                    objProduct.Description = product.Description;
                    objProduct.Price = product.Price;
                    objProduct.CarbonReductionKg = product.CarbonReductionKg;
                    objProduct.EnergySavedWatts = product.EnergySavedWatts;
                    objProduct.Image = product.Image;
                    objProduct.Link = product.Link;
                    

                    ProductsList.Add(objProduct);
                }
                return ProductsList;

            }
            else
            {
                return null;
            }
        }

        public User GetUser(int id)
        {
            var tempUser = (from u in db.Users where
                            u.Id.Equals(id)
                            select u).FirstOrDefault();

            if(tempUser != null)
            {
                User objUser = new User();
                objUser.FirstName = tempUser.FirstName;
                objUser.LastName = tempUser.LastName;
                objUser.Email = tempUser.Email;
                objUser.Password = tempUser.Password;
                objUser.Phone = tempUser.Phone;
                objUser.Address = tempUser.Address;

                return objUser;
            }
            else
            {
                return null;
            }
        }

        public List<User> GetUsers()
        {
            List<User> UserList = new List<User>();
            var tempUser = (from u in db.Users
                            where u.UserType.Equals('C')
                            select u);

            if(tempUser != null)
            {
                foreach(User user in tempUser)
                {
                    User objUser = new User();
                    objUser.FirstName = user.FirstName;
                    objUser.LastName = user.LastName;
                    objUser.Email = user.Email;
                    objUser.Password = user.Password;
                    objUser.Phone = user.Phone;
                    objUser.Address = user.Address;

                    UserList.Add(objUser);
                }
                return UserList;

            }
            else
            {
                return null;
            }
        }

        public UserDTO Login(string email, string Password)
        {
            var HashedPassword = Secrecy.HashPassword(Password);
            var tempUser = (from u in db.Users where
                            u.Email.Equals(email) &&
                            u.Password.Equals(HashedPassword)
                            select u).FirstOrDefault();

            // If no user found, return null
                if (tempUser == null)
                return null;

            // Map EF user to DTO
            return new UserDTO
            {
                Id = tempUser.Id,
                UserType = tempUser.UserType
            };
        }

        public int RegisterUser(string name, string surname, string email, string password, string Phone, char User_type)
        {
            var HashedPassword = Secrecy.HashPassword(password);
            var tempUser = (from u in db.Users where
                             u.Email.Equals(email) &&
                             u.Password.Equals(HashedPassword)
                             select u).FirstOrDefault();

            if(tempUser == null)// checking if uder does mot exist
            {
                User objUser = new User(); // creating a new class object which will be stored in the database

                objUser.FirstName = name;
                objUser.LastName = surname;
                objUser.Email = email;
                objUser.Password = HashedPassword;
                objUser.Phone = Phone;
                objUser.UserType = User_type;
                objUser.Address = "kingsway";
                db.Users.InsertOnSubmit(objUser);

                try
                {
                    db.SubmitChanges();
                    return 0; // everything went well
                }catch(Exception ex)
                {
                    ex.GetBaseException(); //handling some internal errors
                    return -1;
                }

            }
            else
            {
                return 1; //user Exists
            }
        }

        public int UpdateUser(string name, string surname, string email, string password, string Phone, char User_type)
        {
            var HashedPassword = Secrecy.HashPassword(password);
            var tempUser = (from u in db.Users where
                            u.Email.Equals(email) &&
                            u.Password.Equals(HashedPassword)
                            select u).FirstOrDefault();

            if (tempUser == null)// checking if uder does mot exist
            {
                User objUser = new User(); // creating a new class object which will be stored in the database

                objUser.FirstName = name;
                objUser.LastName = surname;
                objUser.Email = email;
                objUser.Password = HashedPassword;
                objUser.Phone = Phone;
                objUser.UserType = User_type;
                

                try
                {
                    db.SubmitChanges();
                    return 0; // everything went well
                }
                catch (Exception ex)
                {
                    ex.GetBaseException(); //handling some internal errors
                    return -1;
                }

            }
            else
            {
                return 1; //user Exists
            }
        }
        public int AddOrder(int userId, int ProductId, int quantity, decimal price)
        {
            var order=(from o in db.OrderDetails where o.ProductID.Equals(ProductId) && o.UserID.Equals(userId)
                       && o.Price.Equals(price) && o.Quantity.Equals(quantity) select o).FirstOrDefault();

            if(order ==null)
            {
                OrderDetail newOrder = new OrderDetail();
                newOrder.UserID = userId;
                newOrder.ProductID = ProductId;
                newOrder.Quantity = quantity;
                newOrder.Price = price;

                db.OrderDetails.InsertOnSubmit(newOrder);
                try
                {
                    db.SubmitChanges();
                    return 1; //order added to cart
                }
                catch(Exception e)
                {
                    e.GetBaseException();
                    return -1; //order doesnt exist
                }
            }
            else
            {
                return 0; //order already exist
            }
        }
        public int deletOrder(int userId, int ProductId)
        {
             var order=(from o in db.OrderDetails where o.ProductID.Equals(ProductId) && o.UserID.Equals(userId)
                 select o).FirstOrDefault();

            if (order != null)
            {

                db.OrderDetails.DeleteOnSubmit(order);
                try
                {
                    db.SubmitChanges();
                    return 1; //order deleted
                }
                catch (Exception e)
                {
                    e.GetBaseException();
                    return -1; //order doesnt exist
                }
            }
            else
            {
                return 0;
            }

        }
        public List<CartItemDTO> GetUserCart(int userId)
        {
            var items = db.OrderDetails
                .Where(o => o.UserID == userId)
                .Select(o => new CartItemDTO
                {
                    ProductId = o.ProductID,
                    ProductName = o.Product.Name,
                    Image = o.Product.Image,
                    Quantity = o.Quantity,
                    Price = o.Price,
                    ItemTotal = o.Quantity * o.Price
                }).ToList();

            return items;
        }

        public int GetTotalCustomers()
        {
            return db.Users.Count(u => u.UserType == 'C');
        }
        public decimal GetTotalSales()
        {
            return db.Orders.Where(o => o.Status == "Paid").Sum(o => (decimal?)o.TotalAmount) ?? 0;
        }

        public int GetTotalProducts()
        {
            return db.Products.Count();
        }
        public List<UserPurchaseDTO> GetAllUserPurchases()
        {
            var result = (from o in db.Orders
                          join u in db.Users on o.UserId equals u.Id
                          group u by new { u.Id, u.FirstName, u.LastName } into g
                          orderby g.Count() descending
                          select new UserPurchaseDTO
                          {
                              FullName = g.Key.FirstName + " " + g.Key.LastName,
                              TotalPurchases = g.Count()
                          }).ToList();

            return result;
        }

        public List<ProductRevenueDTO> GetRevenuePerProduct()
        {
            var result = (from od in db.OrderItems
                          join p in db.Products on od.ProductId equals p.Id
                          join o in db.Orders on od.OrderId equals o.Id
                          where o.Status == "Paid"
                          group new { od, p } by new { od.ProductId, p.Name } into g
                          select new ProductRevenueDTO
                          {
                              ProductName = g.Key.Name,
                              Revenue = g.Sum(x => x.od.Price * x.od.Quantity)
                          }).OrderByDescending(x => x.Revenue).ToList();

            return result;
        }


        public int GetTotalOrders()
        {
            return db.Orders.Count();
        }
        // === Sales Trend (grouped by month) ===
        public List<SalesTrendDTO> GetSalesTrend()
        {
            // First, group by date in SQL-friendly way
            var salesTrendRaw = (from o in db.Orders
                                 join od in db.OrderItems on o.Id equals od.OrderId
                                 group od by o.OrderDate.Date into g
                                 orderby g.Key
                                 select new
                                 {
                                     Day = g.Key,
                                     Total = g.Sum(x => x.Quantity * x.Price)
                                 }).ToList(); // execute query

            // Now format dates in C# (in memory)
            var salesTrend = salesTrendRaw.Select(x => new SalesTrendDTO
            {
                Day = x.Day.ToString("yyyy-MM-dd"),
                Total = x.Total
            }).ToList();

            return salesTrend;
        }



        // === Top Products ===
        public List<TopProductDTO> GetTopProducts(int top)
        {
            var topProducts = (from od in db.OrderItems
                               join p in db.Products on od.ProductId equals p.Id
                               group od by p.Name into g
                               orderby g.Sum(x => x.Quantity) descending
                               select new TopProductDTO
                               {
                                   Name = g.Key,
                                   Quantity = g.Sum(x => x.Quantity)
                               }).Take(top).ToList();

            return topProducts;
        }



        // === Data Transfer Objects (DTOs) ===
        public int PlaceOrder(int userId, string fullName, string email, string address)
        {
            // Get all items in the user's cart
            var cartItems = db.OrderDetails.Where(c => c.UserID == userId).ToList();
            if (!cartItems.Any()) return -1; // Cart is empty

            // Calculate subtotal
            decimal subtotal = cartItems.Sum(c => c.Quantity * c.Price);

            // Determine shipping cost based on subtotal
            decimal shipping = 0;
            if (subtotal < 500) shipping = 50;       // small orders
            else if (subtotal < 1000) shipping = 25; // medium orders
            else shipping = 0;                        // free shipping for large orders

            // Total amount including shipping
            decimal totalAmount = subtotal + shipping;

            // Generate a unique invoice number
            string invoiceNumber = "INV" + DateTime.Now.ToString("yyyyMMddHHmmss") + userId;

            // Create the new order
            var newOrder = new Order
            {
                UserId = userId,
                FullName = fullName,
                Email = email,
                Address = address,
                OrderDate = DateTime.Now,
                TotalAmount = totalAmount,
                ShippingCost = shipping,
                Paid = true,
                Status = "Pending",// mark as paid
                InvoiceNumber = invoiceNumber,
                PaymentDate = DateTime.Now
            };

            db.Orders.InsertOnSubmit(newOrder);
            db.SubmitChanges(); // Save to get OrderId

            // Insert each cart item into OrderItems
            foreach (var item in cartItems)
            {
                var orderItem = new OrderItem
                {
                    OrderId = newOrder.Id,
                    ProductId = item.ProductID,
                    Quantity = item.Quantity,
                    Price = item.Price
                };
                db.OrderItems.InsertOnSubmit(orderItem);
            }

            // Clear the cart
            db.OrderDetails.DeleteAllOnSubmit(cartItems);

            // Save everything
            db.SubmitChanges();

            // Return the new order's invoice number or ID
            return newOrder.Id;
        }
        public bool MarkOrderAsPaid(int orderId)
        {
            var order = db.Orders.FirstOrDefault(o => o.Id == orderId);
            if (order != null)
            {
                order.Paid = true;
                order.Status = "Paid";// Add a Paid column in Orders table
                order.InvoiceNumber = "INV-" + DateTime.Now.Ticks;
                db.SubmitChanges();
                return true;
            }
            return false;
        }
        public string GetInvoiceNumber(int orderId)
        {
            var order = db.Orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null) return null;

            // If InvoiceNumber is empty, generate it
            if (string.IsNullOrEmpty(order.InvoiceNumber))
            {
                order.InvoiceNumber = $"INV-{order.Id:00000}-{DateTime.Now:yyyyMMdd}";
                db.SubmitChanges();
            }

            return order.InvoiceNumber;
        }


        public List<CartItemDTO> GetOrderSummary(int orderId)
        {
            var items = (from oi in db.OrderItems
                         where oi.Id == orderId
                         select new CartItemDTO
                         {
                             ProductId = oi.ProductId,
                             ProductName = oi.Product.Name,
                             Quantity = oi.Quantity,
                             Price = oi.Price,
                             ItemTotal = oi.Quantity * oi.Price,
                             Image = oi.Product.Image
                         }).ToList();

            return items;
        }

        //Dashboard///
        private const decimal CostPerKWh = 0.185m; // Average US electricity cost per kWh in 2025 (change to fit SA)
        private const decimal HoursPerMonth = 24; // Approximate hours per month
        public DashboardStats GetDashboardStats(int userId)
        {
            var purchaseDetails = (from o in db.Orders
                                   join od in db.OrderItems on o.Id equals od.OrderId
                                   join p in db.Products on od.ProductId equals p.Id
                                   where o.UserId == userId && o.Status == "Paid"
                                   select new
                                   {
                                       od.Quantity,
                                       p.EnergySavedWatts,
                                       p.CarbonReductionKg
                                   }).ToList();

            decimal totalEnergySavedW = purchaseDetails.Sum(pd => pd.Quantity * pd.EnergySavedWatts);
            decimal totalMoneySavedMonthly = (totalEnergySavedW / 1000m) * 24 * CostPerKWh;
            decimal totalCo2ReducedAnnually = purchaseDetails.Sum(pd => pd.Quantity * pd.CarbonReductionKg);
            decimal yearlyProjection = totalMoneySavedMonthly * 12;

            return new DashboardStats
            {
                EnergySavedW = totalEnergySavedW,
                MoneySavedMonthly = totalMoneySavedMonthly,
                Co2ReducedKg = totalCo2ReducedAnnually,
                YearlyProjection = yearlyProjection
            };
        }

        public List<PurchaseDTO> GetRecentPurchases(int userId)
        {
            var recentPurchases = (from o in db.Orders
                                   join od in db.OrderItems on o.Id equals od.OrderId
                                   join p in db.Products on od.ProductId equals p.Id
                                   where o.UserId == userId && o.Status == "Paid"
                                   orderby o.OrderDate descending
                                   select new PurchaseDTO
                                   {
                                       ProductName = p.Name,
                                       PurchaseDate = o.OrderDate,
                                       Price = od.Price * od.Quantity,
                                       MonthlySavings = (od.Quantity * p.EnergySavedWatts / 1000m) * 24 * CostPerKWh
                                   }).Take(3).ToList();

            return recentPurchases;
        }
        public List<PurchaseDTO> GeAllPurchases(int userId)
        {
            var recentPurchases = (from o in db.Orders
                                   join od in db.OrderItems on o.Id equals od.OrderId
                                   join p in db.Products on od.ProductId equals p.Id
                                   where o.UserId == userId && o.Status == "Paid"
                                   orderby o.OrderDate descending
                                   select new PurchaseDTO
                                   {
                                       ProductName = p.Name,
                                       PurchaseDate = o.OrderDate,
                                       Price = od.Price * od.Quantity,
                                       MonthlySavings = (od.Quantity * p.EnergySavedWatts / 1000m) * HoursPerMonth * CostPerKWh
                                   }).ToList();

            return recentPurchases;
        }

        public List<InvoiceDTO> GetRecentInvoices(int userId)
        {
            var recentInvoices = (from o in db.Orders
                                  where o.UserId == userId && o.Status == "Paid"
                                  orderby o.OrderDate descending
                                  select new InvoiceDTO
                                  {
                                      OrderId = o.Id,
                                      IssuedDate = o.OrderDate,
                                      TotalAmount = o.TotalAmount,
                                      Status = o.Status
                                  }).Take(3).ToList();

            return recentInvoices;
        }

        public List<InvoiceDTO> GetAllInvoices(int userId)
        {
            var AllInvoices = (from o in db.Orders
                                  where o.UserId == userId && o.Status == "Paid"
                                  orderby o.OrderDate descending
                                  select new InvoiceDTO
                                  {
                                      OrderId = o.Id,
                                      IssuedDate = o.OrderDate,
                                      TotalAmount = o.TotalAmount,
                                      Status = o.Status
                                  }).ToList();

            return AllInvoices;
        }

        public SavingsTrendsDTO GetSavingsTrends(int userId)
        {
            DateTime startDate = new DateTime(2025, 9, 1);
            DateTime endDate = new DateTime(2025, 9, 30);

            var purchaseDetails = (from o in db.Orders
                                   join od in db.OrderItems on o.Id equals od.OrderId
                                   join p in db.Products on od.ProductId equals p.Id
                                   where o.UserId == userId && o.Status == "Paid"
                                   select new
                                   {
                                       o.OrderDate,
                                       Energy = od.Quantity * p.EnergySavedWatts,
                                       Co2 = od.Quantity * p.CarbonReductionKg
                                   }).ToList();

            var labels = new List<string>();
            var moneyData = new List<decimal>();
            var energyData = new List<decimal>();
            var co2Data = new List<decimal>();

            decimal cumEnergy = 0m;
            decimal cumCo2 = 0m;

            for (DateTime day = startDate; day <= endDate; day = day.AddDays(1))
            {
                var upToDay = purchaseDetails.Where(pd => pd.OrderDate.Date <= day);
                cumEnergy = upToDay.Sum(pd => pd.Energy);
                cumCo2 = upToDay.Sum(pd => pd.Co2);

                decimal cumMoneyDaily = (cumEnergy / 1000m) * 24 * CostPerKWh; // assuming you have HoursPerDay

                labels.Add(day.ToString("dd MMM")); // e.g., 01 Apr
                moneyData.Add(Math.Round(cumMoneyDaily, 0));
                energyData.Add(Math.Round(cumEnergy, 0));
                co2Data.Add(Math.Round(cumCo2, 1));
            }

            return new SavingsTrendsDTO
            {
                Labels = labels,
                Money = moneyData,
                Energy = energyData,
                Co2 = co2Data
            };
        }


        public int UpdateProduct(string name, string description, decimal price, char in_stock, decimal energy_saved_watts, decimal carbon_reductionKG, string image, int id)
        {
            var tempProduct = (from p in db.Products
                               where p.Id.Equals(id)
                               select p).FirstOrDefault();

            if (tempProduct != null)
            {
                tempProduct.Id = id;
                tempProduct.Name = name;
                tempProduct.Description = description;
                tempProduct.Price = price;
                tempProduct.InStock = in_stock;
                tempProduct.CarbonReductionKg = carbon_reductionKG;
                tempProduct.EnergySavedWatts = energy_saved_watts;
                tempProduct.Image = image;


                try
                {
                    db.SubmitChanges();
                    return 0;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    return -1;
                }
            }
            else
            {
                return 1;
            }
        }

        public int DeleteProduct(int id)
        {
            var productToDelete = db.Products.FirstOrDefault(p => p.Id == id);

            if (productToDelete != null)
            {
                try
                {
                    // 1. Delete related OrderDetails
                    var relatedOrderDetails = db.OrderDetails.Where(o => o.ProductID == id);
                    db.OrderDetails.DeleteAllOnSubmit(relatedOrderDetails);

                    // 2. Delete related CartItems
                    var relatedCartItems = db.OrderItems.Where(c => c.ProductId == id);
                    db.OrderItems.DeleteAllOnSubmit(relatedCartItems);

                    // 3. Delete the product itself
                    db.Products.DeleteOnSubmit(productToDelete);

                    // Commit all changes
                    db.SubmitChanges();

                    return 0; // success
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); // log the error
                    return -1; // internal error
                }
            }
            else
            {
                return 1; // product not found
            }
        }





    }
}
