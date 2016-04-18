using FreeRadMVC5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using AutoMapper;
using FreeRadMVC5.ViewModels;

namespace FreeRadMVC5.Controllers
{
    public class GroupController : Controller
    {
        private IMappingEngine _mapper;
        private IFreeRadRepository _repository;

        public GroupController(IFreeRadRepository repository, IMappingEngine mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var group = _repository.GetAllGroups();
            var result = _mapper.Mapper.Map<IEnumerable<GroupViewModel>>(group);

            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GroupViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var newGrop = _mapper.Mapper.Map<Group>(vm);
                _repository.AddGroup(newGrop);
                _repository.SaveAll();

                return RedirectToAction("Index");
            }

            return View(vm);

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var editGroup = _repository.FindGroup(id);
            var model = _mapper.Mapper.Map<GroupViewModel>(editGroup);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(GroupViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var group = _mapper.Mapper.Map<Group>(vm);
                _repository.EditGroup(group);

                return RedirectToAction("Index");
            }
            return View(vm);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = _repository.FindGroup(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _repository.DeleteGroup(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
