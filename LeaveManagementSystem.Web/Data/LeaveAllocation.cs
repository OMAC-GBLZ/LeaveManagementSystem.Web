namespace LeaveManagementSystem.Web.Data
{
    public class LeaveAllocation : BaseEntity
    {
        public LeaveType? LeaveType { get; set; } //make this nullable for an optional relationship
        public int LeaveTypeId { get; set; } //Calling this LeaveTypeId allows EF Core to automatically recognize it as a foreign key for the id column inside the LeaveType Property
        public ApplicationUser Employee { get; set; }
        public string EmployeeId { get; set; } //FK for above
        public Period Period { get; set; }
        public int PeriodId { get; set; }
        public int Days { get; set; }
    }
}
