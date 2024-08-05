using Core.BaseDtos;
using Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BaseServices.Interfaces
{
    public interface IBaseReadOnlyService<TEntity, TEntityDto>
        where TEntity : BaseEntity
        where TEntityDto : BaseDto
    {
        public IQueryable<TEntity> GetAll();
        public Task<TEntity> Get(Guid guid);
    }
}
