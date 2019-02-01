using System;
using System.Data.Entity;
using System.Globalization;
using System.Text.RegularExpressions;
using Business.Models;

namespace Business.Repositories
{
    public class StaffRepository : EFRepository<StaffRepository>, IStaffRepository
    {
        public StaffRepository(DbContext context) : base(context) { }

        public void ValidateStaffer(StaffModel staff)
        {
            DateTime dt;
            if (string.IsNullOrEmpty(staff.last_name)) ModelState.AddModelError("", "Фамилия: Поле обязательное");
            if (string.IsNullOrEmpty(staff.first_name)) ModelState.AddModelError("", "Имя: Поле обязательное");
            if (string.IsNullOrEmpty(staff.father_name)) ModelState.AddModelError("", "Отчество: Поле обязательное");
            if (staff.birth_dt == DateTime.MinValue) ModelState.AddModelError("", "Дата рождения: Поле обязательное");
            else if (!DateTime.TryParseExact(staff.birth_dt.ToShortDateString(), "M/d/yyyy", System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out dt)) ModelState.AddModelError("", "Дата рождения: Неверный формат");
            if (!string.IsNullOrEmpty(staff.email))
            {
                var regex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                var re = new Regex(regex);
                if (!re.IsMatch(staff.email)) ModelState.AddModelError("", "Email: Неверный формат");
            }
            if (!string.IsNullOrEmpty(staff.phone_nbr))
            {
                var regex = @"^[0-9]+$";
                var re = new Regex(regex);
                if (!re.IsMatch(staff.phone_nbr)) ModelState.AddModelError("", "Контактный телефон: Неверный формат");
            }
            ViewBag.LastName = staff.last_name;
            ViewBag.FirstName = staff.first_name;
            ViewBag.FatherName = staff.father_name;
            ViewBag.BirthDt = staff.birth_dt;
            ViewBag.Email = staff.email;
            ViewBag.Phone = staff.phone_nbr;
        }
    }
    //public class StaffRepository : Controller, IRepository<DAL.Models.Staff>
    //{
    //    private EntityContext entities;

    //    public StaffRepository(EntityContext context)
    //    {
    //        this.entities = context;
    //    }

    //    public IList<DAL.Models.Staff> GetList(int max = 0)
    //    {

    //        var listStaff = max > 0 ? entities.Staffs.Take(max).ToList() : entities.Staffs.ToList();
    //        return listStaff;
    //    }

    //    public DAL.Models.Staff Get(int? id)
    //    {
    //        var staff = entities.Staffs.Find(id); ;
    //        return staff;
    //    }

    //    public void Remove(int? id)
    //    {
    //        var staffer = Get(id);
    //        entities.Staffs.Remove(staffer);
    //    }

    //    public bool Edit(DAL.Models.Staff staff)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            ValidateStaffer(staff);
    //            entities.Entry(staff).State = EntityState.Modified;
    //            return true;
    //        }
    //        return false;
    //    }

    //    public void Edit(int? id)
    //    {
    //        var staff = Get(id);
    //        entities.Entry(staff).State = EntityState.Modified;
    //    }

    //    public bool AddRecord(DAL.Models.Staff staff)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            ValidateStaffer(staff);
    //            entities.Staffs.Add(staff);
    //            return true;
    //        }
    //        return false;
    //    }

    //    private void ValidateStaffer([Bind(Include = "last_name,first_name,father_name,birth_dt,email,phone_nbr")] DAL.Models.Staff staff)
    //    {
    //        DateTime dt;
    //        if (string.IsNullOrEmpty(staff.last_name)) ModelState.AddModelError("", "Фамилия: Поле обязательное");
    //        if (string.IsNullOrEmpty(staff.first_name)) ModelState.AddModelError("", "Имя: Поле обязательное");
    //        if (string.IsNullOrEmpty(staff.father_name)) ModelState.AddModelError("", "Отчество: Поле обязательное");
    //        if (staff.birth_dt == DateTime.MinValue) ModelState.AddModelError("", "Дата рождения: Поле обязательное");
    //        else if (!DateTime.TryParseExact(staff.birth_dt.ToShortDateString(), "M/d/yyyy", System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out dt)) ModelState.AddModelError("", "Дата рождения: Неверный формат");
    //        if (!string.IsNullOrEmpty(staff.email))
    //        {
    //            var regex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
    //                        @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
    //                        @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
    //            var re = new Regex(regex);
    //            if (!re.IsMatch(staff.email)) ModelState.AddModelError("", "Email: Неверный формат");
    //        }
    //        if (!string.IsNullOrEmpty(staff.phone_nbr))
    //        {
    //            var regex = @"^[0-9]+$";
    //            var re = new Regex(regex);
    //            if (!re.IsMatch(staff.phone_nbr)) ModelState.AddModelError("", "Контактный телефон: Неверный формат");
    //        }
    //        ViewBag.LastName = staff.last_name;
    //        ViewBag.FirstName = staff.first_name;
    //        ViewBag.FatherName = staff.father_name;
    //        ViewBag.BirthDt = staff.birth_dt;
    //        ViewBag.Email = staff.email;
    //        ViewBag.Phone = staff.phone_nbr;
    //    }
    //}
}