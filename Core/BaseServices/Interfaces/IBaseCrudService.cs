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

        public Task<int> InsertAsync(TEntity createInput);
        public Task<int> UpdateAsync(TEntity tEntity);
        public Task<int> DeleteAsync(Guid guid);
    }
}
