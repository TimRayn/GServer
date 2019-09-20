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
    public class MastersController : ControllerBase
    {
        private BaseContext db;

        public MastersController(BaseContext context)
        {
            this.db = context;
            if (!db.Masters.Any())
            {
                db.Masters.Add(new Master {Description = "Ama masta.&Я анчоус.", Name = "Masat", Photo = "master_masat.jpg"});
                
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<MasterArrModified> GetMasters()
        {
            List<MasterArrModified> resultList = new List<MasterArrModified>();
            List<Master> mstList = db.Masters.ToList();
            foreach (var master in mstList)
            {
                resultList.Add(new MasterArrModified
                {
                    Id = master.Id,
                    Name = master.Name,
                    Photo = master.Photo,
                    Description = master.Description.Split('&')
                });
            }

            return resultList;
        }
    }
}