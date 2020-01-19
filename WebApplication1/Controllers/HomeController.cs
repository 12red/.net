using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using MySql.Data.MySqlClient;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login([Bind] Logins logins)
        {
            datas data = new datas();


            if (data.userlogin(logins) > 0)
            {

                return RedirectToAction("write");


            }

            else
            {
                TempData["UserLoginFailed"] = "Login Failed.Please enter correct credentials";
                return View(logins);

            }

        }












        [HttpGet]
        public IActionResult register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult register(Register register)
        {
            if (register.password != register.repassword)
            {
                TempData["UserLoginFailed"] = "Registering Failed! Please enter correct credentials";
                return View();


            }
            datas db = new datas();
            db.Insert(register);

            return View("login");
        }
        [HttpGet]
        public IActionResult write()
        {
            return View();
        }
        [HttpPost]
        public IActionResult write(Venting vent)
        {
            TempData["Success"] = "Locked away :) !";
            datas da = new datas();
            da.story(vent);
            return View("write");
        }


        [HttpGet]
        public IActionResult lists()
        {
            datas data = new datas();
            List<Venting> ven = new List<Venting>();
            ven = data.list().ToList();
            return View(ven);
        }
        [HttpPost]
        public IActionResult lists(diaryvent dv)
        {

            return View();
        }



        [HttpGet]
        public IActionResult writing(int?id)
        {
            datas da = new datas();
            if(id == null){
                return NotFound();
            }
            Venting ben =da.GetDiary(id);
            if(ben == null)
            {
                return NotFound();
            }
            return View(ben);
        }
        [HttpPost]
        public IActionResult writing(int id,[Bind] Venting venting)
        {
            datas da = new datas();
           if(id != venting.id){
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                da.updateDiary(venting);
                return RedirectToAction("lists");

            }
            return View(venting);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            datas da = new datas();
            if (id == null)
            {
                return NotFound();

            }
            Venting va= da.GetDiary(id);
            if(da == null)
            {
                return NotFound();
            }

            return View(va);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            datas da = new datas();
            da.DeleteDiary(id);
            return RedirectToAction("lists");
        }



    }

}
