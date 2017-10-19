using System;
using HomeWork.Data.Data;
using HomeWork.Data.Model;

namespace HomeWork.Data
{
    internal class Program
    {
        private static void Main()
        {
            var user = new User { Id = 1, Name = "Name" };

            var phone = new Phone { Id = 1, PhoneCode = "123", Value = "123124" };

            var userRepository = GetRepository<User>();
            userRepository.Add(user);

            var contactRepository = GetRepository<Contact>();
            contactRepository.Add(phone);

            Console.WriteLine(contactRepository.GetById(1));

            Console.ReadKey();
        }

        private static IRepository<TEntity> GetRepository<TEntity>() where TEntity : IEntity
        {
            return new EntityRepository<TEntity>();
        }
    }
}
