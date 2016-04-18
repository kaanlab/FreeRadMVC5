using AutoMapper;
using FreeRadMVC5.Mapper;
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
    public class UserController : Controller
    {
        private IFreeRadRepository _repository;
        private IMappingEngine _mapper;

        public UserController(IFreeRadRepository repository, IMappingEngine mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var users = _repository.GetAllUsers();
            var result = _mapper.Mapper.Map<IEnumerable<UserViewModel>>(users);

            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var newUser = _mapper.Mapper.Map<User>(vm);
                _repository.AddUser(newUser);
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

            var editUser = _repository.FindUser(id);
            var model = _mapper.Mapper.Map<UserViewModel>(editUser);
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
                var user = _mapper.Mapper.Map<User>(vm);
                _repository.EditUser(user);

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

            var model = _repository.FindUser(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _repository.DeleteUser(id);
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}