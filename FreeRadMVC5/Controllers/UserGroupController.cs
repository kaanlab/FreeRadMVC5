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
    public class UserGroupController : Controller
    {
        private IFreeRadRepository _repository;
        private IMappingEngine _mapper;

        public UserGroupController(IFreeRadRepository repository, IMappingEngine mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: UserGroup
        public ActionResult Index()
        {
            var userInGroup = _repository.GetAllUsersInGroup();
            var result = _mapper.Mapper.Map<IEnumerable<UserGroupViewModel>>(userInGroup);

            return View(result);
        }

        public ActionResult Create()
        {
            //List<User> usersList = context.Users.ToList();
            //List<Group> groupList = context.Groups.ToList();
            //ViewBag.UsersList = new SelectList(usersList, "UserName", "UserName");
            //ViewBag.GroupsList = new SelectList(groupList, "GroupName", "GroupName");

            ViewData["UserName"] = new SelectList(_repository.GetAllUsers(), "UserName", "UserName");
            ViewData["GroupName"] = new SelectList(_repository.GetAllGroups(), "GroupName", "GroupName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(UserGroupViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var selectedUser = _mapper.Mapper.Map<UserGroup>(vm);
                _repository.AddUserToGroup(selectedUser);
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

            //List<User> usersList = context.Users.ToList();
            //List<Group> groupList = context.Groups.ToList();
            //ViewBag.UsersList = new SelectList(usersList, "UserName", "UserName");
            //ViewBag.GroupsList = new SelectList(groupList, "GroupName", "GroupName");

            ViewData["UserName"] = new SelectList(_repository.GetAllUsers(), "UserName", "UserName");
            ViewData["GroupName"] = new SelectList(_repository.GetAllGroups(), "GroupName", "GroupName");

            var editUser = _repository.FindUserInGroup(id);
            var model = _mapper.Mapper.Map<UserGroupViewModel>(editUser);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UserGroupViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Mapper.Map<UserGroup>(vm);
                _repository.EditUserInGroup(user);
                
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

            var model = _repository.FindUserInGroup(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _repository.DeleteUserFromGroup(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}