using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace webapi.Infrastructure
{
    public class DataFunc
    {

        public WebDBContext db;


        public DataFunc(WebDBContext db)
        {

            this.db = db;
        }


        public DataTable mRet_ItemGroupDescr()
        {

            string mSQL;
            DataTable dt;

            mSQL = "select * from ms_param";

            
            dt = webapi.Infrastructure.SQL.mSelect(mSQL, db.Database.Connection);

            return dt;

        }


    }
}