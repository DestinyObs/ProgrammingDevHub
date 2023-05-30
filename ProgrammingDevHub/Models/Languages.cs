﻿using System.ComponentModel.DataAnnotations;

namespace ProgrammingDevHub.Models
{
    public class Languages
    {
        [Key]
        public int Id { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
    }
}
