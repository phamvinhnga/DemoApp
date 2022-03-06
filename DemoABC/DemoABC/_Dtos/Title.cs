using DemoABC.Base.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoABC.Dtos
{
    public class TitleDto : EntityDto<Guid>
    {
        public string CodeValue { get; set; }

        public string Name { get; set; }
    }

    public class TitleInputDto : TitleDto
    {

    }

    public class TitleOutputDto : TitleDto
    {

    }
}
