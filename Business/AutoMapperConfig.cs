using AutoMapper;
using Business.Models;
using DAL.Models;

namespace Business
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Staff, StaffModel>();
            });
        }
    }
}