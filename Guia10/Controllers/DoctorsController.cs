using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Guia10.Data;
using Guia10.Models;

namespace Guia10.Controllers
{
    public class DoctorsController : Controller
    {
        private Guia10Context db = new Guia10Context();

        // GET: Doctors
        //agregar parametro para realizar ordenamiento 
        public ActionResult Index(string sortOrder)
        {
            //parametro de ordenamiento en el campo"Apellidos"
            //lo enviamos a la vista
            ViewBag.ApellidoSortParam = String.IsNullOrEmpty(sortOrder) ? "apellido_desc" : "";

            // parametro de ordenamiento en el campo"Apellidos"
            //lo enviamos a la vista
            ViewBag.DUISortParam = sortOrder == "dui_asc" ? "dui_desc" : "dui_asc";

            //variable para lista de doctores de acuerdo al ordenamiento
            //usamos LINQ
            var doctores = from s in db.Doctors select s; 
            switch(sortOrder)
            {
                //ordenamiento descendente por campo "Apellidos" 
                case "apellido_desc":
                    doctores = doctores.OrderByDescending(s => s.Apellidos); 
                    break;

                //ordenamiento descendente por campo "DUI" 
                case "dui_desc":
                    doctores = doctores.OrderByDescending(s => s.DUI);
                    break;

                //ordenamiento ascendente por campo "DUI" 
                case "dui_asc":
                    doctores = doctores.OrderBy(s => s.DUI);
                    break;

                //ordenamiento descendente por campo "Apellidos" 
                default:
                    doctores = doctores.OrderBy(s => s.Apellidos);
                    break;
            }
            return View(doctores.ToList());
            //return View(db.Doctors.ToList());
        }

        // GET: Doctors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoDoctor,DUI,Nombres,Apellidos,Especialidad,Cargo")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoDoctor,DUI,Nombres,Apellidos,Especialidad,Cargo")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Doctor doctor = db.Doctors.Find(id);
            db.Doctors.Remove(doctor);
            db.SaveChanges();
            return RedirectToAction("Index");
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
