using _4th_Year_BMS_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.VisualStudio.Tools.Applications.Runtime;

namespace _4th_Year_BMS_Project.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Contacts
        public ActionResult Index()
        {
            return View(db.Contacts.ToList());
        }


        // GET: Contacts
        public ActionResult Viewer()
        {
            return View("Viewer");
        }


        // GET: Contacts/Edit/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }



        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit([Bind(Include = "ContactId,Name,Address,City,State,Zip,Email,UserName,PasswordIn,electrical_Circuit_1,electrical_Circuit_2,electrical_Circuit_3,electrical_Circuit_4,heating_Circuit_1,heating_Circuit_2,heating_Circuit_3,heating_Circuit_4,door_access")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                ExportToExcelDoc(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void ExportToExcelDoc(Contact contact)
          {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook sheet = excel.Workbooks.Open("C:\\Sharer\\HomeCurrentSettings.xlsx");
            Microsoft.Office.Interop.Excel.Worksheet x = excel.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;

            Excel.Range userRange = x.UsedRange;
            int countRecords = userRange.Rows.Count;
            int add = countRecords + 1;
            //List<int> actualDB = db.Contacts.ToList();
            x.Cells[2, 1] = contact.electrical_Circuit_1;
            x.Cells[2, 2] = contact.electrical_Circuit_2;
            x.Cells[2, 3] = contact.electrical_Circuit_3;
            x.Cells[2, 4] = contact.electrical_Circuit_4;
            x.Cells[2, 5] = contact.heating_Circuit_1;
            x.Cells[2, 6] = contact.heating_Circuit_2;
            x.Cells[2, 7] = contact.heating_Circuit_3;
            x.Cells[2, 8] = contact.heating_Circuit_4;
            x.Cells[2, 9] = contact.door_access;

            sheet.Save();
            sheet.Close();
        }
    }
}