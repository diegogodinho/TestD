using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Tasks
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Checked { get; set; }
        public DateTime LastChange { get; set; }
        public int UserID { get; set; }

        public virtual User User { get; set; }

        public ICollection<TaskHistoric> Historics { get; set; }
    }
}
