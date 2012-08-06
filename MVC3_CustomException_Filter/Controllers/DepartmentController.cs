using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC3_CustomException_Filter.CustomFilterRepository;
using MVC3_CustomException_Filter.Models;

namespace MVC3_CustomException_Filter.Controllers
{ 
    public class DepartmentController : Controller
    {
        private CompanyEntities db = new CompanyEntities();

        //
        // GET: /Department/

        public ViewResult Index()
        {
            return View(db.Departments.ToList());
        }

        //
        // GET: /Department/Details/5

        public ViewResult Details(int id)
        {
            Department department = db.Departments.Single(d => d.DeptNo == id);
            return View(department);
        }

        //
        // GET: /Department/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Department/Create

        [HttpPost]
        [ModelException]
        public ActionResult Create(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Departments.AddObject(department);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception)
            {
                throw; 
            }
            return View(department);
        }
        
        //
        // GET: /Department/Edit/5
 
        public ActionResult Edit(int id)
        {
            Department department = db.Departments.Single(d => d.DeptNo == id);
            return View(department);
        }

        //
        // POST: /Department/Edit/5

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Attach(department);
                db.ObjectStateManager.ChangeObjectState(department, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        //
        // GET: /Department/Delete/5
 
        public ActionResult Delete(int id)
        {
            Department department = db.Departments.Single(d => d.DeptNo == id);
            return View(department);
        }

        //
        // POST: /Department/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Department department = db.Departments.Single(d => d.DeptNo == id);
            db.Departments.DeleteObject(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}