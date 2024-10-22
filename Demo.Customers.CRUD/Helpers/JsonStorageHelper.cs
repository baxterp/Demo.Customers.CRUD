using System.Text.Json;
using Demo.Customers.CRUD.Models;

namespace Demo.Customers.CRUD.Helpers
{
    public static class JsonStorageHelper
    {
        public static IEnumerable<Customer> ReadCustomerData()
        {
            if(!File.Exists("Customers.json"))
            {
                var customers = new List<Customer>();
                customers.Add(new Customer { Id = 1, Name = "Joe Bloggs Heating", Address = "2 Bakewell Close, Coventry", Email = "a@a.com" });
                customers.Add(new Customer { Id = 2, Name = "Will Smith Industries", Address = "5 The Road, London", Email = "b@b.com" });
                customers.Add(new Customer { Id = 3, Name = "Jane Jones Cars", Address = "5 The Street, Manchester", Email = "c@c.com" });
                customers.Add(new Customer { Id = 4, Name = "Jack Smith Limited", Address = "8 Chime Street, Birmigham", Email = "d@d.com" });

                var result = SaveCustomerData(customers);

                return customers;
            }
            else
            {
                var customers = LoadCustomerData();
                return customers;
            }
        }

        public static bool AddCustomerData(Customer customer)
        {
            try
            {
                var customers = LoadCustomerData();
                customers.Add(customer);
                var result = SaveCustomerData(customers);

                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UpdateCustomerData(Customer customer)
        {
            try
            {
                var customers = LoadCustomerData();
                var oldCustomerData = customers.Where(w => w.Id == customer.Id).FirstOrDefault();

                var newCustomerData = new Customer();
                newCustomerData.Id = customer.Id;
                newCustomerData.Name = customer.Name;
                newCustomerData.Address = customer.Address;
                newCustomerData.Email = customer.Email;

                customers.Remove(oldCustomerData);
                customers.Add(newCustomerData);

                var result = SaveCustomerData(customers);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool DeleteCustomerData(int customerId)
        {
            try
            {
                var customers = LoadCustomerData();
                var customerData = customers.Where(w => w.Id == customerId).FirstOrDefault();
                customers.Remove(customerData);

                var result = SaveCustomerData(customers);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static List<Customer> LoadCustomerData()
        {
            var jsonString = File.ReadAllText("Customers.json");
            var customers = JsonSerializer.Deserialize<List<Customer>>(jsonString);

            return customers;
        }

        private static bool SaveCustomerData(List<Customer> customers)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize<List<Customer>>(customers);
                string fileName = "Customers.json";
                File.WriteAllText(fileName, jsonString);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
