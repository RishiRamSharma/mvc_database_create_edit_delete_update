using Microsoft.Ajax.Utilities;
using mvc_database_create_edit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_database_create_edit.Controllers
{
    public class StudentCtrController : Controller
    {
        // GET: StudentCtr
        private readonly ApplicationContext context;
        public StudentCtrController()
        {
            context = new ApplicationContext();
        }
        public ViewResult Index()
        {
            var studentList = context.Students.ToList();
            return View(studentList);
        }
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (student == null) return HttpNotFound();
            context.Students.Add(student);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var studentId = context.Students.Find(id);
            if(studentId == null) return HttpNotFound();    
            return View(studentId);
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (student == null) return HttpNotFound();
            var studentfromTb = context.Students.Find(student.Id);
            if (studentfromTb == null) return HttpNotFound();
            studentfromTb.Name = student.Name;
            studentfromTb.Class = student.Class;
            studentfromTb.Age = student.Age;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Details(int? id)
        {
            var studentId = context.Students.Find(id);
            if(studentId == null) return HttpNotFound();    
            return View(studentId);
        }
        public ActionResult Delete(int id)
        {
            var studentId = context.Students.Find(id);  
            if (studentId == null) return HttpNotFound();
            return View(studentId);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Student student)
        {
            var studentId = context.Students.Find(id);
            if(studentId==null) return HttpNotFound();
            context.Students.Remove(studentId);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete_Rec(int id)
        {
            var studentId = context.Students.Find(id);
            if (studentId == null) return HttpNotFound();
            context.Students.Remove(studentId);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}