using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace webapi.Infrastructure
{
    public static class SQL
    {
        public static DataTable mSelect(string mSQL, DbConnection mCon)
        {
            DataTable dt = new DataTable();


            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");

            DbDataAdapter mAdapter = factory.CreateDataAdapter();
            DbCommand mDBCommand = mCon.CreateCommand();

            mDBCommand.Connection = mCon;
            mDBCommand.CommandText = mSQL;


            mAdapter.SelectCommand = mDBCommand;
            mAdapter.Fill(dt);


            return dt;

        }

        public static Boolean mCommand(string mSQL, DbConnection mCon)
        {

            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");

            DbDataAdapter mAdapter = factory.CreateDataAdapter();
            DbCommand mDBCommand = mCon.CreateCommand();

            mDBCommand.Connection = mCon;
            mDBCommand.CommandText = mSQL;

            mDBCommand.ExecuteNonQuery();
            mDBCommand.Dispose();

            return true;
        }


        public static string DataTableToJSONWithJSONNet(DataTable table)
        {
            
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }


    }

}