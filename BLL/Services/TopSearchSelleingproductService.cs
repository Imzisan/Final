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
    public class TopSearchSelleingproductService
    {
        public static List<TopSearchSelleingproductDTO> Get()
        {
            var data = DataAccessFactory.TopSearchSelleingproductdata().Read();
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TopSearchSelleingproduct,TopSearchSelleingproductDTO>();
            });
            var mapper = new Mapper(config);
            var mapped = mapper.Map<List<TopSearchSelleingproductDTO>>(data);
            return mapped;
        }

        public static TopSearchSelleingproductDTO Get(string id)
        {
            var data = DataAccessFactory.TopSearchSelleingproductdata().Read(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TopSearchSelleingproduct,TopSearchSelleingproductDTO>();
            });
            var mapper = new Mapper(config);
            var mapped = mapper.Map<TopSearchSelleingproductDTO>(data);
            return mapped;
        }

        public static bool Create(TopSearchSelleingproductDTO search)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TopSearchSelleingproductDTO, TopSearchSelleingproduct>();
            });
            var mapper = new Mapper(config);
            var mapped = mapper.Map<TopSearchSelleingproduct>(search);
            var res = DataAccessFactory.TopSearchSelleingproductdata().Create(mapped);
            if (res != null) return true;
            return false;
        }

        public static TopSearchSelleingproduct Update(TopSearchSelleingproductDTO tSelleingProduct)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<TopSearchSelleingproductDTO, TopSearchSelleingproduct>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<TopSearchSelleingproduct>(tSelleingProduct);
            var res = DataAccessFactory.TopSearchSelleingproductdata().Update(mapped);
            return mapped;
        }

        public static bool Delete(string TopProductName)
        {
            return DataAccessFactory.TopSearchSelleingproductdata().Delete(TopProductName);
        }

    }
}

