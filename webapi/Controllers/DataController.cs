using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi.Infrastructure;
using webapi.Models;

namespace webapi.Controllers
{

    public class DataController : ApiController
    {
        private WebDBContext db;

        

        Product[] products = new Product[]
     {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M },
            new Product { Id = 4, Name = "Software", Category = "Software", Price = 16.99M }
     };

        public DataController()
        {
            db = new WebDBContext();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        
        
        [HttpGet]
        public IHttpActionResult Get_TestData()
        {

            DataFunc erpfunc = new DataFunc(db);

            
            DataTable dt2;
            dt2 = erpfunc.mRet_ItemGroupDescr();


            
            DataSet ds = new DataSet();
            ds.Tables.Add(dt2);
            //ds.Tables.Add(dt2);

            //return Ok(mRv);
            //return Ok(dt);
            return Ok(ds);

        }



    }
}
