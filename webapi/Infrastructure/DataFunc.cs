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

            mSQL = "select " +
                   "id,descr as body,recdate as date,itemcode as preview,prpid as title,'' as url,'author' as author,'tags' as tags " +
                   "from ms_prdata " +
                   "where isnull(fdate, 0) <> 0";

            
            dt = webapi.Infrastructure.SQL.mSelect(mSQL, db.Database.Connection);
            ////
            return dt;

        }


    }
}