using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LolWorldFinalStats.Models.Domain;
using LolWorldFinalStats.Services;

namespace LolWorldFinalStats.Areas.Admin.Controllers
{
    public class TeamsController : Controller
    {
        private readonly TeamService teamService;

        public TeamsController(TeamService teamService)
        {
            this.teamService = teamService;
        }

        // GET: Admin/Teams
        public ActionResult Index()
        {
            return View(teamService.GetAll().OrderBy(a => a.Name).ToList());
        }

        // GET: Admin/Teams/Create
        public ActionResult Create()
        {
            return View(new Team());
        }

        // POST: Admin/Teams/Create
        [HttpPost]
        public ActionResult Create(Team model)
        {
            try
            {
                teamService.InsertOrUpdate(model);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Admin/Teams/Edit/5
        public ActionResult Edit(int id)
        {
            var TeamItem = teamService.GetAll(a => a.Id == id).FirstOrDefault();

            if (TeamItem == null)
                return RedirectToAction("Index");

            return View(TeamItem);
        }

        // POST: Admin/Teams/Edit/5
        [HttpPost]
        public ActionResult Edit(Team model)
        {
            try
            {
                teamService.InsertOrUpdate(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Teams/Delete/5
        public ActionResult Delete(int id)
        {
            return View(teamService.GetAll(a => a.Id == id).First());
        }

        // POST: Admin/Teams/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Team model)
        {
            try
            {
                var item = teamService.GetAll(a => a.Id == id).FirstOrDefault();

                teamService.Purge(item);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}