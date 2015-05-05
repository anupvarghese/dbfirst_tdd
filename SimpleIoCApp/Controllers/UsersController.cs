using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimpleIoCApp;

namespace SimpleIoCApp.Controllers
{
    public class UsersController : Controller
    {
        //private EffortDbEntities db = new EffortDbEntities();
        IUserService _UserService;
        public UsersController(IUserService serv)
        {
            _UserService = serv;
        }

        // GET: Users
        public ActionResult Index()
        {
            return View(_UserService.GetAll());
        }

        
        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _UserService.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        
        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Email,PhoneNumber")] User user)
        {
            if (ModelState.IsValid)
            {
                _UserService.Create(user);
                //db.Users.Add(user);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _UserService.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

       // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Email,PhoneNumber")] User user)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(user).State = EntityState.Modified;
                //db.SaveChanges();
                _UserService.Update(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

       // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _UserService.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = _UserService.GetById(id);
            //db.Users.Remove(user);
            //db.SaveChanges();
            _UserService.Delete(user);
            return RedirectToAction("Index");
        }        
    }
}
