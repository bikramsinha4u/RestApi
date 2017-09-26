using AutoMapper;
using LockerPickupDAL.Models;
using LockerPickupDAL.Services;
using LockerPickupDTO;
using LockerPickupWebApi.Helpers;
using Marvin.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LockerPickupWebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/demo")]
    public class DemoController : ApiController
    {
        private readonly IDemoService _demoService;

        public DemoController()
        {

        }

        public DemoController(IDemoService demoService)
        {
            _demoService = demoService;
        }

        /// <summary>
        /// Adds paging information to the response header as it is a meta data
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("orders", Name = "OrdersList")]
        public IHttpActionResult Get(string sort = "id", string fields = null, string userId = null, int page = 1, int pageSize = 3)
        {
            try
            {
                List<string> lstOfFields = new List<string>();

                if (fields != null)
                {
                    lstOfFields = fields.ToLower().Split(',').ToList();
                }

                var data = _demoService.GetOrders();
                var ordersList = Mapper.Map<List<OrdersDTO>>(data);
                var result = ordersList.AsQueryable().ApplySort(sort).Where(eg => (userId == null || eg.Id.ToString() == userId));

                // Calculate data to paging metadata
                var totalCount = result.Count();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var urlHelper = new System.Web.Http.Routing.UrlHelper(Request);
                var prevLink = page > 1 ? urlHelper.Link("OrdersList",
                    new
                    {
                        page = page - 1,
                        pageSize = pageSize,
                        sort = sort,
                        fields = fields,
                        userId = userId
                    }) : "";
                var nextLink = page < totalPages ? urlHelper.Link("OrdersList",
                    new
                    {
                        page = page + 1,
                        pageSize = pageSize,
                        sort = sort,
                        fields = fields,
                        userId = userId
                    }) : "";


                var paginationHeader = new
                {
                    currentPage = page,
                    pageSize = pageSize,
                    totalCount = totalCount,
                    totalPages = totalPages,
                    previousPageLink = prevLink,
                    nextPageLink = nextLink
                };

                System.Web.HttpContext.Current.Response.Headers.Add("X-Pagination",
                    Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));
                //var response = Request.CreateResponse();
                //response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));
                // Ends Calculate data to paging metadata  

                return Ok(result.Select(exp => LockerPickupWebApi.Helpers.OrdersFactory.CreateDataShapedObject(exp, lstOfFields)).Skip(pageSize * (page - 1)).Take(pageSize));
            }
            catch (Exception ex)
            {

                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("orders/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var data = _demoService.GetOrders(id);
                var result = Mapper.Map<OrdersDTO>(data);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {

                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("orders")]
        public IHttpActionResult Post([FromBody]OrdersDTO ordersDTO)
        {
            try
            {
                if (ordersDTO == null)
                {
                    return BadRequest();
                }

                var ordersData = Mapper.Map<OrdersData>(ordersDTO);
                var data = _demoService.CreateOrders(ordersData);

                if (data != null)
                {
                    var result = Mapper.Map<OrdersDTO>(data);
                    return Created(Request.RequestUri + "/" + result.Id.ToString(), result);
                }

                return BadRequest();

            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

        [HttpPut]
        [Route("orders/{id}")]
        public IHttpActionResult Put(int id, [FromBody]OrdersDTO ordersDTO)
        {
            try
            {
                if (ordersDTO == null)
                {
                    return BadRequest();
                }

                var ordersData = Mapper.Map<OrdersData>(ordersDTO);
                var data = _demoService.UpdateOrders(ordersData);

                if (data != null)
                {
                    var result = Mapper.Map<OrdersDTO>(data);
                    return Ok(result);
                }

                return NotFound();

            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }
        /// <summary>
        /// http://localhost/LockerPickupWebApi/api/Demo/1
        /// [
        ///     {
        ///         "op": "replace",
        ///         "path": "/name",
        ///         "value": "Benjamin"
        ///     }
        /// ]
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ordersDTO"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("orders/{id}")]
        public IHttpActionResult Put(int id, [FromBody]JsonPatchDocument<OrdersDTO> ordersDTO)
        {
            try
            {
                if (ordersDTO == null)
                {
                    return BadRequest();
                }

                var data = _demoService.GetOrders(id);
                var result = Mapper.Map<OrdersDTO>(data);

                ordersDTO.ApplyTo(result);

                var ordersData = Mapper.Map<OrdersData>(result);
                var updatedData = _demoService.UpdateOrders(ordersData);

                if (updatedData != null)
                {
                    var finalResult = Mapper.Map<OrdersDTO>(data);
                    return Ok(finalResult);
                }

                return NotFound();

            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

        [HttpDelete]
        [Route("orders/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var data = _demoService.DeleteOrders(id);

                if (data != null)
                {
                    return StatusCode(System.Net.HttpStatusCode.NoContent);
                }
                else if (data == null)
                {
                    return NotFound();
                }

                return BadRequest();
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

    }
}
