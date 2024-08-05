using Core.BaseDtos;
using Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BaseServices.Interfaces
{
    public interface IBaseCrudAppService<TEntity, TEntityDto, TCreateInput, TUpdateInput> :
        IBaseCrudService<TEntity, TEntityDto, TCreateInput, TUpdateInput>,
        IBaseReadOnlyService<TEntity, TEntityDto>
        where TEntity : BaseEntity
        where TEntityDto : BaseDto
        where TCreateInput : class
        where TUpdateInput : class

    {
    }
}
