using AutoMapper;
using LockerPickupDAL.Data;
using LockerPickupDAL.Models;
using LockerPickupDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LockerPickupWebApi.Tests.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            LockerPickupMap();
        }

        private static void LockerPickupMap()
        {
            Mapper.CreateMap<OrdersDTO, OrdersData>();
            Mapper.CreateMap<OrdersData, OrdersDTO>();
            Mapper.CreateMap<OrdersDetailsDTO, OrdersDetailsData>();
            Mapper.CreateMap<OrdersDetailsData, OrdersDetailsDTO>();
        }
    }
}