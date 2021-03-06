﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TaskHistoric
    {
        public int ID { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
        public int TaskID { get; set; }

        public Tasks Tasks { get; set; }
    }
}
