﻿using LeaveManagementSystem.Web.Models.LeaveTypes;
using LeaveManagementSystem.Web.Models.Periods;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveAllocations
{
    public class LeaveAllocationVM
    {
        public int Id { get; set; }

        [Display(Name = "Number of Days")]
        public int NumberOfDays { get; set; }

        [Display(Name = "Allocation Period")]
        public PeriodVM Period { get; set; }

        public LeaveTypeReadOnlyVM? LeaveType { get; set; }
    }
}
