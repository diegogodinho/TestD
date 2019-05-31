using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModels
{
    public class GridViewModel<T> where T : class
    {
        public int draw { get; set; }

        public int recordsTotal { get; set; }

        public int recordsFiltered { get; set; }

        public T[] data { get; set; }
    }
}
