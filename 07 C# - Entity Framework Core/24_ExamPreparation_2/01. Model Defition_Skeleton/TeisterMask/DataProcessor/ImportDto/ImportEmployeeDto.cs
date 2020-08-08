﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeeDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(\d{3})-(\d{3})-(\d{4})$")]
        public string Phone { get; set; }
        
        public int[] Tasks { get; set; }
    }
}
