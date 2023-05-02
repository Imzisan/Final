using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DeliveryManService
    {
        public static List<DeliveryManDTO> Get()
        {
            var data = DataAccessFactory.DeliveryManData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DeliveryMan, DeliveryManDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<DeliveryManDTO>>(data);
            return mapped;
        }

        public static DeliveryManDTO Get(string Uname)
        {
            var data = DataAccessFactory.DeliveryManData().Read(Uname);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DeliveryMan, DeliveryManDTO>();

            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<DeliveryManDTO>(data);
            return mapped;
        }


        public static bool Create(DeliveryManDTO deliveryman)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DeliveryManDTO, DeliveryMan>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<DeliveryMan>(deliveryman);
            var res = DataAccessFactory.DeliveryManData().Create(mapped);
            if (res) return true;
            return false;
        }

        public static bool Update(DeliveryManDTO deliveryman)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DeliveryManDTO, DeliveryMan>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<DeliveryMan>(deliveryman);
            var res = DataAccessFactory.DeliveryManData().Create(mapped);
            if (res) return true;
            return false;
        }
        public static bool Delete(string Uname)
        {
            return DataAccessFactory.DeliveryManData().Delete(Uname);
        }
        public static bool ChangePassword(string Uname, ChangePasswordDTO changePasswordDTO)
        {
            var deliveryman = DataAccessFactory.DeliveryManData().Read(Uname);
            if (changePasswordDTO.CurrentPassword == deliveryman.Password)
            {
                return DataAccessFactory.ChangePassData().ChangePassword(deliveryman.Uname, changePasswordDTO.Password);
            }
            return false;
        }
    }
}
