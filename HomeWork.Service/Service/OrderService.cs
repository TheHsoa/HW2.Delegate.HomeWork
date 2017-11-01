using System.Linq;
using HomeWork.Data.Data;
using HomeWork.Data.Extensions;
using HomeWork.Data.Model;
using HomeWork.UI.Model;

namespace HomeWork.UI.Service
{
    internal class OrderService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Contact> _contactRepsoitory;
        private readonly IRepository<Order> _orderRepository;

        public OrderService()
        {
            _userRepository = new EntityRepository<User>();
            _contactRepsoitory = new EntityRepository<Contact>();
            _orderRepository = new EntityRepository<Order>();

            _userRepository.Add(new User {Id = 1, Name = "User"});
            _contactRepsoitory.Add(new Phone {Id = 1, UserId = 1, OrderNumber = 1, Value = "123"});
            _contactRepsoitory.Add(new Phone {Id = 2, UserId = 1, OrderNumber = 0, Value = "321"});
            _orderRepository.Add(new Order {Id = 1, UserId = 1, OrderNumber = 5, Price = 10, Quantity = 1});
            _orderRepository.Add(new Order {Id = 2, UserId = 1, OrderNumber = 4, Price = 4, Quantity = 7});
        }

        public UserModel GetUser(long id)
        {
            var user = _userRepository.GetById(id);

            var contacts = _contactRepsoitory.GetBy(x => x.UserId == id);

            var orders = _orderRepository.GetBy(x => x.UserId == id);
            
            var result = new UserModel
            {
                Name = user.Name,
                Contacts = contacts.Select(x => new ContactModel(x)).ToArray(),
                Orders = orders.Select(x => new OrderModel(x)).ToArray()
            };

            return result;
        }
    }
}
