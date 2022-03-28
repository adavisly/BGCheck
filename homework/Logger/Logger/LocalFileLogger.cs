using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Logger
{
    class LocalFileLogger<T> : ILogger
    {
        private string filePath;

        public LocalFileLogger(string filePath)
        {
            this.filePath = filePath;
        }

        private string GenericTypeName = typeof(T).Name;

        public void LogInfo(string message)
        {
            File.AppendAllText(filePath, $"[Info] : [{GenericTypeName}] : {message}\n");
        }

        public void LogWarning(string message)
        {
            File.AppendAllText(filePath, $"[Warning] : [{GenericTypeName}] : {message}\n");
        }

        public void LogError(string message, Exception ex)
        {
            File.AppendAllText(filePath, $"[Error] : [{GenericTypeName}] : {message}. {ex.Message}\n");
        }
    }
}
