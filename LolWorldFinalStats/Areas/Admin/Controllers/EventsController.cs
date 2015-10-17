using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LolWorldFinalStats.Models.Domain;
using LolWorldFinalStats.Services;

namespace LolWorldFinalStats.Areas.Admin.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventService _eventService;

        public EventsController(EventService eventService)
        {
            _eventService = eventService;
        }

        // GET: Admin/Events
        public ActionResult Index()
        {
            return View(_eventService.GetAll());
        }
        
        // GET: Admin/Events/Create
        public ActionResult Create()
        {
            return View(new Event());
        }

        // POST: Admin/Events/Create
        [HttpPost]
        public ActionResult Create(Event model)
        {
            try
            {
                _eventService.InsertOrUpdate(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Events/Edit/5
        public ActionResult Edit(int id)
        {
            var eventItem = _eventService.GetAll(a => a.Id == id).FirstOrDefault();

            if (eventItem == null)
                return RedirectToAction("Index");

            return View(eventItem);
        }

        // POST: Admin/Events/Edit/5
        [HttpPost]
        public ActionResult Edit(Event model)
        {
            try
            {
                _eventService.InsertOrUpdate(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Events/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Events/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Event model)
        {
            try
            {
                var item = _eventService.GetAll(a => a.Id == id).FirstOrDefault();

                _eventService.Purge(item);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
