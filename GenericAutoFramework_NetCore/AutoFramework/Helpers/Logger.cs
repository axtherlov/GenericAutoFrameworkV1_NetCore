﻿using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using log4net;
using log4net.Config;

namespace AutoFramework.Helpers
{
    public static class Logger
    {
        private static ILog _log;

        public static void LogInfo(string message, [CallerFilePath] string path = @"C:\Unknown.cs",
            [CallerLineNumber] int line = 0, [CallerMemberName] string method = ""
        )
        {   
            EnsureLogger();
            _log.Info(PrefixLog(path, line, method, message));
        }

        public static void LogDebug(string message, [CallerFilePath] string path = @"C:\Unknown.cs",
            [CallerLineNumber] int line = 0, [CallerMemberName] string method = ""
        )
        {   
            EnsureLogger();
            _log.Debug(PrefixLog(path, line, method, message));
        }

        public static void LogWarn(string message, [CallerFilePath] string path = @"C:\Unknown.cs",
            [CallerLineNumber] int line = 0, [CallerMemberName] string method = ""
        )
        {   
            EnsureLogger();
            _log.Warn(PrefixLog(path, line, method, message));
        }

        public static void LogError(string message, [CallerFilePath] string path = @"C:\Unknown.cs",
            [CallerLineNumber] int line = 0, [CallerMemberName] string method = ""
        )
        {   
            EnsureLogger();
            _log.Error(PrefixLog(path, line, method, message));
        }

        public static void LogFatal(string message, [CallerFilePath] string path = @"C:\Unknown.cs",
            [CallerLineNumber] int line = 0, [CallerMemberName] string method = ""
        )
        {   
            EnsureLogger();
            _log.Fatal(PrefixLog(path, line, method, message));
        }

        public static void LogIn(string message, [CallerFilePath] string path = @"C:\Unknown.cs",
            [CallerLineNumber] int line = 0, [CallerMemberName] string method = "")
        {
            EnsureLogger();
            message = $">>>>>>>>>> {message} >>>>>>>>>>";
            _log.Debug(message);
        }

        public static void LogOut(string message = "",[CallerFilePath] string path = @"C:\Unknown.cs", 
            [CallerLineNumber] int line = 0,[CallerMemberName] string method = "")
        {
            EnsureLogger();
            message = $"<<<<<<<<<< {message} <<<<<<<<<<";
            _log.Debug(message);
        }

        public static void LogException(Exception exception, [CallerFilePath] string path = @"C:\Unknown.cs",
            [CallerLineNumber] int line = 0, [CallerMemberName] string method = "")
        {
            EnsureLogger();
            string extraLogLevel = "[EXCEPTION]";
            _log.Error(PrefixLog(path, line, method, exception.Message, extraLogLevel));
            
            while (exception.InnerException != null)
            {
                extraLogLevel = "[INNER EXCEPTION]";
                exception = exception.InnerException;
                _log.Error(PrefixLog(path, line, method, exception.Message, extraLogLevel));
            }
        }

        private static string PrefixLog(string path, int line, string method, string message, string extraLogLevel = "")
        {
            var file = new FileInfo(path);

            return $"{extraLogLevel} --> {file.Name}:{line} ({method}) --> {message}";
        }

        private static void EnsureLogger()
        {
            if (_log != null) return;

            var assembly = Assembly.GetEntryAssembly();
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            var configFile = GetConfigFile();

            XmlConfigurator.Configure(logRepository, configFile);
            _log = LogManager.GetLogger(assembly, assembly.ManifestModule.Name.Replace(".dll", "").Replace(".", " "));
        }

        private static FileInfo GetConfigFile()
        {
            FileInfo configFile = null;
            var configFileNames = new[] { "Config/log4net.config", "log4net.config" };

            foreach (var configFileName in configFileNames)
            {
                configFile = new FileInfo(configFileName);
                if (configFile.Exists) break;
            }

            if (configFile == null || !configFile.Exists) throw new NullReferenceException("Log4net config file not found.");

            return configFile;
        }
    }
}
