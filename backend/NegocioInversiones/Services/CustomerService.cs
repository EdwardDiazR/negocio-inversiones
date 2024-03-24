using Microsoft.EntityFrameworkCore;
using NegocioInversiones.Data;
using NegocioInversiones.Interfaces;
using NegocioInversiones.Models.CustomerModels;
using System.Collections.Frozen;

namespace NegocioInversiones.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly SqlServerContext _context;
        //TODO: INJECT FRAUD SERVICE OR CONTROLLER TO CHECK IF CUSTOMER IS FRAUDSTER
        public CustomerService(SqlServerContext context)
        {
            _context = context;
        }

        public bool CheckIfCustomerExists(string CustomerId)
        {
            return _context.Customer.AsNoTracking()
                .Any(c => c.CivilId == CustomerId 
                );
        }


        //Method: search customer by it's civil ID
        public Customer GetCustomerByCivilId(string CustomerId, int? CustomerIdType)
        {
            Customer customer = _context.Customer.AsNoTracking()
                //.Select(c=>new Customer { CivilId = c.CivilId,
                //    CustomerCivilIdType=c.CustomerCivilIdType})
                .Where(customer => customer.CivilId == CustomerId && customer.CustomerCivilIdType == CustomerIdType || customer.CivilId == CustomerId).First();


            if (customer is null)
            {
                throw new Exception("Customer not found with this ID");
            }

            return customer;

        }

        //Method: Get Customer by CustomerId
        public Customer GetCustomerByCustomerId(int CustomerId)
        {
            var r = _context.Database.SqlQuery<Customer>($"SELECT * FROM dbo.personal_customer");

            Customer? customer = _context.Customer.AsNoTracking()
                .FirstOrDefault(customer => customer.Id == CustomerId);

            if (customer is null)
            {
                throw new Exception("No se encuentra cliente con ese ID");
            }
            return customer;

        }
        public Customer CreateCustomer(CreateCustomerDto customerDto)
        {
            bool IsFraudulentCustomer = false;
            int CustomerAge = CalculateAge(customerDto.CustomerDob);

            //Check if CustomerId is on fraudster customers

            if (IsFraudulentCustomer)
            {
                throw new Exception("Este cliente no puede ser creado porque presenta una alerta de fraude en el Modulo de fraudes");
            }

            if (CustomerAge < 18)
            {
                throw new Exception("Cliente es menor de edad");
            }

            //TODO: Check if Email already exists

            Customer customer = new Customer()
            {
                CivilId = customerDto.CustomerCivilId.Trim(),
                CustomerCivilIdType = customerDto.CustomerDocumentType,
                FirstName = customerDto.CustomerFirstName.Trim(),
                MiddleName = !string.IsNullOrEmpty(customerDto.CustomerMiddleName) ? customerDto.CustomerMiddleName?.Trim() : "",
                LastName = customerDto.CustomerLastName.Trim(),
                SecondLastName = !string.IsNullOrEmpty(customerDto.CustomerSecondLastName) ? customerDto.CustomerSecondLastName?.Trim() : "",
                Address = customerDto.CustomerAddress,
                City = customerDto.CustomerCity,
                Country = customerDto.CustomerCountry,
                CustomerDob = customerDto.CustomerDob,
                Email = customerDto.CustomerEmail.Trim(),
                PhoneNumber = customerDto.CustomerPhoneNumber,
                ResidentialPhoneNumber = !string.IsNullOrEmpty(customerDto.CustomerResidentialPhoneNumber) ? customerDto.CustomerResidentialPhoneNumber : "",
                CustomerProfileStatus = 1,
                CustomerAge = CustomerAge, //TODO: Calculate Age based on customer Dob 
                MonthlyIncome = customerDto.MonthlyIncome,
                WorkPlace = customerDto.CustomerWorkPlace.Trim(),
                IncomeVerified = false,
                WorkPlaceVerified = false,
                Gender = customerDto.CustomerGender,
                LastTimeProfileUpdated = DateTime.Now

            };

            _context.Customer.Add(customer);
            _context.SaveChanges();

            return customer;

        }

        static int CalculateAge(DateTime birthdate)
        {
            // Get the current date
            DateTime currentDate = DateTime.Now;

            // Calculate the age
            int age = currentDate.Year - birthdate.Year;

            // Check if the birthday has occurred this year
            if (birthdate.Date > currentDate.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        public void UpdateCustomerInformation(UpdateCustomerDto updateCustomerDto)
        {
            bool HasChanges = false;

            Customer customer = _context.Customer.Find(updateCustomerDto.CustomerId);


            if (customer == null)
            {
                throw new Exception("No se encuentra ningun cliente con este ID");
            }

            if (updateCustomerDto.CustomerFirstName != customer.FirstName)
            {
                HasChanges = true;
            }

            if (updateCustomerDto.CustomerMiddleName != customer.MiddleName)
            {
                HasChanges = true;
            }

            if (updateCustomerDto.CustomerLastName != customer.LastName)
            {
                HasChanges = true;
            }
            if (updateCustomerDto.CustomerSecondLastName != customer.SecondLastName)
            {
                HasChanges = true;
            }


            if (HasChanges)
            {
                customer.FirstName = updateCustomerDto.CustomerFirstName;
                customer.MiddleName = updateCustomerDto.CustomerMiddleName;
                customer.LastName = updateCustomerDto.CustomerLastName;
                customer.SecondLastName = updateCustomerDto.CustomerSecondLastName;

            }

            _context.Customer.Update(customer);

            //_context.SaveChanges();

        }
    }
}
