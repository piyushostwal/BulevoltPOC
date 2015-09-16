using Bluevolt.POC.Business;
using Bluevolt.POC.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Bluevolt.POC.Web.Controllers
{
    public class UserDetailsController : Controller
    {
        #region Declarations 

        UserDetails _userDetails;
 
        #endregion

        #region Methods

        public ActionResult Index()
        {
            _userDetails = new UserDetails();         
            return View(_userDetails.Search(new UserDetailsSearch()).Items);
        }
      
        public ActionResult Details(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return View(GetData(id.Value));
        }       

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Create(UserDetails user)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    var userDetails = new UserDetails();
                    if (userDetails.Save(user))
                        return RedirectToAction("Index");                  
                }
                return View(user);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return View(GetData(id));
        }

        [HttpPost]
        public ActionResult Edit(UserDetails user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userDetails = new UserDetails();
                    if (userDetails.Save(user))
                        return RedirectToAction("Index");
                }
                return View(user);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return View(GetData(id));
        }

        [HttpPost]
        public ActionResult Delete(UserDetails user)
         {
             try
            {
                if (ModelState.IsValid)
                {
                    var userDetails = new UserDetails();
                    if (userDetails.Remove(user))
                        return RedirectToAction("Index");
                }
                return View(user);
            }
            catch
            {
                return View();
            }
         }        

        private IUserDetails GetData(long id)
        {
            _userDetails = new UserDetails();
            return _userDetails.Search(new UserDetailsSearch()).Items.FirstOrDefault(u => u.ID == id);

        }

        #endregion
    }
}
