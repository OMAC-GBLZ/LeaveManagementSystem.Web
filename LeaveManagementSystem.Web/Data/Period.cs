namespace LeaveManagementSystem.Web.Data
{
    public class Period : BaseEntity
    {
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }

    }
}
