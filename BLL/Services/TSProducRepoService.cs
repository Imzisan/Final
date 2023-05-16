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
    public  class TSProducRepoService
    {
        public static List<ProductDTO> Get()
        {
            var data = DataAccessFactory.TProductdata().Read();
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(config);
            var mapped = mapper.Map<List<ProductDTO>>(data);
            return mapped;
        }

        public static ProductDTO Get(string product)
        {
            var data = DataAccessFactory.TProductdata().Read(product);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(config);
            var mapped = mapper.Map<ProductDTO>(data);
            return mapped;
        }

    }
}

