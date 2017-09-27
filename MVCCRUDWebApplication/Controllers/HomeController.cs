using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCRUDWebApplication.Models;
using System.Net;

namespace MVCCRUDWebApplication.Controllers
{
    public class HomeController : Controller
    {



        // GET: Home

       public CustomerContex Contex;
        private Customer2 cust2;

        public HomeController()
        {

            Contex = new CustomerContex();
        }
        public ActionResult Index()
        {
           


            return View(Contex.Customers.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer2 obj)
        {
            Contex.Customers.Add(obj);
            Contex.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int? ID)
        {

            if (ID == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Customer2 customers = Contex.Customers.Find(ID);
            if (customers == null)
                return HttpNotFound();
            return View(customers);



        }

        [HttpPost]
        public ActionResult Edit(Customer2 myobj1)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Contex.Entry(myobj1).State
                        = System.Data.Entity.EntityState.Modified;
                    Contex.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(myobj1);
            }
            catch
            {

                return View();
            }


        }

        public ActionResult Details()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Details(int? Id)
        {
            if (Id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        Customer2 c2 = Contex.Customers.Find(Id);
            if (c2 == null)
                return HttpNotFound();
            return View(c2);
        }









        [HttpGet]
        public ActionResult Delete(int? ID)
        {

            
                if (ID == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                Customer2 customer2 = Contex.Customers.Find(ID);
                if (customer2 == null)
                    return HttpNotFound();
                
                return View(customer2);
            
        }






        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? ID)
        {
            try
            {
                Customer2 customer3 = new Customer2();
                if (ModelState.IsValid)
                {
                    if (ID == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                 this.cust2= Contex.Customers.Find(ID);
                    if (cust2 == null)
                        return HttpNotFound();
                    Contex.Customers.Remove(cust2);
                    Contex.SaveChanges();
                    return RedirectToAction("Index");

                }

                return View(customer3);
            }
            catch
            {
                return View();
            }

        }

    }
}

