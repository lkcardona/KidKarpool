using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KidKarpool.Data;
using KidKarpool.Models;

namespace KidKarpool.Controllers
{
    public class RequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequestsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: AcceptRequest - Check to see if this works as a view for accept request /added 3/12
        //public async Task<IActionResult> AcceptRequest()
        //{
        //    return View(await _context.Requests.ToListAsync());
        //}
        // GET: Accept Request - to populate that view
        public async Task<IActionResult> AcceptRequest(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            ViewData["id"] = id;
            return View(request);
        }
        //POST: Requests/AcceptRequest -Trial to see if this retains data-"edit" code model /added 3/12
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AcceptRequest(int id, [Bind("RequestID,StudentName,StudentClass,TimeOfPickUp,IdentifyLot,ParentName,PhoneNumber,ParentAcceptingName,DriverPhoneNumber,CarMakeModel,")]Request request)
        {
            if (id != request.RequestID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(request);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.RequestID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //This is a redirect to the details action under the request controller and then takes it to the details view
                return RedirectToAction("details", "Requests", new { id = id });

            }
            return View(Request);

        }
        // public ActionResult SaveInput()

        // {

        // }

        //GET: Request/Accept Request (Parent Accepts Request)
        //This is experimental code 3/13
        //  public IActionResult CreateParentAccept()
        // {
        //     //creates list of Parents accepting requests to/from the database???
        //  var ParentAcceptingName = _context
        //    .Accept
        //  .Select(x => new SelectListItem(x.ParentAcceptingName, x.AcceptID.ToString()))
        // .ToList();
        //ViewBag.Accept = ParentAcceptingName;
        //return View();
        //}
        //POST: Request/Accept Request
        //I think this is the correct post format, it's from an edit code format but I don't have dropdowns and need the info to bind
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateParentAccept(int id, [Bind("AcceptID, StudentName, ParentAcceptingName, CarMakeModel, PhoneNumber")]Accept accept)
        //{
        //    if (id != accept.AcceptID)
        //    {
        //        return NotFound();
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(accept);
        //            await _context.SaveChangesAsync();
        //        }
        //catch (DbUpdateConcurrencyException)
        //{
        // if (!CreateParentAccept(accept.AcceptID))
        // {
        //   return NotFound();
        //}
        //finally
        //{


        //  throw;
        //    }

        //} 
        //I feel this is wrong...I need it to redirect a view of Request Details
        //        return View(accept);

        //    }
        //    return View(accept);
        //}




        // GET: Requests
        public async Task<IActionResult> Index()
        {
            return View(await _context.Requests.ToListAsync());
        }

        // GET: Requests/Details/5
        public async Task<IActionResult> Details(int id, bool shouldSend)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (request == null)
            {
                return NotFound();
            }
            request.ShouldSend = shouldSend;
            return View(request);
        }

        ////POST: Details -Copied from AcceptRequest to post Start/End Ride to Database
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Details(int id, [Bind("RequestID,StudentName,StudentClass,TimeOfPickUp,IdentifyLot,ParentName,PhoneNumber,ParentAcceptingName,DriverPhoneNumber,CarMakeModel,")]Request request)
        //{
        //    if (id != request.RequestID)
        //    {
        //        return NotFound();
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(request);
        //            await _context.SaveChangesAsync();

        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!RequestExists(request.RequestID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        //This is a redirect to the details action under the request controller and then takes it to the details view
        //        return RedirectToAction("details", "Requests", new { id = id });

        //    }
        //    return View(Request);
        //}
        // GET: Requests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentName,StudentClass,TimeOfPickUp,IdentifyLot,ParentName,PhoneNumber")] Request request)
        {
            //creates list of lots from the database but doesn't hold data
            //   var Lot = _context.Lot.Select(x => new SelectListItem(x.))
            if (ModelState.IsValid)
            {
                _context.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(request);
            }
        }

        // GET: Requests/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestID,StudentName,StudentClass,TimeOfPickUp,IdentifyLot,ParentName,PhoneNumber,DriverPhonenumber,CarMakeModel,ParentAcceptingName")] Request request)
        {
            if (id != request.RequestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.RequestID))
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
            return View(request);
        }

        // GET: Requests/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var request = await _context.Requests.FindAsync(id);
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.RequestID == id);
        }

        //POST: Details - Start Ride upon click input will be sent to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StartTime(int id, [Bind("RequestID,StudentName,StudentClass,TimeOfPickUp,IdentifyLot,ParentName,PhoneNumber,ParentAcceptingName,DriverPhoneNumber,CarMakeModel,RideStarTime")]Request request)
        {
           
           // if (id != request.RequestID)
            //{
            //    return NotFound();
            //}
            if (ModelState.IsValid)
            {
                try
                {
                    request.RideStartTime = DateTime.Now;
                    _context.Update(request);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.RequestID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //This is a redirect to the details action under the request controller and then takes it to the details view
                return RedirectToAction("details", "Requests", new { id = id, shouldSend = true });

            }
            return View(request);
        }
        //POST: Details - Start Ride upon click input will be sent to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EndTime(int id, [Bind("RequestID,RideStartTime,RideEndTime,StudentName,StudentClass,TimeOfPickUp,IdentifyLot,ParentName,PhoneNumber,ParentAcceptingName,DriverPhoneNumber,CarMakeModel,")]Request request)
        {
            if (id != request.RequestID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    request.RideEndTime = DateTime.Now;
                    _context.Update(request);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.RequestID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //This is a redirect to the details action under the request controller and then takes it to the details view
                return RedirectToAction("details", "Requests", new { id = id });

            }
            return View(Request);
        }
    }
}
