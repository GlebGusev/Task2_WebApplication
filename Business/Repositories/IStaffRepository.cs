using Business.Models;

namespace Business.Repositories
{
    public interface IStaffRepository : IRepository
    {
        void ValidateStaffer(StaffModel staff);
    }
}