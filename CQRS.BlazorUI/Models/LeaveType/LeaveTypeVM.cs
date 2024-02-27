﻿using System.ComponentModel.DataAnnotations;

namespace CQRS.BlazorUI.Models.LeaveType
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Default Number Of Days")]
        public int DefaultDays { get; set; }
    }
}