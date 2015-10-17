using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LolWorldFinalStats.Models.Domain;
using LolWorldFinalStats.Services;
using Microsoft.Ajax.Utilities;

namespace LolWorldFinalStats.Areas.Admin.Controllers
{
    public class ChampionsController : Controller
    {
        private readonly ChampionService championService;

        public ChampionsController(ChampionService championService)
        {
            this.championService = championService;
        }

        // GET: Champions
        public ActionResult Index()
        {
            return View(championService.GetAll().OrderBy(a => a.Name));
        }

        public ActionResult Create()
        {
            return View(new Champion());
        }

        [HttpPost]
        public ActionResult Create(Champion model)
        {
            if (ModelState.IsValid)
            {
                championService.InsertOrUpdate(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var champ = championService.GetAll(a => a.Id == id).First();

            return View(champ);
        }

        [HttpPost]
        public ActionResult Edit(Champion champ)
        {
            if (ModelState.IsValid)
            {
                championService.InsertOrUpdate(champ);

                return RedirectToAction("Index");
            }

            return View(champ);
        }
            
    }
}