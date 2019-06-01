using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class HistoricTaskModel
    {
        public string Action { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
