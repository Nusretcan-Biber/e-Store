using Core.BaseDtos;
using Core.BaseEntities;
using Core.BaseServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BaseServices.Services
{
    public class BaseReadOnlyService<TEntity, TEntityDto> : IBaseReadOnlyService<TEntity, TEntityDto>
        where TEntity : BaseEntity
        where TEntityDto : BaseDto
    {
        public Task<TEntity> Get(Guid guid)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
