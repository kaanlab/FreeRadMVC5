using AutoMapper;
using FreeRadMVC5.Models;
using FreeRadMVC5.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FreeRadMVC5.Controllers
{
    public class GroupAttributeController : Controller
    {
        private IFreeRadRepository _repository;
        private IMappingEngine _mapper;

        public GroupAttributeController(IFreeRadRepository repository, IMappingEngine mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var groupAttr = _repository.GetAllGroupAttributes();
            var result = _mapper.Mapper.Map<IEnumerable<GroupViewModel>>(groupAttr);

            return View(result);
        }

        public ActionResult Create()
        {
            ViewData["GroupName"] = new SelectList(_repository.GetAllGroups(), "GroupName", "GroupName");
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(GroupViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var newGroupAttr = _mapper.Mapper.Map<GroupAttribute>(vm);
                _repository.AddGroupAttr(newGroupAttr);
                _repository.SaveAll();

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewData["GroupName"] = new SelectList(_repository.GetAllGroups(), "GroupName", "GroupName");

            var editGroupAttr = _repository.FindGroupAttr(id);
            var model = _mapper.Mapper.Map<GroupViewModel>(editGroupAttr);
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
                var groupAttr = _mapper.Mapper.Map<GroupAttribute>(vm);
                _repository.EditGroupAttr(groupAttr);

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

            var model = _repository.FindGroupAttr(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _repository.DeleteGroupAttr(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }              
    }
}