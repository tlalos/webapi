using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace webapi.Infrastructure
{
    public class WebDBContext : DbContext
    {

        public WebDBContext() : base("name=MainDB")
        {

        }



    }
}