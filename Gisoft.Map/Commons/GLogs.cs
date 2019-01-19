using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Gisoft.Map.Commons
{
    /// <summary>
    /// 日志
    /// </summary>
    public class GLogs
    {
        public static string path = AppDomain.CurrentDomain.BaseDirectory + "Logs";

        public bool showOnConsole;
        GLogs()
        {
            LogLevel = 3;
            showOnConsole = true;
        }
        private static object _locker = new object();
        private static GLogs _mapLog;

        public static GLogs Instance
        {
            get
            {
                lock (_locker)
                {
                    if (_mapLog == null)
                    {
                        _mapLog = new GLogs();
                    }
                    return _mapLog;
                }
            }
        }

        public int LogLevel
        {
            get;
            set;
        }
        /**
         * 向日志文件写入调试信息
         * @param className 类名
         * @param content 写入内容
         */
        public void Debug(string className, string content)
        {
            if (LogLevel >= 3)
            {
                WriteLog("DEBUG", className, content);
            }

        }

        /**
        * 向日志文件写入运行时信息
        * @param className 类名
        * @param content 写入内容
        */
        public void Info(string className, string content)
        {
            if (LogLevel >= 2)
            {
                WriteLog("INFO", className, content);
            }
        }

        /**
        * 向日志文件写入出错信息
        * @param className 类名
        * @param content 写入内容
        */
        public void Error(string className, string content)
        {
            if (LogLevel >= 1)
            {
                WriteLog("ERROR", className, content);
            }
        }

        /**
        * 实际的写日志操作
        * @param type 日志记录类型
        * @param className 类名
        * @param content 写入内容
        */
        public void WriteLog(string type, string className, string content)
        {
            lock (_fileLocker)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");//获取当前系统时间
                string filename = path + "/MapLog_" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";//用日期对日志文件命名

                //创建或打开日志文件，向日志文件末尾追加记录
                StreamWriter mySw = File.AppendText(filename);

                //向日志文件写入内容
                string write_content = time + " " + type + " " + className + ": " + content;
                mySw.WriteLine(write_content);

                //关闭日志文件
                mySw.Close();

                if (showOnConsole)
                {
                    Console.WriteLine("MapLog" + write_content);
                }
            }
        }

        private object _fileLocker = new object();
    }
}
