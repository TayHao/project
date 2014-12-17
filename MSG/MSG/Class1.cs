using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSG
{
    [Serializable]
    public enum STATUS { LOGIN, GET_TABLE, ADD_STUDENT, ADD_ADMIN, ADD_INSTRUCTOR }
    [Serializable]
    public class MSG
    {
        public STATUS stat;
    }
}
