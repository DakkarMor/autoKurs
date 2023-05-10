using kursovik.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kursovik.Models;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace kursovik.Controllers
{
    public class HomeController : Controller
    {
        ContactsDAO contactsDAO = new ContactsDAO();
        GroupsDAO groupsDAO = new GroupsDAO();

        public ActionResult Index()
        {
            return View("Index");
        }
        //private bd1Entities3 _entities = new bd1Entities3();
        //
        // GET: /Home/
        public async Task<ActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["PointSortParm"] = String.IsNullOrEmpty(sortOrder) ? "ArrivalPoint" : "";
            ViewData["TimeSortParm"] = sortOrder == "" ? "TimeDeparture" : "Time";
            ViewData["CurrentFilter"] = searchString;

            var routes = from s in contactsDAO.getAllContacts()
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                routes = routes.Where(s => s.DeparturePoint.ToUpper().Contains(searchString.ToUpper())
                                       || s.ArrivalPoint.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "ArrivalPoint":
                    routes = routes.OrderByDescending(s => s.DeparturePoint);
                    break;
                case "TimeDeparture":
                    routes = routes.OrderBy(s => s.TimeDeparture);
                    break;
                case "Time":
                    routes = routes.OrderByDescending(s => s.TimeDeparture);
                    break;
                default:
                    routes = routes.OrderBy(s => s.DeparturePoint);
                    break;
            }
            return View(contactsDAO.getAllContacts());
        }
        //
        // GET: /Home/Details/5
        public ActionResult Details(int id)
        {
            return View(contactsDAO.getContact(id));
        }
        protected bool ViewDataSelectList(int TransportId)
        {
            var groups = groupsDAO.getAllGroups();
            ViewData["TransportId"] = new SelectList(groups, "Id", "Name",
           TransportId);
            return groups.Count() > 0;
        }
        //
        // GET: /Home/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            if (!ViewDataSelectList(-1))
                return RedirectToAction("Index");
            return View("Create");
        }
        //
        // POST: /Home/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(int TransportId, [Bind(Exclude = "Id")] Route contact)
        {
            if (contactsDAO.addContact(TransportId, contact))
                return RedirectToAction("Index");
            else
            {
                ViewDataSelectList(TransportId);
                return View("Create");
            }
        }
        //
        // GET: /Home/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            Route contact = contactsDAO.getContact(id);
            if (!ViewDataSelectList(contact.Transport.Id))
                return RedirectToAction("Index");
            return View(contactsDAO.getContact(id));
        }
        //
        // POST: /Home/Edit/5
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int TransportId, int id, Route contact)
        {
            if (contactsDAO.updateContact(TransportId, contact))
                return RedirectToAction("Index");
            else
            {
                ViewDataSelectList(-1);
                return View("Edit", contactsDAO.getContact(id));
            }
        }
        //
        // GET: /Home/Delete
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            return View("Delete", contactsDAO.getContact(id));
        }
        //
        // POST: /Home/Delete
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, Route contact)
        {
            if (contactsDAO.deleteContact(contact))
                return RedirectToAction("Index");
            else
                return View("Delete", contactsDAO.getContact(id));
        }
    }
}
