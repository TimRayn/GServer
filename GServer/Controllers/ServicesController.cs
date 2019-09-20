using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private BaseContext db;

        public ServicesController()
        {

        }
    }
}