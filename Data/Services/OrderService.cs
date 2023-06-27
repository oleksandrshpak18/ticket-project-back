using ticket_project_back.Data.Models;
using ticket_project_back.Data.ViewModels;

namespace ticket_project_back.Data.Services
{
    public class OrderService
    {
        private TicketDbContext _context;
        private CustomerService _customerService;
        private TicketService _ticketService;
        public OrderService(TicketDbContext context, CustomerService customerService, TicketService ticketService)
        {
            _context = context;
            _customerService = customerService;
            _ticketService = ticketService;
        }

        public OrderVM AddNew(OrderVM order)
        {
            if (order.Customer == null) { throw new ArgumentNullException("The customer is null."); }
            if (order.Tickets == null || order.Tickets.Count() == 0) { throw new ArgumentException("There were no tickets provided."); }

            var customer = (_customerService.isPresent(order.Customer))
                            ? order.Customer
                            : _customerService.AddNew(order.Customer);

            var maxOperationNumber = _context.Orders.Any() ? _context.Orders.Max(x => x.OperationNumber) : 0;
            DateTime dateTime = DateTime.Now;
            var newOrder = new Order()
            {
                CreateDate = dateTime,
                CustomerId = _context.Customers
                    .FirstOrDefault(x => x.PhoneNumber == customer.PhoneNumber && x.Email == customer.Email)
                    ?.CustomerId,
                OperationDatetime = dateTime,
                OperationNumber = maxOperationNumber + 1,
                TotalPrice = order.Tickets.Sum(x => x.TicketPrice)
            };
            _context.Orders.Add(newOrder);
            

            foreach(var ticket in order.Tickets)
            {
                _ticketService.AddNew(ticket);
            }

            _context.SaveChanges();

            // Get the last recent order ID
            var lastRecentOrderId = _context.Orders
                .OrderByDescending(order => order.OrderId)
                .Select(order => order.OrderId)
                .FirstOrDefault();

            // Get the last 10 recent tickets
            var lastRecentTickets = _context.Tickets
                .OrderByDescending(ticket => ticket.TicketId)
                .Take(order.Tickets.Count())
                .ToList();

            foreach(var ticket in lastRecentTickets)
            {
                _context.OrderItems.Add(new OrderItem()
                {
                    OrderId = lastRecentOrderId,
                    TicketId = ticket.TicketId,
                    CreateDate = dateTime
                });
            }
            _context.SaveChanges();
            return order;
        }
    }
}
