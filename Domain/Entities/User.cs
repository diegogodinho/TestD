using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
