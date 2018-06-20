using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Text;

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
            JSONString = JsonConvert.SerializeObject(table, Formatting.Indented);
            return JSONString;
        }

        public static string DataTableToJSONWithJavaScriptSerializer(DataTable table)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return jsSerializer.Serialize(parentRow);
        }



        public static string DataTableToJsonWithStringBuilder(DataTable table)
        {
            var jsonString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                jsonString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    jsonString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            jsonString.Append("\"" + table.Columns[j].ColumnName.ToString()
                                              + "\":" + "\""
                                              + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            jsonString.Append("\"" + table.Columns[j].ColumnName.ToString()
                                              + "\":" + "\""
                                              + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        jsonString.Append("}");
                    }
                    else
                    {
                        jsonString.Append("},");
                    }
                }
                jsonString.Append("]");
            }
            return jsonString.ToString();
        }




    }



}