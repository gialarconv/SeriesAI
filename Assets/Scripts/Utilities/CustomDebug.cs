using UnityEngine;
using System.Runtime.CompilerServices;
using System.IO;

namespace SeriesAI.Utilities
{
    public static class CustomDebug
    {
        public static void Log(string title, string body, Color color, [CallerFilePath] string file = "", [CallerLineNumber] int line = 0)
        {
            string fileName = Path.GetFileName(file);
            string message =
                $"<b><color=#{ColorUtility.ToHtmlStringRGB(color)}>{title}</color></b>: {body} (File: {fileName}, Line: {line})";
            Debug.Log(message);
        }

        public static void LogEditor(string title, string body, Color color, [CallerFilePath] string file = "", [CallerLineNumber] int line = 0)
        {
            if (!Application.isEditor) 
                return;
            
            string fileName = Path.GetFileName(file);
            string message =
                $"<b><color=#{ColorUtility.ToHtmlStringRGB(color)}>{title}</color></b>: {body} (File: {fileName}, Line: {line})";
            Debug.Log(message);
        }
        
        public static void LogWarning(string title, string body, [CallerFilePath] string file = "", [CallerLineNumber] int line = 0)
        {
            string fileName = Path.GetFileName(file);
            string message = $"<b>{title}</b>: {body} (File: {fileName}, Line: {line})";
            Debug.LogWarning(message);
        }

        public static void LogWarningEditor(string title, string body, [CallerFilePath] string file = "", [CallerLineNumber] int line = 0)
        {
            if (!Application.isEditor) 
                return;
            
            string fileName = Path.GetFileName(file);
            string message = $"<b>{title}</b>: {body} (File: {fileName}, Line: {line})";
            Debug.LogWarning(message);
        }

        public static void LogError(string title, string body, [CallerFilePath] string file = "", [CallerLineNumber] int line = 0)
        {
            string fileName = Path.GetFileName(file);
            string message = $"<b>{title}</b>: {body} (File: {fileName}, Line: {line})";
            Debug.LogError(message);
        }
        public static void LogErrorEditor(string title, string body, [CallerFilePath] string file = "", [CallerLineNumber] int line = 0)
        {
            if (!Application.isEditor) 
                return;
            
            string fileName = Path.GetFileName(file);
            string message = $"<b>{title}</b>: {body} (File: {fileName}, Line: {line})";
            Debug.LogError(message);
        }
    }
}