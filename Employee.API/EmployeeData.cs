using Employee.API.Models;

namespace Employee.API
{
    public class EmployeeData
    {
        public List<EmployeeViewModel> employeesList { get; set; }

        public EmployeeData()
        {
            employeesList = new List<EmployeeViewModel>()
            {
                new EmployeeViewModel()
                {
                    Id = 1,
                    FirstName = "Manasa",
                    LastName = "Bhogiraju",
                    MobileNumber = "9876543212",
                    Email = "manasa@gmail.com",
                    AddressLine1 = "Hno-12/3 Flat No-34",
                    AddressLine2 = "Anjana Homes",
                    City = "Hyderabad",
                    PostalCode = "500070",
                    Country = "India"
                },
                new EmployeeViewModel()
                {
                    Id = 2,
                    FirstName = "Sneha",
                    LastName = "Kadari",
                    MobileNumber = "7989965432",
                    Email = "sneha@gmail.com",
                    AddressLine1 = "Hno-31/44 Flat No-20",
                    AddressLine2 = "Bhanupriya Homes",
                    City = "Banglore",
                    PostalCode = "400908",
                    Country = "India"
                },
                new EmployeeViewModel()
                {
                    Id = 3,
                    FirstName = "Rishi",
                    LastName = "Gowda",
                    MobileNumber = "9876865443",
                    Email = "rishi@gmail.com",
                    AddressLine1 = "Hno-3/99 Flat No-30",
                    AddressLine2 = "Manju Homes",
                    City = "Chennai",
                    PostalCode = "500943",
                    Country = "India"
                },
                new EmployeeViewModel()
                {
                    Id = 4,
                    FirstName = "Jhanu",
                    LastName = "Thota",
                    MobileNumber = "9876865356",
                    Email = "jhanu@gmail.com",
                    AddressLine1 = "Hno-7/99 Flat No-21",
                    AddressLine2 = "Malthu Homes",
                    City = "Delhi",
                    PostalCode = "700989",
                    Country = "India"
                }

            };
        }

        //internal Task SaveChanges()
        //{
        //    throw new NotImplementedException();
        //}
    }
}



