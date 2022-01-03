using System;
using UnityEngine;
using UnityEngine.Diagnostics;

namespace BetterDebug
{
    public static class AdvancedDebug
    {
        /// <summary>
        /// Logs a message to the console and writes to a log file in devmode, includes timestamp
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="any"></param>
        public static void Log<T>(T any)
        {
            Debug.Log("INFO: " + any.ToString() + " | " + DateTime.Now.ToString());
        }

        /// <summary>
        /// Logs a warning to the console and writes to a log file in devmode, includes timestamp
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="any"></param>
        public static void LogWarning<T>(T any)
        {
            Debug.LogWarning("WARN: " + any.ToString() + " | " + DateTime.Now.ToString());
        }

        /// <summary>
        /// Logs an error to the console and writes to a log file in devmode, includes timestamp
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="any"></param>
        public static void LogError<T>(T any)
        {
            Debug.LogError("ERR:" + any.ToString() + " | " + DateTime.Now.ToString());
        }

        /// <summary>
        /// Logs an exception to the console and writes to a log file in devmode, includes timestamp
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="any"></param>
        public static void LogException(Exception ex)
        {
            Debug.LogError("EX:" + ex + " TRACE: " + ex.StackTrace + " | " + DateTime.Now.ToString());
        }

        /// <summary>
        /// Logs an exception to the console and writes to a log file in devmode, includes timestamp
        /// Also crashes the application with reason FatalError
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="any"></param>
        public static void LogException(Exception ex, bool fatal)
        {
            Debug.LogError("EX:" + ex + " TRACE: " + ex.StackTrace + " | " + DateTime.Now.ToString());

            if (fatal)
            {
                Utils.ForceCrash(ForcedCrashCategory.FatalError);
            }
        }
    }
}
