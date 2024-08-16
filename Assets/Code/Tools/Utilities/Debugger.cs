using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    public static class Debugger
    {
        public static bool debug = true;

        public static void Log(float text) => Log(text.ToString());
        public static void Log(string text)
        {
            if(debug) Debug.Log(text);
        }

        public static void Warning(string text)
        {
            if (debug) Debug.LogWarning(text);
        }

        public static void Error(string text)
        {
            if (debug) Debug.LogError(text);
        }
    }
}
