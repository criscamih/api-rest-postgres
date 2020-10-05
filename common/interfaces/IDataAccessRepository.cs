using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_stock.common.interfaces
{
    public abstract class IDataAccessRepository<TEntity>{
        public abstract Task<TEntity> GetOne(int id);
        public abstract Task<IEnumerable<TEntity>> GetAll();

        public abstract Task Update(TEntity TEntity);
        public abstract Task Add(TEntity TEntity);
        public abstract Task Delete(int id);
    }
}