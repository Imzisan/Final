using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public  class SellerReviewService
    {
        public static UserSellerReviewDTO GetwithSelleReview(int id)
        {
            var data = DataAccessFactory.ManageUserData().GetAll(id);
            var cfg = new MapperConfiguration(c =>
            {

                c.CreateMap<User, UserSellerReviewDTO>();
                c.CreateMap<SellerReview, SellerReviewDTO>();

            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<UserSellerReviewDTO>(data);
            return mapped;
        }

        public static SellerReviewDTO Get(int id)
        {
            var data = DataAccessFactory.SellerReviewdata().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<SellerReview, SellerReviewDTO>();



            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<SellerReviewDTO>(data);
            return mapped;
        }
    }
}
