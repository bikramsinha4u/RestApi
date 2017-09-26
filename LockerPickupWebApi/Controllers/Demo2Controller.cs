using AutoMapper;
using LockerPickupDAL.Models;
using LockerPickupDAL.Services;
using LockerPickupDTO;
using LockerPickupWebApi.Helpers;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LockerPickupWebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/demo2")]
    public class Demo2Controller : ApiController
    {
        private readonly IDemoService _demoService;

        public Demo2Controller()
        {

        }

        public Demo2Controller(IDemoService demoService)
        {
            _demoService = demoService;
        }

        [HttpGet]
        [VersionedRoute("orders/{groupId}/orderDetails/{id}", 1)]
        [VersionedRoute("orders/orderDetails/{id}", 1)]
        public IHttpActionResult Get(int id, int? groupId)
        {
            try
            {
                var orderDetails = new List<OrdersDetailsData>();
                orderDetails = _demoService.GetOrderDetails(id, groupId);

                if (orderDetails == null)
                {
                    return NotFound();
                }

                var result = Mapper.Map<List<OrdersDetailsDTO>>(orderDetails);

                return Ok(result.FirstOrDefault(r => r.Id == id));
            }
            catch (Exception ex)
            {

                return InternalServerError();
            }
        }
        /// <summary>
        /// put in request header:
        /// Accept: application/vnd.lockerpickupwebapi.v2+json
        /// or
        /// api-version: 2
        /// </summary>
        /// <param name="id"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpGet]
        [VersionedRoute("orders/{groupId}/orderDetails/{id}", 2)]
        [VersionedRoute("orders/orderDetails/{id}", 2)]
        public IHttpActionResult GetV2(int id, int? groupId)
        {
            try
            {
                var orderDetails = new List<OrdersDetailsData>();
                orderDetails = _demoService.GetOrderDetails(id, groupId);

                if (orderDetails == null)
                {
                    return NotFound();
                }

                var result = Mapper.Map<List<OrdersDetailsDTO>>(orderDetails);

                return Ok(result.FirstOrDefault(r => r.Id == id));
            }
            catch (Exception ex)
            {

                return InternalServerError();
            }
        }
    }
}