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
    public class BaseCrudService<TEntity, TEntityDto, TCreateInput, TUpdateInput> : IBaseCrudService<TEntity, TEntityDto, TCreateInput, TUpdateInput>
        where TEntity : BaseEntity
        where TEntityDto : BaseDto
        where TCreateInput : class
        where TUpdateInput : class
    {
        public Task<bool> DeleteAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> InsertAsync(TCreateInput createInput)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(Guid guid, TUpdateInput updateInput)
        {
            throw new NotImplementedException();
        }
    }
}
