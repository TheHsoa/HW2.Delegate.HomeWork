using System;
using System.Collections.Generic;
using System.Linq;
using HomeWork.Data.Data;
using HomeWork.Data.Model;

namespace HomeWork.Data.Extensions
{
    public static class RepositoryExtensions
    {
        public static IEnumerable<TEntity> GetBy<TEntity>(this IRepository<TEntity> repository, Func<TEntity, bool> predicate) where TEntity : IEntity
        {
            return repository.GetAll().Where(predicate).ToArray();
        }
    }
}
