using System;

namespace NUnitSeleniumTestProjectExample.Helpers
{
    public static class Logger
    {
        public static int logLevel;
        private enum MessageTypes : int
        {
            Fatal = 0,
            Error = 1,
            Warning = 2,
            Info = 3,
            Debug = 4
        }

        private static void logMessage(MessageTypes type, string message)
        {
            switch (type)
            {
                case MessageTypes.Fatal:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case MessageTypes.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case MessageTypes.Warning:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case MessageTypes.Info:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case MessageTypes.Debug:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
            if ((int)type >= logLevel) 
            {
                Console.WriteLine (type.ToString() + ": " + message);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            
        }

        public static void LogInfo(string message)
        {
            logMessage(MessageTypes.Info, message);
        }

        public static void LogWarning (string message)
        {
            logMessage(MessageTypes.Warning, message);
        }

        public static void LogError (string message)
        {
            logMessage(MessageTypes.Error, message);
        }

        public static void LogDebug (string message)
        {
            logMessage(MessageTypes.Debug, message);
        }

        public static void LogFatal (string message)
        {
            logMessage(MessageTypes.Fatal, message); 
        }
        
    }
}