﻿using Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BaseDtos
{
    public class IBaseDto : IBaseEntity
    {
        public Guid Guid { get; set; }
    }
}
