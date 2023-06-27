using Microsoft.CodeAnalysis.Text;
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

        public CustomerVM AddNew(CustomerVM item)
        {
            var _customer = new Customer()
            {
                Name = item.Name,
                Surname = item.Surname,
                Email = item.Email,
                PhoneNumber = item.PhoneNumber,
                BirthDate = item.BirthDate,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
            _context.Customers.Add(_customer);
            _context.SaveChanges();
            return item;
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
