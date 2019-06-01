using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModels
{
    public class TagListViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Checked { get; set; }
        public DateTime LastChange { get; set; }

        public string LastChangeView
        {
            get
            {
                return LastChange.ToString("dd/MM/yyyy hh:mm:ss");
            }
        }
    }
}
