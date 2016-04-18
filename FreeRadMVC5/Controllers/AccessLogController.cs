using FreeRadMVC5.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;


namespace FreeRadMVC5.Controllers
{
    public class AccessLogController : Controller
    {
        private IFreeRadRepository _repository;

        public AccessLogController(IFreeRadRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index(int pageIndex = 1)
        {
            return View(_repository.GetAllLogsOderByIdDes().ToPagedList(pageIndex, 15));
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = _repository.FindLog(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _repository.DeleteLog(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}