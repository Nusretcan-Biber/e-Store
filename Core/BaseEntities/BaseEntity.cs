using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BaseEntities
{
    public class BaseEntity : IBaseEntity, IBaseDateOperationEntity, IBaseControlOperationEntity
    {

        public BaseEntity()
        {
            Guid = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            IsUpdated = false;
            IsDeleted = false;
        }


        public Guid Guid { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
