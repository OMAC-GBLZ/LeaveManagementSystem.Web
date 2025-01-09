
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services.LeaveAllocations
{
    public class LeaveAllocationsService(ApplicationDbContext _context, IHttpContextAccessor _httpContextAccessor, UserManager<ApplicationUser> _userManager) : ILeaveAllocationsService
    {
        public async Task AllocateLeave(string employeeId)
        {
            //get all the leave types
            var leaveTypes = await _context.LeaveTypes.ToListAsync();

            //get the current period based on year
            var currentDate = DateTime.Now;
            var period = await _context.Periods.SingleAsync(q => q.End.Year == currentDate.Year);
            var monthsRemaining = period.End.Month - currentDate.Month;

            //foreach leave type, create an allocation entry
            foreach (var leaveType in leaveTypes)
            {
                var accuralRate = decimal.Divide(leaveType.NumberOfDays, 12);
                var leaveAllocation = new LeaveAllocation
                {
                    EmployeeId = employeeId,
                    LeaveTypeId = leaveType.Id,
                    PeriodId = period.Id,
                    Days = (int)Math.Ceiling(accuralRate * monthsRemaining),
                };

                _context.Add(leaveAllocation);
            }

            await _context.SaveChangesAsync();
        }
    

        public async Task<List<LeaveAllocation>> GetAllocations()
        {
           
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
            var leaveAllocations = await _context.LeaveAllocations
                .Include(q => q.LeaveType) // Include simulates join statement in SQL
                .Include(q => q.Period)
                .Where(q => q.EmployeeId == user.Id)
                .ToListAsync();

            return leaveAllocations;
        }


    }
}
