using sendingmails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sendingmails.Controllers
{
    public class DropdownController : Controller
    {
        // GET: Dropdown
        MVCEntities1 DB = new MVCEntities1();
        public ActionResult Index()
        {
            List<m_district_test> distList = DB.m_district_test.ToList();
            ViewBag.Districts=new SelectList(distList,"sno","District");
            return View();
        }
    }
} 