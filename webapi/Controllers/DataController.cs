﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using webapi.Infrastructure;
using webapi.Models;


namespace webapi.Controllers
{

    public class DataController : ApiController
    {
        private WebDBContext db;

        

        public DataController()
        {
            db = new WebDBContext();
            
            db.Database.Connection.Open(); 
        }
        protected override void Dispose(bool disposing)
        {
            db.Database.Connection.Close();
            db.Dispose();
        }



        [HttpGet]
        public IHttpActionResult GetData()

        {

            return Ok();
            
        }


        [HttpGet]
        public HttpResponseMessage GetMobileData(string requestcode,string deviceCode,string param)
        {


            DataFunc erpfunc = new DataFunc(db);
            DataTable dt=null;
            

            if (requestcode.ToLower() == "allcustomers")
            {
                dt = erpfunc.mRet_Persons();
            }

            else if (requestcode.ToLower() == "singlecustomer")
            {
                dt = erpfunc.mRet_Persons_FromCode(param);
            }

            else if (requestcode.ToLower() == "expenses")
            {
                dt = erpfunc.mRetExpenses();
            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Request not found");
            }
    
                        
            string retval = SQL.DataTableToJSONWithJSONNet(dt);
            
            var resp = new HttpResponseMessage { Content = new StringContent(retval, System.Text.Encoding.UTF8, "application/json") };

            return resp;


        }



        [HttpPost]
        [Route("api/data/PostExpensesData")]
        public HttpResponseMessage PostExpensesData([FromBody] List<Expenses> p)
        {
            DataFunc erpfunc = new DataFunc(db);
            erpfunc.mSaveExpenses(p);

            string retval = "[{result:'ok'}]";

            var resp = new HttpResponseMessage { Content = new StringContent(retval, System.Text.Encoding.UTF8, "application/json") };

            return resp;

        }


        [HttpPost]
        [Route("api/data/PostExpenseTypeData")]
        public HttpResponseMessage PostExpenseTypeData([FromBody] List<ExpenseType> p)
        {
            DataFunc erpfunc = new DataFunc(db);
            erpfunc.mSaveExpenseType(p);

            string retval = "[{result:'ok'}]";

            var resp = new HttpResponseMessage { Content = new StringContent(retval, System.Text.Encoding.UTF8, "application/json") };

            return resp;

        }
    }

}
