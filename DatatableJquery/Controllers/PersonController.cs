using DatatableJquery.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DatatableJquery.Controllers
{
    public class PersonController : Controller
    {
        PeopleEntities db = new PeopleEntities();
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPersonList()
        {
            List<PersonViewModel> PersList = db.People.Where(x => x.IsDeleted == false).Select(x => new PersonViewModel
            {
                Id = x.Id,
                firstname = x.firstname,
                lastname = x.lastname,
                birthday = x.birthday,
                email = x.email,
                phone = x.phone,
                company = x.company,
                zipcode = x.zipcode
               
            }).ToList();

            return Json(PersList, JsonRequestBehavior.AllowGet);



        }
        public JsonResult GetPersonById(int Id)
        {
            Person model = db.People.Where(x => x.Id == Id).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveDataInDatabase(PersonViewModel model)
        {
            var result = false;
            try
            {
                if (model.Id > 0)
                {
                    Person Pers = db.People.SingleOrDefault(x => x.IsDeleted == false && x.Id == model.Id);
                    Pers.firstname = model.firstname;
                    Pers.lastname = model.lastname;
                    Pers.birthday = model.birthday;
                    Pers.email = model.email;
                    Pers.phone = model.phone;
                    Pers.company = model.company;
                    Pers.zipcode = model.zipcode;                   
                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    Person Pers = new Person();
                    Pers.Id = model.Id;
                    Pers.firstname = model.firstname;
                    Pers.lastname = model.lastname;
                    Pers.birthday = model.birthday;
                    Pers.email = model.email;
                    Pers.phone = model.phone;
                    Pers.company = model.company;
                    Pers.zipcode = model.zipcode;
                    Pers.IsDeleted = false;
                    db.People.Add(Pers);
                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeletePersonRecord(int Id)
        {
            bool result = false;
            Person Pers = db.People.SingleOrDefault(x => x.IsDeleted == false && x.Id == Id);
            if (Pers != null)
            {
                Pers.IsDeleted = true;
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}