using LeaveManagementSystem.Web.Services.LeaveAllocations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Web.Controllers
{
    [Authorize]
    public class LeaveAllocationController(ILeaveAllocationsService _leaveAllocationsService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            
            var employeeVm = await _leaveAllocationsService.GetEmployeeAllocation();
            return View(employeeVm);
        }
    }
}
