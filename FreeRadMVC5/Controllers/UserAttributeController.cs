using AutoMapper;
using FreeRadMVC5.Models;
using FreeRadMVC5.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FreeRadMVC5.Controllers
{
    public class UserAttributeController : Controller
    {
        private IFreeRadRepository _repository;
        private IMappingEngine _mapper;

        public UserAttributeController(IFreeRadRepository repository, IMappingEngine mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public ActionResult Index()
        {
            var userAttr = _repository.GetAllUserAttributes();
            var result = _mapper.Mapper.Map<IEnumerable<UserViewModel>>(userAttr);

            return View(result);
        }

        public ActionResult Create()
        {
            ViewData["UserName"] = new SelectList(_repository.GetAllUsers(), "UserName", "UserName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var newUserAttr = _mapper.Mapper.Map<UserAttribute>(vm);
                _repository.AddUserAttr(newUserAttr);
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

            ViewData["UserName"] = new SelectList(_repository.GetAllUsers(), "UserName", "UserName");
            
            var editUserAttr = _repository.FindUserAttr(id);
            var model = _mapper.Mapper.Map<UserViewModel>(editUserAttr);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var userAttr = _mapper.Mapper.Map<UserAttribute>(vm);
                _repository.EditUserAttr(userAttr);

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

            var model = _repository.FindUserAttr(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _repository.DeleteUserAttr(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}