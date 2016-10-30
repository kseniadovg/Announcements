using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class RecordModelController : ApiController
    {
        public static List<RecordModel> Products = new List<RecordModel>()
        {
            new RecordModel {Id = 1, Name = "Tomato Soup", Data = "Groceries"},
            new RecordModel {Id = 2, Name = "Yo-yo", Data = "Toys"},
            new RecordModel {Id = 3, Name = "Hammer", Data = "Hardware"}
        };

        public IEnumerable<RecordModel> GetAllProducts()
        {
            return Products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = Products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public void AddRecord([FromBody]RecordModel record)
        {
            Products.Add(record);
        }
    }
}
