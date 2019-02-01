using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Business.Models;
using Business.Repositories;
using Staff = DAL.Models.Staff;

namespace Task2_WebApplication1.Controllers
{
    public class StaffsController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public StaffsController()
        {
            _unitOfWork = new UnitOfWork();
        }

        // GET: Staffs
        public ActionResult Index()
        {
            var users = Mapper.Map<IEnumerable<Staff>, List<StaffModel>>(_unitOfWork.Staffs.GetList());

            return View(users);
        }

        // GET: Staffs/Details/5
        public ActionResult Details(int? id)
        {
            var users = Mapper.Map<Staff, StaffModel>(_unitOfWork.Staffs.Get(id));

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: Staffs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staffs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StaffModel staff)
        {
            var user = Mapper.Map<StaffModel, Staff>(staff);
            _unitOfWork.ValidateStaffer.ValidateStaffer(staff);
            var succeed = _unitOfWork.Staffs.AddRecord(user);
            if (succeed) succeed = TrySaveChanges();

            return succeed ? (ActionResult)RedirectToAction("Index") : View(staff);
        }

        // GET: Staffs/Edit/5
        public ActionResult Edit(int? id)
        {
            var users = Mapper.Map<Staff, StaffModel>(_unitOfWork.Staffs.Get(id));

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Staffs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StaffModel staff)
        {
            var user = Mapper.Map<StaffModel, Staff>(staff);
            _unitOfWork.ValidateStaffer.ValidateStaffer(staff);
            var succeed = _unitOfWork.Staffs.Edit(user);
            if (succeed) succeed = TrySaveChanges();

            return succeed ? (ActionResult)RedirectToAction("Index") : View(staff);
        }

        // GET: Staffs/Delete/5
        public ActionResult Delete(int? id)
        {
            var users = Mapper.Map<Staff, StaffModel>(_unitOfWork.Staffs.Get(id));

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var users = Mapper.Map<Staff, StaffModel>(_unitOfWork.Staffs.Get(id));

            _unitOfWork.Staffs.Remove(id);
            var succeed = TrySaveChanges();
            return succeed ? (ActionResult)RedirectToAction("Index") : View(users);
        }

        public bool TrySaveChanges()
        {
            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eError in e.EntityValidationErrors)
                {
                    foreach (var error in eError.ValidationErrors)
                    {

                        ModelState.AddModelError("", string.Format("{0}: {1}", error.PropertyName, error.ErrorMessage));
                    }
                }
                ViewBag.Exception = e.Message;
                return false;
            }
            return true;
        }
    }
}
