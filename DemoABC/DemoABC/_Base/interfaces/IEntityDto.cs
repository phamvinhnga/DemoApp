using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoABC.Base.interfaces
{
    public interface IEntityDto<TPrimaryKey> where TPrimaryKey : struct
    {
        public TPrimaryKey Id { get; set; }
    }
}
