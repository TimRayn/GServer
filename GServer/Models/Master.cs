using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GServer.Models
{
    public class Master
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }

    }

    public class MasterArrModified
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Description { get; set; }
        public string Photo { get; set; }
    }
}
