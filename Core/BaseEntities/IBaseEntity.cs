﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BaseEntities
{
    public interface IBaseEntity
    {
        public Guid Guid { get; set; }
    }
}
