using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using drugaMVC.Models;

namespace drugaMVC.Controllers
{
    public class StudentController : Controller
    {

        List<Student> seznam = new List<Student>();
        // GET: Student
        public ActionResult Index()
        {
            seznam = new List<Student> {
                new Student(){ StudentID = 1, StudentIme="Janez",Leta=18},
                new Student(){ StudentID = 2, StudentIme="Metka",Leta=22},
                new Student(){ StudentID = 3, StudentIme="Fifi",Leta=18},
                };

            return View(seznam);
        }

        public ActionResult TestRazorja()
        {
            return View();
        }

        public ActionResult UporabaModela()
        {
            Student x = new Student() { StudentID = 1, StudentIme = "mifko", Leta = 20 };
            return View(x);
        }

        public ActionResult Edit(int id)
        {
            Student x = seznam.Where(a => a.StudentID == id).FirstOrDefault();

            /*var y = (from a in seznam
                     where a.StudentID == id
                     select a).FirstOrDefault();

            return View(x);*/
        }
    }
}