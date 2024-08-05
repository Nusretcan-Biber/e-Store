using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainShared
{

    [Flags]

    /// <summary>
    /// Sistemi kullanacak kullanıcıların yetkisini belirleyecek enum
    /// Flag etiketi sayesinde bir kullanıcının birden fazla rolü olabilmekte
    /// </summary>
    public enum UserRoleType : int
    {
        GUEST,
        CUSTOMER,
        SELLER,
        ADMİN,
        OWNER

    }
}
