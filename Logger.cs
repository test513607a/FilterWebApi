using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FilterWebApi
{
    public static class Logger
    {
        public static void WriteLogFile(string str)
        {
            try
            {
                if (!String.IsNullOrEmpty(str))
                {
                    try
                    {
                        string filename = DateTime.Now.ToString("MMMddyyyy");
                        string todaysfilepath = System.Web.HttpContext.Current.Server.MapPath(@"~/Logger/Log_" + filename + ".txt");
                        if (!File.Exists(todaysfilepath))
                        {
                            File.Create(todaysfilepath).Close();
                        }


                        using (StreamWriter sw = File.AppendText(todaysfilepath))
                        {
                            //sw.WriteLine("#");
                            sw.WriteLine(DateTime.Now.ToString() +"  "+ str);
                           

                        }

                    }
                    catch (Exception ex) { throw; }

                }
            }
            catch
            {

                throw;
            }

        }
    }
}