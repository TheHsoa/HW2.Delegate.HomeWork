using System;
using System.Linq;
using HomeWork.Data.Data;
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

            _userRepository.Add(new User { Id = 1, Name = "User" });
            _contactRepsoitory.Add(new Phone { Id = 1, UserId = 1, OrderNumber = 1, Value = "123" });
            _contactRepsoitory.Add(new Phone { Id = 2, UserId = 1, OrderNumber = 0, Value = "321" });
            _orderRepository.Add(new Order { Id = 1, UserId = 1, OrderNumber = 5, Price = 10, Quantity = 1 });
            _orderRepository.Add(new Order { Id = 2, UserId = 1, OrderNumber = 4, Price = 4, Quantity = 7 });
        }

        public UserModel GetUser(long id)
        {
            var user = _userRepository.GetById(id);

            var contacts = GetEntitiesFromRepository<IRepository<Contact>, Contact>(_contactRepsoitory, x => x.UserId == id);

            var orders = GetEntitiesFromRepository<IRepository<Order>, Order>(_orderRepository, x => x.UserId == id); ;

            var result = new UserModel
                             {
                                 Name = user.Name,
                                 Contacts = GetModel(contacts, x => new ContactModel(x)),
                                 Orders = GetModel(orders, x => new OrderModel(x))
                             };

            return result;
        }

        private static TModel[] GetModel<TModel, TEntity>(TEntity[] entities, Func<TEntity, TModel> convert)
            where TModel : IModel
            where TEntity : IOrdered
        {
            return entities.OrderBy(o => o.OrderNumber).Select(convert).ToArray();
        }

        private static TEntity[] GetEntitiesFromRepository<TRepository, TEntity>(TRepository repository, Func<TEntity, bool> condition)
            where TRepository : IRepository<TEntity>
            where TEntity : IEntity
        {
            return repository.GetAll().Where(condition).ToArray();
        }
    }
}
