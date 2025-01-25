using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common_Project;
using Testing_Application_Project.Models;

namespace Testing_Application_Project.Controllers
{
    public class Po_Hedar_LineController : Controller
    {
        // GET: Po_Hedar_Line
        public ActionResult Index()
        {
            string product = "select product_id as [Value], product_name as [Text] from Product_tbl";
            string supplier = "select supplier_id as [Value], supplier_name as [Text] from supplier_tbl";
            string tax = "select tax_id as [Value],tax_name as[Text] from tax_tbl";
            ViewBag.supplier = AllDDL(supplier);
            ViewBag.product = AllDDL(product);
            ViewBag.tax=AllDDL(tax);

            var Hedar = new Po_Hedar_Model();
            var Line = new List<Po_Line_Model>();
            Po_Hedar_Line Model = new Po_Hedar_Line()
            {
                hedar=Hedar,
                line=Line
            };
            return View(Model);
        }
        public List<SelectListItem> AllDDL(string Qry)
        {
            var _selectedlist= new List<SelectListItem>();
            _selectedlist.Add(new SelectListItem { Text="--SELECT--",Value="0"});
            ClsFunction clsfun= new ClsFunction();
            DataTable dt = clsfun.FetchQry(Qry);
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                _selectedlist.Add(new SelectListItem { Text = dt.Rows[i]["Text"].ToString(), Value = dt.Rows[i]["Value"].ToString() });
            }
            return _selectedlist;
        }
        public JsonResult GetSupplierDetails(int supplierid)
        {
            string Qry = "select supplier_contact, supplier_email from supplier_tbl where supplier_id=" + supplierid;
            ClsFunction cls=new ClsFunction();
            DataTable dt=cls.FetchQry(Qry);

            string suppliercontact = dt.Rows[0]["supplier_contact"].ToString();
            string supplierEmail = dt.Rows[0]["supplier_email"].ToString();

            var res = new { contact = suppliercontact, Email = supplierEmail };
            return Json(res,JsonRequestBehavior.AllowGet);
        }
        public JsonResult Product(int productid)
        {
            string item = "select item_id as [Value], item_name as [Text] from item_tbl where product_id=" + productid;
            var _selectlist = new List<SelectListItem>();
            _selectlist.Add(new SelectListItem { Text = "--SELECT", Value = "0" });
            ClsFunction cls = new ClsFunction();
            DataTable dt = cls.FetchQry(item);
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                _selectlist.Add(new SelectListItem { Text = dt.Rows[i]["Text"].ToString(), Value =dt.Rows[i]["Value"].ToString() });
            }
            var res = new { listdata= _selectlist };
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetTaxPercentage(int taxid)
        {
            string taxQry = "select tax_percentage from tax_tbl where tax_id=" + taxid;

            ClsFunction clsfn = new ClsFunction();
            DataTable dt = clsfn.FetchQry(taxQry);

            decimal taxPercentage = Convert.ToDecimal(dt.Rows[0]["tax_percentage"]);
            var res = new { taxPercentage = taxPercentage };
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PoHedarView()
        {
            //string supplier = "select supplier_id as [Value], supplier_name as [Text] from supplier_tbl";
            //ViewBag.supplier = AllDDL(supplier);
            return View();
        }
        public ActionResult PoLineView()
        {
            //string product = "select product_id as [Value], product_name as [Text] from Product_tbl";
            //ViewBag.product = AllDDL(product);
            return View();
        }
    }
}