using Case1.Core.Entities.Abstract;
using System.Linq.Expressions;

namespace Case1.Data.Respository
{
    public interface IEntityRespository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);


    }
}
