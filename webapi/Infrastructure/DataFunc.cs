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


        public DataTable mRet_Persons()
        {

            string mSQL;
            DataTable dt;
            
            mSQL = "select top 4 " +
                   "id,per_code as code,per_descr as name," +
                   "per_address as address " +
                   "from ms_persons ";



            dt = webapi.Infrastructure.SQL.mSelect(mSQL, db.Database.Connection);
            ////
            return dt;

        }

        public DataTable mRet_Persons_FromCode(string code)
        {

            string mSQL;
            DataTable dt;

            mSQL = "select " +
                   "id,per_code as code,per_descr as name," +
                   "per_address as address " +
                   "from ms_persons "+
                   "where per_code='"+code+"'";



            dt = webapi.Infrastructure.SQL.mSelect(mSQL, db.Database.Connection);
            ////
            return dt;

        }



    }
}