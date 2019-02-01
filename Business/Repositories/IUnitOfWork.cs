using DAL.Models;

namespace Business.Repositories
{
    public interface IUnitOfWork
    {
        void SaveChanges();

        IRepository<Staff> Staffs { get; }
        //IRepository<Subject> Subject { get; }

        IStaffRepository ValidateStaffer { get; }
    }
}