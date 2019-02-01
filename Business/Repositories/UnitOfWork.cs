using System;
using DAL;
using DAL.Models;

namespace Business.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private EntityContext Context { get; set; }

        public UnitOfWork()
        {
            Context = new EntityContext();
        }

        public IRepository<Staff> Staffs
        {
            get { return new EFRepository<Staff>(Context); }
        }

        public IStaffRepository ValidateStaffer
        {
            get { return new StaffRepository(Context); }
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //private Staff _staff;
        //public Staff Staff
        //{
        //    get
        //    {
        //        if (_staff == null) _staff = new Staff(_context);
        //        return _staff;
        //    }
        //}
        //private Subject _subject;
        //public Subject Subject
        //{
        //    get
        //    {
        //        if (_subject == null) _subject = new Subject(entities);
        //        return _subject;
        //    }
        //}
    }
}