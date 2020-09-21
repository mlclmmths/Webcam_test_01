using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Webcam_WS
{
    public class Logger
    {
        private static string logFolderPath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
        private static string logFile = logFolderPath + "\\Log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
        //private string path = AppDomain.CurrentDomain.BaseDirectory + "\\Log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

        // dateFormat = 2018-04-06 3:09:38 PM
        private static string dateTimeInFormat = DateTime.Now.ToString("yyyy'-'MM'-'dd h:mm:ss tt");

        private static object FileLock = new object();

        public static void Log(Exception ex)
        {
            lock (FileLock)
            {
                //StreamWriter sw = null;
                try
                {
                    /* installer */
                    ////var datetoday = DateTime.Now.ToString();
                    ////string path = AppDomain.CurrentDomain.BaseDirectory + "\\Log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

                    //StreamWriter sw = new StreamWriter(logFile, true);
                    ////sw = new StreamWriter(path, true);

                    //sw.WriteLine(dateTimeInFormat + ": " + ex.Source.ToString().Trim() + "; " + ex.Message.ToString().Trim());
                    ////sw.WriteLine(DateTime.Now.ToString("yyyy'-'MM'-'dd h:mm:ss tt") + ": " + ex.Source.ToString().Trim() + "; " + ex.Message.ToString().Trim());

                    //sw.Flush();
                    //sw.Close();

                    /* testing */
                    string logText = dateTimeInFormat + ": " + ex.Source.ToString().Trim() + "; " + ex.Message.ToString().Trim();
                    using (FileStream fs = new FileStream(logFile, FileMode.Append, FileAccess.Write, FileShare.Read))
                    {
                        byte[] data = System.Text.Encoding.ASCII.GetBytes(logText + "\r\n");
                        fs.Write(data, 0, data.Length);
                        fs.Flush();
                        fs.Close();
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
            }
        }

        public static void Log(string msg)
        {
            lock (FileLock)
            {
                //StreamWriter sw = null;
                try
                {
                    /* installer */
                    ////string path = AppDomain.CurrentDomain.BaseDirectory + "\\Log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

                    //StreamWriter sw = new StreamWriter(logFile, true);
                    ////sw = new StreamWriter(path, true);

                    //sw.WriteLine(dateTimeInFormat + ": " + msg);
                    ////sw.WriteLine(DateTime.Now.ToString("yyyy'-'MM'-'dd h:mm:ss tt") + ": " + msg);

                    //sw.Flush();
                    //sw.Close();

                    /* testing */
                    string logText = dateTimeInFormat + ": " + msg;
                    using (FileStream fs = new FileStream(logFile, FileMode.Append, FileAccess.Write, FileShare.Read))
                    {
                        byte[] data = System.Text.Encoding.ASCII.GetBytes(logText + "\r\n");
                        fs.Write(data, 0, data.Length);
                        fs.Flush();
                        fs.Close();
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
            }
        }
    }
}
