using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common_Project;
using Testing_Application_Project.Models;
using Testing_Application_Project.Repo;

namespace Testing_Application_Project.Controllers
{
    public class InstituteController : Controller
    {
        // GET: Institute
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InstitutePartial()
        {
            return View();
        }

        public ActionResult SaveRecord(InstituteModel model)
        {
            SaveData sd=new SaveData();
            sd.save(model);
            return RedirectToAction("Index");
        }

        public ActionResult Report()
        {
            ClsFunction cls = new ClsFunction();
            DataTable dt = cls.FetchQry("select * from Institute_tbl");
            int count = dt.Rows.Count;

            var ReportData = new List<InstituteModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                InstituteModel model = new InstituteModel()
                {
                    Institute_id = Convert.ToInt32(dt.Rows[i]["Institute_id"]),
                    Institute_Name = dt.Rows[i]["Institute_Name"].ToString(),
                    Institute_Contact = dt.Rows[i]["Institute_Contact"].ToString(),
                    Institute_Address = dt.Rows[i]["Institute_Address"].ToString(),
                    Institute_Url = dt.Rows[i]["Institute_Url"].ToString(),
                    Institute_Email = dt.Rows[i]["Institute_Email"].ToString(),
                    Institute_Reg_No = dt.Rows[i]["Institute_Reg_No"].ToString()
                };
                ReportData.Add(model);
            }
            return View(ReportData);

        }
        public ActionResult Edit(int id)
        {
            ClsFunction cls = new ClsFunction();
            DataTable dt = cls.FetchQry("select * from Institute_tbl where Institute_id=" + id);
            InstituteModel model = new InstituteModel()
            {
                Institute_id = Convert.ToInt32(dt.Rows[0]["Institute_id"]),
                Institute_Name = dt.Rows[0]["Institute_Name"].ToString(),
                Institute_Contact = dt.Rows[0]["Institute_Contact"].ToString(),
                Institute_Address = dt.Rows[0]["Institute_Address"].ToString(),
                Institute_Url = dt.Rows[0]["Institute_Url"].ToString(),
                Institute_Email = dt.Rows[0]["Institute_Email"].ToString(),
                Institute_Reg_No = dt.Rows[0]["Institute_Reg_No"].ToString()
            };
            return PartialView("Index", model);
        }
        public ActionResult Delete(int id)
        {
            string deleteQry = "delete from Institute_tbl where Institute_id=" + id;
            ClsFunction Cls=new ClsFunction();
            Cls.ExecuteQry(deleteQry);
            return RedirectToAction("Index");
        }

       
        
    }
}