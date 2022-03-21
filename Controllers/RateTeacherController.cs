using Microsoft.AspNetCore.Mvc;
using Rating.Data;
using Rating.Models;

namespace Rating.Controllers
{
    public class RateTeacherController : Controller
    {

        private readonly TeacherDbContext _context;
        public RateTeacherController(TeacherDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Teacher> objCatlist = _context.Teachers;
            return View(objCatlist);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Teacher rating)
        {
            if (ModelState.IsValid)
            {
                _context.Teachers.Add(rating);
                _context.SaveChanges();
                TempData["ResultOk"] = "Record Added Successfully !";
                return RedirectToAction("Index");
            }

            return View(rating);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var empfromdb = _context.Ratings.Find(id);

            if (empfromdb == null)
            {
                return NotFound();
            }
            return View(empfromdb);
        }


        public IActionResult Rate(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var tid = _context.Teachers.Find(id);
            Ratings ratings = new Ratings();
            ratings.TeacherId = tid.TeacherId;

            return View(ratings);
        }
        [HttpPost]
        public IActionResult Rate(Ratings ratings)
        {
            /*if (ModelState.IsValid)
            {*/
            try
            {
                Teacher teach = new Teacher();
                ratings.Id = 0;
                _context.Ratings.AddRange(ratings);
                _context.SaveChanges();
                var updatedrank = _context.Ratings.Select(r => r).Where(r => r.TeacherId == ratings.TeacherId);
                var teacher = _context.Teachers.Find(ratings.TeacherId);
                teacher.AverageRating = 0;
                var val1 = updatedrank.Sum(u => u.PersonalityPoint);
                var val2 = updatedrank.Sum(u => u.PunctualityPoint);
                var val3 = updatedrank.Sum(u => u.CommunicationPoint);

                var agg = (val1 + val2 + val3) / 3;

                teacher.AverageRating = agg;
                _context.Teachers.Update(teacher);
                _context.SaveChanges();
                TempData["ResultOk"] = "Data Updated Successfully !";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

            }

            //}

            return View(ratings);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var empfromdb = _context.Ratings.Find(id);

            if (empfromdb == null)
            {
                return NotFound();
            }
            return View(empfromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmp(int? id)
        {
            var deleterecord = _context.Ratings.Find(id);
            if (deleterecord == null)
            {
                return NotFound();
            }
            _context.Ratings.Remove(deleterecord);
            _context.SaveChanges();
            TempData["ResultOk"] = "Data Deleted Successfully !";
            return RedirectToAction("Index");
        }



    }
}
