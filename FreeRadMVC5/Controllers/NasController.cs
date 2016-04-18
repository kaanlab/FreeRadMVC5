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
    public class NasController : Controller
    {
        private IFreeRadRepository _repository;
        private IMappingEngine _mapper;

        public NasController(IFreeRadRepository repository, IMappingEngine mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: User
        public ActionResult Index()
        {
            var nases = _repository.GetAllNas();
            var result = _mapper.Mapper.Map<IEnumerable<NasViewModel>>(nases);

            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NasViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var newNas = _mapper.Mapper.Map<Nas>(vm);
                _repository.AddNas(newNas);
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

            var editNas = _repository.FindNas(id);
            var model = _mapper.Mapper.Map<NasViewModel>(editNas);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(NasViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var nas = _mapper.Mapper.Map<Nas>(vm);
                _repository.EditNas(nas);

                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: Group/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = _repository.FindNas(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        // POST: Group/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _repository.DeleteNas(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}