﻿using DemoABC.Base;
using DemoABC.Base.interfaces;
using DemoABC.Dtos;
using DemoABC.EntityFramework.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoABC.Business.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TitleController : BaseCrudAsyncController<Title, TitleInputDto, TitleOutputDto, Guid>
    {
        public TitleController(IRepository<Title, Guid> repository) : base(repository)
        {
        }
    }
}
