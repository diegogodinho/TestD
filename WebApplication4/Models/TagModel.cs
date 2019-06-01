using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class TagModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public bool Checked { get; set; }
        public DateTime LastChange { get; set; }        
    }
}