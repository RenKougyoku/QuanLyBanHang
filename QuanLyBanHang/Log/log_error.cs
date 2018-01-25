using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Log
{
    public class log_error
    {
        public void WriteLogError(string strLog)
        {
            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;

            string logFilePath = "D:\\Project\\QuanLyBanHang\\QuanLyBanHang\\Log\\Error\\";
            logFilePath = logFilePath + "log-error-" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            log = new StreamWriter(fileStream);

            string time = DateTime.Now.ToString("HH:mm:ss");


            string date =  DateTime.Today.ToString("dd-MM-yyyy");
            string datetime = date + " :: " + time;
            log.WriteLine(datetime + " : " + strLog);
            log.Close();
        }
        public void WriteLogSystem(string strLog)
        {
            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;

            string logFilePath = "D:\\Project\\QuanLyBanHang\\QuanLyBanHang\\Log\\System\\";
            logFilePath = logFilePath + "log-system-" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            log = new StreamWriter(fileStream);

            string time = DateTime.Now.ToString("HH:mm:ss");


            string date = DateTime.Today.ToString("dd-MM-yyyy");
            string datetime = date + " :: " + time;
            log.WriteLine(datetime + " : " + strLog);
            log.Close();
        }
        public void WriteLogDatabase(string strLog)
        {
            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;

            string logFilePath = "D:\\Project\\QuanLyBanHang\\QuanLyBanHang\\Log\\Data\\";
            logFilePath = logFilePath + "log-data-" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            log = new StreamWriter(fileStream);

            string time = DateTime.Now.ToString("HH:mm:ss");


            string date = DateTime.Today.ToString("dd-MM-yyyy");
            string datetime = date + " :: " + time;
            log.WriteLine(datetime + " : " + strLog);
            log.Close();
        }
    }
}
