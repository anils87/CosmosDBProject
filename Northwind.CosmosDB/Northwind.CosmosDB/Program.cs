
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Northwind.CosmosDB.Data;
using Northwind.CosmosDB.Models;

using (NorthwindContext context = new NorthwindContext())
{
    #region Insert Employee
    /*
    Employee employee1 = new Employee()
    {
        Id = Guid.NewGuid().ToString(),
        FirstName = "Anil",
        LastName = "Yadav",
        Title = "Software Professional",
        BirthDate = new DateTime(1987, 07, 15),
        HireDate = new DateTime(2022, 01, 20),
        Address = "N/304,durvas chsl,yashwant viva township",
        City = "Mumbai",
        PostalCode = "400101",
        Country = "India",
        HomePhone = "1234567890"
    };
    Employee employee2 = new Employee()
    {
        Id = Guid.NewGuid().ToString(),
        FirstName = "Sarita",
        LastName = "Yadav",
        Title = "House wife",
        BirthDate = new DateTime(1987, 07, 15),
        HireDate = new DateTime(2022, 01, 20),
        Address = "N/304,durvas chsl,yashwant viva township",
        City = "Mumbai",
        PostalCode = "400101",
        Country = "India",
        HomePhone = "1234567898"
    };
    context.Employees?.Add(employee1);
    context.Employees?.Add(employee2);
    await context.SaveChangesAsync();
    */
    #endregion

    #region Insert Customers
    /*
    Customer customer1 = new Customer()
    {
        Id = Guid.NewGuid().ToString(),
        CompanyName = "Customer 1",
        ContactName = "Anil Yadav",
        ContactTitle = "Mr.",
        Address = "Customer Address 1",
        City = "Mumbai",
        Country = "India",
        PostalCode = "400001",
        Phone = "022-12345432",
        Region = "West",
        Orders = new List<Order>()
        {
            new Order()
            {
                Id = Guid.NewGuid().ToString(),
                OderDate = new DateTime(2022, 12, 23),
                RequiredDate = new DateTime(2022, 12, 31),
                ShippedDate = new DateTime(2022, 12, 24),
                ShipVia = 3,
                Freight = 29.34,
                ShipName = "Ezzy Shipment",
                ShipAddress = "Order Street 123",
                ShipCity = "Delhi",
                ShipPostalCode = "011-12345543",
                ShipRegion = "North",
                ShipCountry = "India"
            },
            new Order()
            {
                Id = Guid.NewGuid().ToString(),
                OderDate = new DateTime(2022, 12, 31),
                RequiredDate = new DateTime(2023, 01, 05),
                ShippedDate = new DateTime(2023, 01, 02),
                ShipVia = 3,
                Freight = 29.34,
                ShipName = "Maruti Shipment",
                ShipAddress = "Dalal Street 123",
                ShipCity = "Mumbai",
                ShipPostalCode = "022-12345543",
                ShipRegion = "West",
                ShipCountry = "India"
            }
        }

    };
    context.Customers?.Add(customer1);
    await context.SaveChangesAsync();
    Console.WriteLine("Record inserted successfully!");
    */
    #endregion

    #region Get Employee List
    /*
    if (context.Employees != null)
    {
        var empList=await context.Employees.ToListAsync();
        foreach (var emp in empList)
        {
            Console.WriteLine("Employee Detail: "+JsonConvert.SerializeObject(emp));
        }
    }
    */
    #endregion

    #region Get An Employee
    if (context.Employees != null)
    {
        var empl = await context.Employees.Where(m => m.FirstName == "Anil").FirstOrDefaultAsync();
        Console.WriteLine("First Name:"+ empl?.FirstName);
        Console.WriteLine("Last Name:" + empl?.LastName);
        Console.WriteLine("Hire Date:" + empl?.HireDate);
        Console.WriteLine("==================");
    }
    #endregion

    #region Update An Employee
    if (context.Employees != null)
    {
        //var empl = await context.Employees.Where(m => m.FirstName == "Anil").FirstOrDefaultAsync();
        //if(empl != null)
        //{
        //    empl.LastName = "Yadav1";
        //}
        //await context.SaveChangesAsync();        
    }
    #endregion

    #region Delete An Employee
    if (context.Employees != null)
    {
        var empl = await context.Employees.Where(m => m.FirstName == "Anil").FirstOrDefaultAsync();
        if (empl != null)
        {
            context.Employees.Remove(empl);
            await context.SaveChangesAsync();
        }
        Console.WriteLine("Record Deleted Successfully!");
    }
    #endregion
}