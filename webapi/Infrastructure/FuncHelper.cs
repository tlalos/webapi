using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace webapi.Infrastructure
{
    public class FuncHelper
    {
        static string path = System.Web.HttpContext.Current.Server.MapPath("~/logging.log");

        public static TextWriterTraceListener logListener = new TextWriterTraceListener(path, "Expenses Logging" );
        

        

        public static void Log(string logEntry,string module,string comments)
        {

            string d=DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            if (comments == "")
                Trace.WriteLine(d + "[" + module + "]" + logEntry);
            else
                Trace.WriteLine(d + "[" + module + "]("+comments+")" + logEntry);

            Trace.Flush();
            Trace.Close();

        }



    }

    

}