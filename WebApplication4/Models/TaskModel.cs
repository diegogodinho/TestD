using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Checked { get; set; }
        public DateTime LastChange { get; set; }        
    }
}