using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class NominaController : Controller
    {

        // GET: Nomina
        public ActionResult Index()
        {
                return View();
        }
        [HttpPost]
        public ActionResult Index(Nominas nomin)
        {
            using (RecursosHumanosEntities4 db = new RecursosHumanosEntities4())
            {
                if (db.Empleados.Where(m=>m.FechaIng.Month == nomin.Mes && m.FechaIng.Year == nomin.Año).Count()>0)
                {
                    if (ModelState.IsValid)
                    {
                        var nomina = (from n in db.Empleados
                                      where n.FechaIng.Month == nomin.Mes && n.FechaIng.Year == nomin.Año
                                      select n.Salario).Sum();

                        nomin.Total_Nomina = nomina;
                        db.Nominas.Add(nomin);
                        db.SaveChanges();

                        ViewBag.Total = nomina;
                    }
                }
                else
                {
                    ViewBag.error = "Esta nomina no existe";
                }

            }
            return View();
        }
        public ActionResult Listar()
        {
            List<Nominas> lista;
            using (RecursosHumanosEntities4 db = new RecursosHumanosEntities4())
            {
                lista = (from list in db.Nominas
                             select list).ToList();
            }
            return View(lista);
        }
        public ActionResult Edit(int? id)
        {
            using (RecursosHumanosEntities4 db = new RecursosHumanosEntities4())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Nominas nominas = db.Nominas.Find(id);
                if (nominas == null)
                {
                    return HttpNotFound();
                }
                return View(nominas);
            }
                
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Nominas,Año,Mes,Total_Nomina")] Nominas nominas)
        {
            using (RecursosHumanosEntities4 db = new RecursosHumanosEntities4())
            {
                if (ModelState.IsValid)
                {
                    var nomina = (from n in db.Empleados
                                  where n.FechaIng.Month == nominas.Mes && n.FechaIng.Year == nominas.Año
                                  select n.Salario).Sum();
                    nominas.Total_Nomina = nomina;
                    db.Entry(nominas).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Listar");
                }
                return View(nominas);
            }
           
        }

        // GET: Nominas/Delete/5
        public ActionResult Delete(int? id)
        {
            using (RecursosHumanosEntities4 db = new RecursosHumanosEntities4())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Nominas nominas = db.Nominas.Find(id);
                if (nominas == null)
                {
                    return HttpNotFound();
                }
                return View(nominas);
            }
              
        }

        // POST: Nominas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (RecursosHumanosEntities4 db = new RecursosHumanosEntities4())
            {
                Nominas nominas = db.Nominas.Find(id);
                db.Nominas.Remove(nominas);
                db.SaveChanges();
                return RedirectToAction("Listar");
            }

        }

        protected override void Dispose(bool disposing)
        {
            using (RecursosHumanosEntities4 db = new RecursosHumanosEntities4())
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }
               
        }
    }
}
