using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentStaffApp.Models;

namespace StudentStaffApp.Controllers
{
    public class StaffDetailsController : Controller
    {
        private Training_20Feb_MumbaiEntities db = new Training_20Feb_MumbaiEntities();

        // GET: StaffDetails
        public ActionResult Index()
        {
            int staffcount = db.StaffDetails.Count();
            ViewBag.StaffCount = staffcount;
            return View();
        }

        public ActionResult StaffDetails()
        {
            var staff = db.StaffDetails.ToList();
            return View(staff);
        }

        [HttpPost]
        public ActionResult StaffDetails(int? staffid)
        {
            var staff = db.StaffDetails.Where(a=>a.StaffId == staffid).ToList();
            return View(staff);
        }

        // GET: StaffDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffDetail staffDetail = db.StaffDetails.Find(id);
            if (staffDetail == null)
            {
                return HttpNotFound();
            }
            return View(staffDetail);
        }

        // GET: StaffDetails/Create
        public ActionResult AddStaff()
        {
            return View();
        }

        // POST: StaffDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStaff([Bind(Include = "StaffId,Name,Gender,City,Experience,PhoneNumber,Salary,subject")] StaffDetail staffDetail)
        {
            if (ModelState.IsValid)
            {
                db.StaffDetails.Add(staffDetail);
                db.SaveChanges();
                return Content("<html><head><script>alert('Successfully Registered'); window.location.href = '/StaffDetails/AddStaff'</script></head></html>");
            }
            return View(staffDetail);
        }

        // GET: StaffDetails/Edit/5
        public ActionResult Edit(int? staffid)
        {
            if (staffid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffDetail staffDetail = db.StaffDetails.Find(staffid);
            if (staffDetail == null)
            {
                return HttpNotFound();
            }
            return View(staffDetail);
        }

        // POST: StaffDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StaffId,Name,Gender,City,Experience,PhoneNumber,Salary,subject")] StaffDetail staffDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staffDetail).State = EntityState.Modified;
                db.SaveChanges();
                return Content("<html><head><script>alert('Successfully Updated'); window.location.href = '/StaffDetails/Index'</script></head></html>");
            }
            return View(staffDetail);
        }

        // GET: StaffDetails/Delete/5
        public ActionResult Delete(int? staffid)
        {
            if (staffid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffDetail staffDetail = db.StaffDetails.Find(staffid);
            if (staffDetail == null)
            {
                return HttpNotFound();
            }
            return View(staffDetail);
        }

        // POST: StaffDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StaffDetail staffDetail = db.StaffDetails.Find(id);
            db.StaffDetails.Remove(staffDetail);
            db.SaveChanges();
            return Content("<html><head><script>alert('Successfully Deleted'); window.location.href = '/StaffDetails/StaffDetails'</script></head></html>");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
