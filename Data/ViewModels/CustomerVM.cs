using ticket_project_back.Data.Models;

namespace ticket_project_back.Data.ViewModels
{
    public class CustomerVM
    {
        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public DateTime? BirthDate { get; set; }

        public static explicit operator CustomerVM(Customer? v)
        {
            CustomerVM? c = (v == null) ? null : new CustomerVM()
            {
                Name = v.Name,
                Surname = v.Surname,
                Email = v.Email,
                PhoneNumber = v.PhoneNumber,
                BirthDate = v.BirthDate
            };
            return c;
        }
    }
}
