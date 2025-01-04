using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using AutoMapper;
using LeaveManagementSystem.Web.Services;

namespace LeaveManagementSystem.Web.Controllers
{
    public class LeaveTypesController(ILeaveTypesService _leaveTypesService) : Controller
    {
        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            // var data = await _context.LeaveTypes.ToListAsync();

            // //Without AutoMapper:
            // //var viewData = data.Select(q => new IndexVM
            // //{
            // //    Id = q.Id,
            // //    Name = q.Name,
            // //    NumberOfDays = q.NumberOfDays
            // //});

            // //Using AutoMapper
            //var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);


            //using service layer
            var viewData = await _leaveTypesService.GetAllLeaveTypesAsync();
            
            //return model to view
            return View(viewData);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _leaveTypesService.Get<LeaveTypeReadOnlyVM>(id.Value);
            
            
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeCreateVM leaveTypeCreate)
        {
            //custom errors:
            //if (leaveTypeCreate.Name.Contains("vacation"))
            //{
            //    ModelState.AddModelError(nameof(leaveTypeCreate.Name), "Name should not contain 'vacation'");
            //}

           if ( await _leaveTypesService.CheckIfLeaveTypeNameExists(leaveTypeCreate.Name))
            {
                ModelState.AddModelError(nameof(leaveTypeCreate.Name), "Leave Type already exists.");
            }

            if (ModelState.IsValid)
            {
                await _leaveTypesService.Create(leaveTypeCreate);
                //var leaveType = _mapper.Map<LeaveType>(leaveTypeCreate);
                //_context.Add(leaveType);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeCreate);
        }

       

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _leaveTypesService.Get<LeaveTypeEditVM>(id.Value);
            
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeEditVM leaveTypeEdit)
        {
            if (id != leaveTypeEdit.Id)
            {
                return NotFound();
            }

            if (await _leaveTypesService.CheckIfLeaveTypeNameExists(leaveTypeEdit.Name))
            {
                ModelState.AddModelError(nameof(leaveTypeEdit.Name), "Leave Type already exists.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await _leaveTypesService.Edit(leaveTypeEdit);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_leaveTypesService.LeaveTypeExists(leaveTypeEdit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeEdit);
        }

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _leaveTypesService.Get<LeaveTypeReadOnlyVM>(id.Value);
            
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _leaveTypesService.Remove(id);
          
            return RedirectToAction(nameof(Index));
        }

    }
}
