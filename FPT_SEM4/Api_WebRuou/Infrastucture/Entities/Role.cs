﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_WebRuou.Infrastucture.Entities
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
            
        public string? Description { get; set; }
    }
}
