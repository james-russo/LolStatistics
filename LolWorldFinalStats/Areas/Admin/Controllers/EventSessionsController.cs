using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LolWorldFinalStats.Models.Domain;
using LolWorldFinalStats.Services;

namespace LolWorldFinalStats.Areas.Admin.Controllers
{
    public class EventSessionsController : Controller
    {
        private readonly EventSessionService _eventSessionService;

        public EventSessionsController(EventSessionService eventSessionService)
        {
            _eventSessionService = eventSessionService;
        }

        // GET: Admin/EventSessions
        public ActionResult Index(int eventId)
        {
            return View(_eventSessionService.GetAll(a => a.EventId == eventId));
        }
        
        // GET: Admin/EventSessions/Create
        public ActionResult Create()
        {
            return View(new EventSession());
        }

        // POST: Admin/EventSessions/Create
        [HttpPost]
        public ActionResult Create(EventSession model)
        {
            try
            {
                _eventSessionService.InsertOrUpdate(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/EventSessions/Edit/5
        public ActionResult Edit(int id)
        {
            var item = _eventSessionService.GetAll(a => a.Id == id).FirstOrDefault();

            return View(item);
        }

        // POST: Admin/EventSessions/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EventSession model)
        {
            try
            {
                _eventSessionService.InsertOrUpdate(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Admin/EventSessions/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_eventSessionService.GetAll(a => a.Id == id).First());
        }

        // POST: Admin/EventSessions/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EventSession model)
        {
            try
            {
                var item = _eventSessionService.GetAll(a => a.Id == id).First();

                _eventSessionService.Purge(item);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
