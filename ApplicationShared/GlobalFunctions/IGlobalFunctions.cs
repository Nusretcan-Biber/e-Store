using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationShared.GlobalFunctions
{
    public interface IGlobalFunctions
    {
        public string CalculateMD5(string inputString);
    }
}
