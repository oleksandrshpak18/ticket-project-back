using Microsoft.CodeAnalysis.Text;
using System.Text.RegularExpressions;
using ticket_project_back.Data.Interfaces;
using ticket_project_back.Data.Models;
using ticket_project_back.Data.ViewModels;

namespace ticket_project_back.Data.Services
{
    public class CustomerService : ICreate<CustomerVM>
    {
        private TicketDbContext _context;
        public CustomerService(TicketDbContext context)
        {
            _context = context;
        }

        private bool isValid(CustomerVM customer)
        {
            bool res = true;
            res &= customer != null;
            res &= customer.Name != null && customer.Name.Length > 0 && customer.Name.Length <= 50 && Regex.IsMatch(customer.Name, @"^[^0-9]*$");
            res &= customer.Surname != null && customer.Surname.Length > 0 && customer.Surname.Length <= 50 && Regex.IsMatch(customer.Surname, @"^[^0-9]*$");
            res &= customer.PhoneNumber != null && customer.PhoneNumber.Length == 12 && Regex.IsMatch(customer.PhoneNumber, @"^[0-9]{12}$");
            res &= customer.Email != null && customer.Email.Length > 0 && customer.Email.Length <= 320 && Regex.IsMatch(customer.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return res;
        }

        public CustomerVM AddNew(CustomerVM item)
        {
            if(isValid(item))
            {
                var _customer = new Customer()
                {
                    Name = item.Name.Trim(),
                    Surname = item.Surname.Trim(),
                    Email = item.Email.Trim(),
                    PhoneNumber = item.PhoneNumber.Trim(),
                    BirthDate = item.BirthDate,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                };
                _context.Customers.Add(_customer);
                _context.SaveChanges();
                return item;
            }else
            {
                return null;
            }
            
        }

        public CustomerVM getByPhone(string phoneNumber)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.PhoneNumber == phoneNumber);
            return (CustomerVM)customer;    
        }

        public bool isPresent(CustomerVM customer)
        {
            return _context.Customers
                .Any(x => x.PhoneNumber == customer.PhoneNumber && x.Email == customer.Email);
        }
    }
}
