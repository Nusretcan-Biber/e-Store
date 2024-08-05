using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BaseEntities
{
    public interface IBaseControlOperationEntity
    {
        public bool IsUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
