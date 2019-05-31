using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModels
{
    public class RequestGrid
    {
        public int draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public int Total { get; set; }
        public int Currentpage { get; set; }
    }
}
