using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _4th_Year_BMS_Project.Models;
using OfficeOpenXml;
using ClosedXML;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

namespace _4th_Year_BMS_Project.Controllers
{
    public class ContactsController : Controller
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





        // GET: Contacts/Details/5
        public ActionResult Details(int? id)
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





        // GET: Contacts/Create
        [Authorize(Roles = "canEdit")]
        public ActionResult Create()
        {
            return View();
        }





        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactId,Name,Address,City,State,Zip,Email,UserName,PasswordIn,electrical_Circuit_1,electrical_Circuit_2,electrical_Circuit_3,electrical_Circuit_4,heating_Circuit_1,heating_Circuit_2,heating_Circuit_3,heating_Circuit_4,door_access")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
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
                return RedirectToAction("Index");
            }
            return View(contact);
        }






        // GET: Contacts/Delete/5
        //[Authorize(Roles = "canEdit")]
        public ActionResult Delete(int? id)
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





        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }





        public void Upload(FormCollection formCollection)
        {
            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["UploadedFile"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = file.FileName;
                    string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                    List<int> usersList = new List<int>();
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;

                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            var user = new Users();
                            usersList.Add(user.electrical_Circuit_1 = Convert.ToInt32(workSheet.Cells[rowIterator, 1].Value.ToString()));
                            usersList.Add(user.electrical_Circuit_2 = Convert.ToInt32(workSheet.Cells[rowIterator, 2].Value.ToString()));
                            usersList.Add(user.electrical_Circuit_3 = Convert.ToInt32(workSheet.Cells[rowIterator, 3].Value.ToString()));
                            usersList.Add(user.electrical_Circuit_4 = Convert.ToInt32(workSheet.Cells[rowIterator, 4].Value.ToString()));
                            usersList.Add(user.heating_Circuit_1 = Convert.ToInt32(workSheet.Cells[rowIterator, 5].Value.ToString()));
                            usersList.Add(user.heating_Circuit_2 = Convert.ToInt32(workSheet.Cells[rowIterator, 6].Value.ToString()));
                            usersList.Add(user.heating_Circuit_3 = Convert.ToInt32(workSheet.Cells[rowIterator, 7].Value.ToString()));
                            usersList.Add(user.heating_Circuit_4 = Convert.ToInt32(workSheet.Cells[rowIterator, 8].Value.ToString()));
                            usersList.Add(user.door_access = Convert.ToInt32(workSheet.Cells[rowIterator, 9].Value.ToString()));
                            
                        }
                    }
                }
            }
        }
    }
}
