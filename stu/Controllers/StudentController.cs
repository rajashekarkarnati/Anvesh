using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentStaffApp.Models;
using StudentStaffApp.ViewModels;
using System.Data.Entity;

namespace StudentStaffApp.Controllers
{
    public class StudentController : Controller
    {

        private readonly Training_20Feb_MumbaiEntities db = new Training_20Feb_MumbaiEntities();

        // GET: Student
        public ActionResult Index()
        {
            int studentcount = db.StudentDetails.Count();
            ViewBag.StudentCount = studentcount;
            return View();
        }

        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(StudentDetail student)
        {
            if(ModelState.IsValid)
            {
                var msg = string.Format("Please enter a value between 01/01/1996 and 31/12/2000");
                DateTime dob = Convert.ToDateTime(student.DateofBirth);
                DateTime startdate = DateTime.ParseExact("01/01/1996", "dd/MM/yyyy", null);
                DateTime enddate = DateTime.ParseExact("31/12/2000", "dd/MM/yyyy", null);
                if ((dob.CompareTo(startdate) >= 0) && (dob.CompareTo(enddate) <= 1))
                {
                    db.StudentDetails.Add(student);
                    Fee fees = new Fee()
                    {
                        StudentId = student.StudentId,
                        Amount = student.feesAmount,
                        Balance = student.feesAmount,
                        Branch = student.Branch,
                        Year = student.year,
                        Paid = "NotPaid"
                    };
                    db.Fees.Add(fees);
                    db.SaveChanges();
                    return Content("<html><head><script>alert('Successfully Registered'); window.location.href = '/Student/AddStudent'</script></head></html>");
                }
                else
                {
                    ModelState.AddModelError("DateofBirth", msg); 
                }
            }
            return View();
        }

        public ActionResult StudentDetails()
        {
            var studentDetails = db.StudentDetails.ToList();
            return View(studentDetails);
        }

        [HttpPost]
        public ActionResult StudentDetails(int? studentid)
        {
            var student = db.StudentDetails.Where(a=>a.StudentId == studentid).ToList();
            return View(student);
        }

        public ActionResult DeleteStudentById(int? studentid)
        {
            var student = db.StudentDetails.Find(studentid);
            db.StudentDetails.Remove(student);
            db.SaveChanges();
            return Content("<html><head><script>alert('Successfully Deleted'); window.location.href = '/Student/StudentDetails'</script></head></html>");
        }

        public ActionResult GetStudentById(int? studentid)
        {
            var student = db.StudentDetails.Find(studentid);
            return View(student);
        }

        [HttpPost]
        public ActionResult GetStudentById(StudentDetail student)
        {
            var msg = string.Format("Please enter a value between 01/01/1996 and 31/12/2000");
            DateTime dob = Convert.ToDateTime(student.DateofBirth);
            DateTime startdate = DateTime.ParseExact("01/01/1996", "dd/MM/yyyy", null);
            DateTime enddate = DateTime.ParseExact("31/12/2000", "dd/MM/yyyy", null);
            if ((dob.CompareTo(startdate) >= 0) && (dob.CompareTo(enddate) <= 1))
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return Content("<html><head><script>alert('Successfully Updated'); window.location.href = '/Student/StudentDetails'</script></head></html>");
            }
            ModelState.AddModelError("DateofBirth", msg);
            return View(student);
        }

        [HttpPost]
        public ActionResult GetFeesByYear(string year, string branch)
        {
            var fees = db.FeeStructures.Where(a => a.Branch == branch && a.year == year).SingleOrDefault();
            return Json(new { fees = fees.Amount}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetFeesByBranch(string year, string branch)
        {
            var fees = db.FeeStructures.Where(a => a.Branch == branch && a.year == year).SingleOrDefault();
            return Json(new { fees = fees.Amount }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Fees()
        {
            var res = db.Fees.Where(a => a.Balance > 0).ToList();
            return View(res);
        }

        public ActionResult PayFees(int? id)
        {
            var res = db.Fees.Find(id);
            return View(res);
        }

        [HttpPost]
        public ActionResult PayFees(int? id, int? amt)
        {
            var res = db.Fees.Find(id);
            res.Balance = res.Balance - amt;
            db.SaveChanges();
            return Json(new { status = "suceess" }, JsonRequestBehavior.AllowGet);
        }

    }
}