using System;
using UnityEngine;

namespace TurnBasedGameTemplate.Tools.Logger
{
    public static class Logger
    {
        const char Period = '.';
        const string OpenBrackets = "[";
        const char CloseBrackets = ']';
        const string OpenColor = ": <color={0}><b>";
        const string CloseColor = "</b></color>";

        /// <summary>    Use "black", "red" or any other html code to set the color. </summary>
        public static void Log<T>(object log, string colorName = "black")
        {
            var coloredText = OpenColor + log + CloseColor;
            var context = OpenBrackets + GetTypeString(typeof(T)) + CloseBrackets;
            log = string.Format(context + coloredText, colorName);
            Debug.Log(log);
        }

        static string GetTypeString(Type t)
        {
            var split = t.ToString().Split(Period);
            return split[split.Length - 1];
        }
    }
}