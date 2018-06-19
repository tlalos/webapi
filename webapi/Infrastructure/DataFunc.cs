﻿using System;
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


        public DataTable mRetExpenses()
        {

            string mSQL;
            DataTable dt;

            mSQL = "select " +
                   "CONVERT(VARCHAR(10), e.cdate, 103) as cdate, " +
                   "e.cyear,e.cmonth, " +
                   "e.expensecodeid,et.descr as expensedescr, " +
                   "isnull(e.comments, '') as comments, " +
                   "cast(isnull(e.value,0) as varchar(10)) as value," +
                   "e.guid " +
                   "from expenses e " +
                   "left join expensetype et on et.codeid = e.expensecodeid";

            
            dt = webapi.Infrastructure.SQL.mSelect(mSQL, db.Database.Connection);
            ////
            return dt;

        }



        public bool mSaveExpenses(List<Expenses> expenses)
        {
            foreach (Expenses e in expenses)
            {
                if (e.deleted==0)
                {
                    DataTable dt;
                    dt = SQL.mSelect("select id from expenses where guid='" + e.guid + "'", db.Database.Connection);
                    if (dt.Rows.Count == 0)
                    {


                        string mSQL;
                        mSQL = "insert into expenses " +
                               "(cdate,cyear,cmonth,comments,expensecodeid,value,guid) " +
                               "values " +
                               "(" +
                               "convert(datetime,'" + Convert.ToDateTime(e.cdate).ToString("dd/MM/yyyy") + "',103)," +
                               "'" + e.cyear + "'," +
                               "'" + e.cmonth + "'," +
                               "'" + e.comments + "'," +
                               "'" + e.expensecodeid + "'," +
                               "'" + e.Value.ToString().Replace(",", ".") + "'," +
                               "'" + e.guid + "' " +
                               ")";

                        SQL.mCommand(mSQL, db.Database.Connection);
                    }
                    else
                    {
                        string mSQL;
                        mSQL = "update expenses " +
                               "set " +
                               "cdate=convert(datetime,'" + Convert.ToDateTime(e.cdate).ToString("dd/MM/yyyy") + "', 103)," +
                               "cyear='" + e.cyear + "'," +
                               "cmonth='" + e.cmonth + "'," +
                               "comments='" + e.comments + "'," +
                               "expensecodeid='" + e.expensecodeid + "'," +
                               "value='" + e.Value.ToString().Replace(",", ".") + "' " +
                               "where id=" + dt.Rows[0]["id"];

                        SQL.mCommand(mSQL, db.Database.Connection);
                    }


                }
                else //delete marked for deletion
                {
                    SQL.mCommand("delete from expenses where guid='"+e.guid+"'", db.Database.Connection);
                }
            }
                

            return true;
        }


        public bool mSaveExpenseType(List<ExpenseType> expensetype)
        {
            foreach (ExpenseType e in expensetype)
            {

                if (e.deleted == 0)
                {
                    DataTable dt;
                    dt = SQL.mSelect("select id from expensetype where codeid='" + e.codeid + "'", db.Database.Connection);

                    if (dt.Rows.Count == 0)
                    {
                        string mSQL;
                        mSQL = "insert into expensetype " +
                               "(codeid,descr) " +
                               "values " +
                               "(" +
                               "'" + e.codeid + "'," +
                               "'" + e.descr + "' " +
                               ")";

                        SQL.mCommand(mSQL, db.Database.Connection);
                    }
                    else
                    {
                        string mSQL;
                        mSQL = "update expensetype " +
                               "set " +
                               "descr='" + e.descr + "' " +
                               "where id=" + dt.Rows[0]["id"];

                        SQL.mCommand(mSQL, db.Database.Connection);
                    }
                }
                else //delete marked for deletion
                {
                    SQL.mCommand("delete from expensetype where codeid='" + e.codeid + "'", db.Database.Connection);
                }

                

            }

            return true;
        }




    }
}