using Core.BaseDtos;
using Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BaseServices.Interfaces
{
    public interface IBaseCrudService<TEntity, TEntityDto, TCreateInput, TUpdateInput>
        where TEntity : BaseEntity
        where TEntityDto : BaseDto
        where TCreateInput : class
        where TUpdateInput : class
    {

        public Task<TEntity> InsertAsync(TCreateInput createInput);
        public Task<TEntity> UpdateAsync(Guid guid, TUpdateInput updateInput);
        public Task<bool> DeleteAsync(Guid guid);
    }
}
