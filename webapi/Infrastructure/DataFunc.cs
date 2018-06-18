using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using webapi.Models;

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


            mSQL = "select * " +
                   "from expenses ";



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


        public bool mSaveExpenses(List<Expenses> expenses)
        {
            foreach (Expenses e in expenses)
            {
                string mSQL;
                mSQL = "insert into expenses " +
                       "(cdate,cyear,cmonth,comments,expensecodeid,value) " +
                       "values " +
                       "(" +
                       "'" + e.cdate + "'," +
                       "'" + e.cyear + "'," +
                       "'" + e.cmonth + "'," +
                       "'" + e.comments + "'," +
                       "'" + e.expensecodeid + "'," +
                       "'" + e.Value + "'" +
                       ")";

                webapi.Infrastructure.SQL.mCommand(mSQL, db.Database.Connection);
                 
            }

            return true;
        }


    }
}