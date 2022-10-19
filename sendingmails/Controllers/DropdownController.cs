using sendingmails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace sendingmails.Controllers
{
    public class DropdownController : Controller
    {
        string conn1 = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        
        // GET: Dropdown
        MVCEntities1 DB = new MVCEntities1();
        public ActionResult Index()
        {
            List<m_district_test> distList = DB.m_district.ToList();
            ViewBag.Districts=new SelectList(distList,"sno","District");
            return View();
        }
        public ActionResult Dropdownlist()
        {
            string qry = "select * from [dbo].[m_city_test]";
            var kjhg =connection(qry);
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (DataRow dr in ViewBag.cities.Rows)
            {
                list.Add(new SelectListItem { Text = dr["City"].ToString(),Value = dr["sno"].ToString() });
            }
            ViewBag.city = list;
            
            return View();
        }//https://youtu.be/_l_p7MOqRho
        public ActionResult connection(string qry)
        {
            SqlConnection con = new SqlConnection(conn1);
            SqlCommand cmd = new SqlCommand(qry, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ViewBag.cities = ds.Tables[0];
            con.Close();
            return View(ds);
        }
    }
} 