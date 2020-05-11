#region Using ...
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Diagnostics;
using Framework.Core.Common;
using Framework.Common.Enums;
#endregion

namespace MersalAccountingService.BusinessLogic.Common
{
    /// <summary>
    /// Specify a functionality to 
    /// log any thing in a log.
    /// </summary>
    public class LoggerService : ILoggerService
    {
        #region Data Members
        private readonly string _rootPath;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type LoggerService.
        /// </summary>
        public LoggerService()
        {
            this._rootPath = HttpContext.Current.Server.MapPath("~/logs");
        }
        #endregion

        #region ILoggerService
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="type"></param>
        public void Log(string content, LogType type)
        {
            DateTime now = DateTime.Now;

            try
            {
                if (Directory.Exists(this._rootPath) == false)
                    Directory.CreateDirectory(this._rootPath);

                string yearFolderPath = $"{this._rootPath}\\{now.Year}";
                if (Directory.Exists(yearFolderPath) == false)
                    Directory.CreateDirectory(yearFolderPath);

                string monthFolderPath = $"{this._rootPath}\\{now.Year}\\{now.Month}";
                if (Directory.Exists(monthFolderPath) == false)
                    Directory.CreateDirectory(monthFolderPath);

                string dayFolderPath = $"{this._rootPath}\\{now.Year}\\{now.Month}\\{now.Day}";
                if (Directory.Exists(dayFolderPath) == false)
                    Directory.CreateDirectory(dayFolderPath);

                string filePath = $"{_rootPath}\\{now.Year}\\{now.Month}\\{now.Day}\\{now.ToLongTimeString().Replace(":", "-")}-{LogType.Error.ToString()}.log";
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (StreamWriter wr = new StreamWriter(fs))
                    {
                        wr.WriteLine(content);
                        wr.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    #region Log Exception in EventLog
                    EventLog eventLog = new EventLog(this.GetType().FullName, System.Environment.MachineName);

                    eventLog.WriteEntry(ex.ToString(), EventLogEntryType.Error); 
                    #endregion
                }
                catch { }
            }
        }
        #endregion
    }
}
