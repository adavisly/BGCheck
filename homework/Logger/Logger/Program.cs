using System;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "text.txt"; //"Logger\bin\Debug\net5.0\text.txt"

            LocalFileLogger<string> strLogger = new LocalFileLogger<string>(filePath);

            strLogger.LogInfo("LogInfoStr");
            strLogger.LogWarning("LogWarningStr");
            strLogger.LogError("LogErrorStr", new Exception());

            LocalFileLogger<int> intLogger = new LocalFileLogger<int>(filePath);

            intLogger.LogInfo("LogInfoInt");
            intLogger.LogWarning("LogWarningInt");
            intLogger.LogError("LogErrorInt", new Exception());

            
        }
    }
}
