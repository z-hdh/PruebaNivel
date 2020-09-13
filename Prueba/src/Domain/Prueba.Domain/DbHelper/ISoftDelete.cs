using System;
using System.Collections.Generic;
using System.Text;

namespace Prueba.Domain.DbHelper
{
    public interface ISoftDelete
    {
        bool Delete { get; set; }
    }
}
