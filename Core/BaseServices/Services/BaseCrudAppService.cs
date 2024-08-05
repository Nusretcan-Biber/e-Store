using Core.BaseDtos;
using Core.BaseEntities;
using Core.BaseServices.Interfaces;
using Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BaseServices.Services
{
    public class BaseCrudAppService<TDbContext, TEntity, TEntityDto, TCreateInput, TUpdateInput> :
        IBaseCrudService<TEntity, TEntityDto, TCreateInput, TUpdateInput>,
        IBaseReadOnlyService<TEntity, TEntityDto>
        where TDbContext : DbContext
        where TEntity : BaseEntity
        where TEntityDto : BaseDto
        where TCreateInput : class
        where TUpdateInput : class

    {
        public Task<bool> DeleteAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Get(Guid guid)
        {
            using (var uow = new UnitOfWork<TDbContext>())
            {
                var isExist = uow.GetRepository<TEntity>().Get(x => x.Guid == guid);
                if (isExist == null)
                    return Task.FromResult<TEntity>(isExist) ;
                return Task.FromResult(isExist);
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            using (var uow = new UnitOfWork<TDbContext>())
            {
                return uow.GetRepository<TEntity>().GetAll();
            }
        }

        public Task<TEntity> InsertAsync(TCreateInput createInput)
        {
            using (var uow = new UnitOfWork<TDbContext>())
            {
                throw new NotImplementedException();
            }
        }

        public Task<TEntity> UpdateAsync(Guid guid, TUpdateInput updateInput)
        {
            throw new NotImplementedException();
        }
    }
}
