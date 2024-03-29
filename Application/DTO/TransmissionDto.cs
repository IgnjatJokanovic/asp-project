﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class TransmissionDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Field Type is required")]
        public string Type { get; set; }
    }
}
